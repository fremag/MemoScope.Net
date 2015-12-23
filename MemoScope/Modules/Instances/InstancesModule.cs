using BrightIdeasSoftware;
using MemoScope.Core.Data;
using MemoScope.Core.Helpers;
using MemoScope.Modules.TypeDetails;
using Microsoft.Diagnostics.Runtime;
using System.Collections.Generic;
using System.Linq;
using WinFwk.UICommands;
using WinFwk.UIModules;
using System.Windows.Forms;
using System;

namespace MemoScope.Modules.Instances
{
    public partial class InstancesModule : UIModule, UIDataProvider<ClrDumpType>
    {
        private IList<ClrInstanceField> fields;

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
        }

        internal void Setup(AddressList addressList)
        {
            AddressList = addressList;
            Name = $"#{addressList.ClrDump.Id} - {addressList.ClrType.Name}";
            CreateDefaultColumns();
            dlvAdresses.RebuildColumns();

            Generator.GenerateColumns(dtlvFields, typeof(FieldNode), false);
            dtlvFields.SetUpTypeColumn(nameof(FieldNode.TypeName));
            dtlvFields.CheckBoxes = true;
            dtlvFields.CheckStatePutter += OnCheckStateChanged;
            dtlvFields.CanExpandGetter = o => ((FieldNode)o).HasChildren;
            dtlvFields.ChildrenGetter = o => ((FieldNode)o).Children;
            dtlvFields.RegiserDataProvider(() => { return new ClrDumpType(AddressList.ClrDump, dtlvFields.SelectedObject<FieldNode>()?.ClrType); }, this);
        }

        private void CreateDefaultColumns()
        {
            dlvAdresses.AllColumns.Clear();
            dlvAdresses.AddAddressColumn(o => o, (o) => AddressList.ClrType, AddressList.ClrDump, this);
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

            var col = new OLVColumn(fieldNode.Name, null);
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
    }
}
