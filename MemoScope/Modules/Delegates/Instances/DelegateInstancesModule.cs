using MemoScope.Core;
using MemoScope.Core.Helpers;
using MemoScope.Core.Data;
using System.Collections.Generic;
using WinFwk.UICommands;
using MemoScope.Modules.Delegates.Targets;

namespace MemoScope.Modules.Delegates.Instances
{
    public partial class DelegateInstancesModule : UIClrDumpModule, UIDataProvider<ClrDumpObject>
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

        public ClrDumpObject Data
        {
            get
            {
                var instance = dlvDelegateInstances.SelectedObject<DelegateInstanceInformation>();
                return new ClrDumpObject(clrDumpType, instance.Address);
            }
        }

        private void dlvDelegateInstances_CellClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
        {
            if (e.ClickCount != 2)
            {
                return;
            }
            if (e.Column == dlvDelegateInstances[nameof(DelegateInstanceInformation.Address)] )
            {
                return;
            }
            var data = Data;
            if (data == null)
            {
                return;
            }
            DelegateTargetsCommand.Display(this, data);
        }
    }
}
