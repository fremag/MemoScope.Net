using BrightIdeasSoftware;
using MemoScope.Core.Data;
using MemoScope.Core.Helpers;
using MemoScope.Modules.TypeDetails;
using System.Windows.Forms;
using WinFwk.UICommands;
using WinFwk.UIModules;

namespace MemoScope.Modules.Instances
{
    public partial class InstancesModule : UIModule, UIDataProvider<ClrDumpType>
    {
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
        }

        public override void PostInit()
        {
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
