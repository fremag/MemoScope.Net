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
using System.Threading.Tasks;
using System.Threading;

namespace MemoScope.Modules.Instances
{
    public partial class InstancesModule : UIClrDumpModule, UIDataProvider<ClrDumpType>, UIDataProvider<ClrDumpObject>, IModelFilter
    {
        private List<FieldInfo> fieldInfos;
        private AddressList AddressList { get; set; }
        private List<Func<bool>> filters;
        private FieldAccessor myFieldAccessor;
        HashSet<ulong> filteredAddresses = new HashSet<ulong>();

        public static void Create(AddressList addresses, UIModule parent, Action<InstancesModule> postInit, string name=null )
        {
            if( addresses == null)
            {
                MessageBox.Show("No instances selected !", "Error", MessageBoxButtons.OK);
                return;
            }
            UIModuleFactory.CreateModule<InstancesModule>(
                mod => {
                    mod.UIModuleParent = parent; mod.Setup(addresses);
                    if( name != null)
                    {
                        mod.Name = name;
                    }
                },
                mod => postInit(mod)
                );
        }

        public InstancesModule()
        {
            InitializeComponent();
            Icon = Properties.Resources.legend_small;
            InitCodeEditor();
            dlvAdresses.ModelFilter = this;
        }

        private void InitCodeEditor()
        {
            codeTriggersControl.CodeGetter = o =>
            {
                var fieldNode = o as FieldNode;
                string prefix = FieldAccessor.GetFuncName(fieldNode.ClrType.ElementType);
                string code = $" x.{prefix}(\"{fieldNode.FullName}\") ";
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
            dtlvFields.SetUpTypeColumn<FieldNode>(this);
            dtlvFields.CheckBoxes = true;
            dtlvFields.CheckStatePutter += OnCheckStateChanged;
            dtlvFields.IsSimpleDragSource = true;
        }

        private void CreateDefaultColumns()
        {
            dlvAdresses.ContextMenuStrip?.Items.Clear();
            dlvAdresses.AllColumns.Clear();
            dlvAdresses.AddRowNumberColumn();
            dlvAdresses.AddAddressColumn(o => o, this);
            dlvAdresses.AddSimpleValueColumn(o => (ulong)o, AddressList.ClrDump, AddressList.ClrType);
            dlvAdresses.AddSizeColumn(o => (ulong)o, AddressList.ClrDump, AddressList.ClrType);
            dlvAdresses.AddRefInColumn(o => (ulong)o, AddressList.ClrDump);
            // Do not sort ! Too slow...
            dlvAdresses.ShowSortIndicators = false;
            dlvAdresses.BeforeSorting += (sender, e) => e.Canceled = true;
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
            bool hasSimpleValue = fieldNode.ClrType.HasSimpleValue;
            var col = new OLVColumn(fieldNode.FullName, null);
            col.Width = 120;
            switch (fieldNode.ClrType.ElementType)
            {
                case ClrElementType.Int16:
                case ClrElementType.Int32:
                case ClrElementType.Int64:
                case ClrElementType.Int8:
                case ClrElementType.UInt16:
                case ClrElementType.UInt32:
                case ClrElementType.UInt64:
                case ClrElementType.UInt8:
                    col.TextAlign = HorizontalAlignment.Right;
                    col.AspectToStringFormat = "{0:###,###,###,##0}";
                    break;
                case ClrElementType.Float:
                case ClrElementType.Double:
                    col.TextAlign = HorizontalAlignment.Right;
                    break;
                case ClrElementType.Boolean:
                    col.TextAlign = HorizontalAlignment.Center;
                    col.CheckBoxes = true;
                    break;
                case ClrElementType.Object:
                case ClrElementType.Array:
                case ClrElementType.SZArray:
                    col.AspectGetter = o => o;
                    dlvAdresses.SetUpAddressColumn(col, this);
                    break;
                case ClrElementType.Struct:
                    break;
            }
            dlvAdresses.AllColumns.Add(col);

            List<string> fields = new List<string>();
            string fieldName = fieldNode.FieldName;
            do
            {
                fields.Insert(0, fieldName);
                var parent = dtlvFields.GetParent(fieldNode);
                fieldNode =  parent as FieldNode;
                fieldName = fieldNode == null ? null : fieldNode.FieldName;
            } while (fieldNode != null);

            col.AspectGetter = o =>
            {
                ulong address = (ulong)o;
                var type = AddressList.ClrType;
                var val = AddressList.ClrDump.GetFieldValue(address, type, fields);
                return val;
            };
        }

        // Not Gui thread
        public override void Init()
        {
            var dump = AddressList.ClrDump;
            var type = AddressList.ClrType;
            fieldInfos = dump.GetFieldInfos(type);
        }

        // Gui thread
        public override void PostInit()
        {
            var fieldNodes = fieldInfos.Select(fieldInfo=> new FieldNode(fieldInfo.Name, fieldInfo.FieldType, AddressList.ClrDump));
            dtlvFields.Roots = fieldNodes;
            dlvAdresses.VirtualListDataSource = new InstanceVirtualSource(dlvAdresses, AddressList, filteredAddresses);
            Summary = $"{AddressList.Addresses.Count:###,###,###,##0} instances";
            RefreshInstanceCounter();
        }

        ClrDumpType UIDataProvider<ClrDumpType>.Data
        {
            get
            {
                return new ClrDumpType(AddressList.ClrDump, AddressList.ClrType);
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
            filters = new List<Func<bool>>();
            foreach (var trigger in triggers)
            {
                try
                {
                    CompiledExpression<bool> exp = new CompiledExpression<bool>(trigger.Code) { TypeRegistry = reg };
                    Func<bool> comp = exp.Compile();
                    filters.Add(comp);
                }
                catch (Exception ex)
                {
                    Log($"Can't compile expression: {trigger.Code}", ex);
                }
            }
            CancellationTokenSource source = new CancellationTokenSource();
            var token = source.Token;
            BeginTask("Filtering instances...", source);
            dlvAdresses.BeginUpdate();
            Task.Run(() => FilterAddresses(token)  )
                .ContinueWith(task => {
                    if (token.IsCancellationRequested)
                    {
                        EndTask("Instances NOT filtered.");
                    }
                    else
                    {
                        dlvAdresses.UseFiltering = true;
                        EndTask("Instances filtered.");
                    }
                    dlvAdresses.EndUpdate();
                    RefreshInstanceCounter();
                }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void RefreshInstanceCounter()
        {
            if (dlvAdresses.UseFiltering)
            {
                tsbInstancesCount.Text = $"# instances: {filteredAddresses.Count:###,###,###,##0} / {AddressList.Addresses.Count:###,###,###,##0}";
            }
            else
            {
                tsbInstancesCount.Text = $"# instances: {AddressList.Addresses.Count:###,###,###,##0}";
            }
        }

        private void FilterAddresses(CancellationToken token)
        {
            var addresses = AddressList.Addresses;
            int c = addresses.Count;
            const int batchSize = 1024;
            for (int i = 0; i < c && ! token.IsCancellationRequested; i += batchSize)
            {
                Status($"Filtering: {i:###,###,###,##0} / {c:###,###,###,##0}");
                ClrDump.Run(() =>
                {
                    int max = Math.Min(i + batchSize, c);
                    for (int j = i; j < max; j++)
                    {
                        ulong address = addresses[j];
                        if (DoFilter(address))
                        {
                            filteredAddresses.Add(address);
                        }
                        if (token.IsCancellationRequested)
                        {
                            filteredAddresses.Clear();
                            return ;
                        }
                    }
                });
            }
        }

        public bool Filter(object modelObject)
        {
            ulong address = (ulong)modelObject;
            bool b = filteredAddresses.Contains(address);
            return b;
        }

        public bool DoFilter(ulong address)
        {
            myFieldAccessor.Address = address;
            foreach (var filter in filters)
            {
                bool result = filter();
                if( result)
                {
                    return true;
                }
            }
            return false;
        }

        private void tsbClearFilter_Click(object sender, EventArgs e)
        {
            filteredAddresses.Clear();
            RefreshInstanceCounter();
            dlvAdresses.UseFiltering = false;
            Status("Filter removed.");
        }

        public override IEnumerable<ObjectListView> ListViews => new ObjectListView[] { dlvAdresses };

    }
}
