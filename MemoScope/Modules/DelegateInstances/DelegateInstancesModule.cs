using MemoScope.Core;
using MemoScope.Core.Helpers;
using MemoScope.Core.Data;
using System.Collections.Generic;
using MemoScope.Modules.DelegateTypes;

namespace MemoScope.Modules.DelegateInstances
{
    public partial class DelegateInstancesModule : UIClrDumpModule
    {
        List<DelegateInstanceInformation> delegateInstanceInformations;
        ClrDumpType clrDumpType;

        public DelegateInstancesModule()
        {
            InitializeComponent();
        }

        public void Setup(ClrDumpType clrDumpType)
        {
            this.clrDumpType = clrDumpType;
            ClrDump = clrDumpType.ClrDump;
            Icon = Properties.Resources.attributes_display_small;
            Name = $"#{ClrDump.Id} - Delegates - {clrDumpType.TypeName}";

            dlvDelegateInstances.InitColumns<DelegateInstanceInformation>();
            dlvDelegateInstances.SetUpAddressColumn<DelegateInstanceInformation>(this);
            dlvDelegateInstances.SetUpTypeColumn<DelegateInstanceInformation>(this);
        }

        public override void Init()
        {
            delegateInstanceInformations = DelegatesAnalysis.GetDelegateInstanceInformation(clrDumpType);
        }

        public override void PostInit()
        {
            Summary = $"{delegateInstanceInformations.Count} Delegates Instances";
            dlvDelegateInstances.Objects = delegateInstanceInformations;
        }
        
        private void dlvDelegateInstances_CellClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
        {
            if (e.ClickCount != 2)
            {
                return;
            }
            // TODO: open invocation target module
        }
    }
}
