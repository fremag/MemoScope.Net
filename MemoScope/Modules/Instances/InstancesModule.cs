using BrightIdeasSoftware;
using MemoScope.Core.Data;
using MemoScope.Core.Helpers;
using Microsoft.Diagnostics.Runtime;
using System.Collections.Generic;
using System.Linq;
using WinFwk.UICommands;
using WinFwk.UIModules;
using System.Windows.Forms;
using System;
using MemoScope.Core;
using MemoScope.Tools.CodeTriggers;
using ExpressionEvaluator;
using System.Text.RegularExpressions;

namespace MemoScope.Modules.Instances
{
    public partial class InstancesModule : UIClrDumpModule, UIDataProvider<ClrDumpType>, UIDataProvider<AddressList>, UIDataProvider<ClrDumpObject>, IModelFilter
    {
        private IList<ClrInstanceField> fields;
        List<CompiledExpression<bool>> filters;
        FieldAccessor myFieldAccessor;

        public static void Create(AddressList addresses, UIModule parent, Action<InstancesModule> postInit )
        {
            if( addresses == null)
            {
                MessageBox.Show("No instances selected !", "Error", MessageBoxButtons.OK);
                return;
            }
            UIModuleFactory.CreateModule<InstancesModule>(
                mod => { mod.UIModuleParent = parent; mod.Setup(addresses); },
                mod => postInit(mod)
                );
        }

        private AddressList AddressList { get; set; }

        public InstancesModule()
        {
            InitializeComponent();
            Icon = Properties.Resources.scroll_pane_list;
            InitCodeEditor();
            dlvAdresses.ModelFilter = this;
        }

        private void InitCodeEditor()
        {
            codeTriggersControl.CodeGetter = o =>
            {
                var fieldNode = o as FieldNode;
                string prefix = FieldAccessor.GetFuncName(fieldNode.ClrType.ElementType);
                string code = $" x._{prefix}(\"{fieldNode.FullName}\") ";
                return code;
            };

            codeTriggersControl.SaveTriggers = triggers =>
            {
                MemoScopeSettings.Instance.InstanceFilters = triggers;
                MemoScopeSettings.Instance.Save();
            };

            codeTriggersControl.LoadTriggers = () =>
            {
                if (MemoScopeSettings.Instance != null)
                {
                    return new List<CodeTrigger>(MemoScopeSettings.Instance.InstanceFilters.Select(t => t.Clone()));
                }
                return null;
            };
        }

        internal void Setup(AddressList addressList)
        {
            AddressList = addressList;
            ClrDump = addressList.ClrDump;
            Name = $"#{addressList.ClrDump.Id} - {addressList.ClrType.Name}";
            myFieldAccessor = new FieldAccessor(ClrDump, addressList.ClrType );

            CreateDefaultColumns();
            dlvAdresses.RebuildColumns();

            dtlvFields.InitData<FieldNode>();
            dtlvFields.SetUpTypeColumn(nameof(FieldNode.TypeName), this);
            dtlvFields.CheckBoxes = true;
            dtlvFields.CheckStatePutter += OnCheckStateChanged;
            dtlvFields.IsSimpleDragSource = true;
        }

        private void CreateDefaultColumns()
        {
            dlvAdresses.AllColumns.Clear();
            dlvAdresses.AllColumns.Add(new OLVColumn("Address", null));
            dlvAdresses.AddAddressColumn(o => o, this);
            dlvAdresses.AddSimpleValueColumn(o => (ulong)o, AddressList.ClrDump, AddressList.ClrType);
            dlvAdresses.AddSizeColumn(o => (ulong)o, AddressList.ClrDump, AddressList.ClrType);
        }

        private CheckState OnCheckStateChanged(object rowObject, CheckState newValue)
        {
            CreateDefaultColumns();

            if (newValue == CheckState.Checked)
            {
                AddFieldColumn(rowObject as FieldNode);
            }

            foreach (FieldNode fieldNode in dtlvFields.CheckedObjects.OfType<FieldNode>().Where(fn => fn != rowObject))
            {
                AddFieldColumn(fieldNode);
            }

            dlvAdresses.RebuildColumns();

            return newValue;
        }

        private void AddFieldColumn(FieldNode fieldNode)
        {
            if( fieldNode == null)
            {
                return;
            }

            var col = new OLVColumn(fieldNode.FullName, null);
            col.Width = 120;
            switch( fieldNode.Field.ElementType)
            {
                case ClrElementType.Float:
                case ClrElementType.Int16:
                case ClrElementType.Int32:
                case ClrElementType.Int64:
                case ClrElementType.Int8:
                case ClrElementType.Double:
                case ClrElementType.UInt16:
                case ClrElementType.UInt32:
                case ClrElementType.UInt64:
                case ClrElementType.UInt8:
                    col.TextAlign = HorizontalAlignment.Right;
                    break;
                case ClrElementType.Object:
                case ClrElementType.Struct:
                    dlvAdresses.SetUpAddressColumn(col, o => o, this);
                    break;
            }
            dlvAdresses.AllColumns.Add(col);

            List<ClrInstanceField> fields = new List<ClrInstanceField>();
            ClrInstanceField field = fieldNode.Field;
            do
            {
                fields.Insert(0, field);
                var parent = dtlvFields.GetParent(fieldNode);
                fieldNode =  parent as FieldNode;
                field = fieldNode == null ? null : fieldNode.Field;
            } while (fieldNode != null);

            col.AspectGetter = o =>
            {
                ulong address = (ulong)o;
                var type = AddressList.ClrType;
                return AddressList.ClrDump.GetFieldValue(address, type, fields);
            };

        }

        // Not Gui thread
        public override void Init()
        {
            var dump = AddressList.ClrDump;
            var type = AddressList.ClrType;
            fields = dump.Eval(() => type.Fields);
        }

        // Gui thread
        public override void PostInit()
        {
            var fieldNodes = fields.Select(field => new FieldNode(field, AddressList.ClrDump));
            dtlvFields.Roots = fieldNodes;
            dlvAdresses.SetObjects(AddressList.Addresses);
            Summary = $"{AddressList.Addresses.Count:###,###,###,##0} instances";
        }

        ClrDumpType UIDataProvider<ClrDumpType>.Data
        {
            get
            {
                return new ClrDumpType(AddressList.ClrDump, AddressList.ClrType);
            }
        }

        AddressList UIDataProvider<AddressList>.Data
        {
            get
            {
                var type = dtlvFields.SelectedObject<FieldNode>()?.ClrType;
                if (type != null)
                {
                    return new AddressList(AddressList.ClrDump, type);
                }
                return null;
            }
        }

        ClrDumpObject UIDataProvider<ClrDumpObject>.Data
        {
            get
            {
                var selectedAddressObj = dlvAdresses.SelectedObject;
                if( selectedAddressObj is ulong)
                {
                    ulong address = (ulong)selectedAddressObj;
                    return new ClrDumpObject(AddressList.ClrDump, AddressList.ClrDump.GetObjectType(address), address);
                }
                return null;
            }
        }

        private void tspApplyfilter_Click(object sender, EventArgs e)
        {
            var triggers = codeTriggersControl.Triggers.Where(trig => trig.Active).ToArray();
            TypeRegistry reg = new TypeRegistry();
            reg.RegisterType<DateTime>();
            reg.RegisterType<TimeSpan>();
            reg.RegisterType<Regex>();
            reg.RegisterSymbol("x", myFieldAccessor);
            filters = new List<CompiledExpression<bool>>();
            foreach (var trigger in triggers)
            {
                CompiledExpression<bool> exp = new CompiledExpression<bool>(trigger.Code) { TypeRegistry = reg };
                filters.Add(exp);
            }

            dlvAdresses.UseFiltering = true;
        }

        public bool Filter(object modelObject)
        {
            ulong address = (ulong)modelObject;
            myFieldAccessor.Address = address;
            foreach (var filter in filters)
            {
                bool result = filter.Eval();
                if( result)
                {
                    return true;
                }
            }
            return false;
        }

        private void tsbClearFilter_Click(object sender, EventArgs e)
        {
            dlvAdresses.UseFiltering = false;
        }
    }
}
