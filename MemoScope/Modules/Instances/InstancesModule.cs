using BrightIdeasSoftware;
using MemoScope.Core;
using MemoScope.Core.Data;
using MemoScope.Core.Helpers;
using MemoScope.Modules.TypeDetails;
using Microsoft.Diagnostics.Runtime;
using System.Collections.Generic;
using System.Linq;
using WinFwk.UICommands;
using WinFwk.UIModules;
using System.Windows.Forms;

namespace MemoScope.Modules.Instances
{
    public partial class InstancesModule : UIModule, UIDataProvider<ClrDumpType>
    {
        private IList<ClrInstanceField> fields;

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
            dlvAdresses.AddAddressColumn(o => o);
            dlvAdresses.RebuildColumns();
            

            Generator.GenerateColumns(dtlvFields, typeof(FieldNode), false);
            dtlvFields.SetUpTypeColumn(nameof(FieldNode.TypeName));
            dtlvFields.CheckBoxes = true;
            dtlvFields.CheckStatePutter += OnCheckStateChanged;
            dtlvFields.CanExpandGetter = o => ((FieldNode)o).HasChildren;
            dtlvFields.ChildrenGetter = o => ((FieldNode)o).Children;
        }

        private CheckState OnCheckStateChanged(object rowObject, CheckState newValue)
        {
            dlvAdresses.AllColumns.Clear();
            dlvAdresses.AddAddressColumn(o => o);
            if (newValue == CheckState.Checked)
            {
                AddFieldColumn(rowObject as FieldNode);
            }

            foreach (FieldNode fieldNode in dtlvFields.CheckedObjects)
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
            dlvAdresses.AllColumns.Add(col);

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
