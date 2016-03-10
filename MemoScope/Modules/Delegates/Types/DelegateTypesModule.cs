using MemoScope.Core;
using MemoScope.Core.Helpers;
using WinFwk.UICommands;
using MemoScope.Core.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using MemoScope.Modules.Delegates.Instances;

namespace MemoScope.Modules.Delegates.Types
{
    public partial class DelegateTypesModule : UIClrDumpModule, UIDataProvider<ClrDumpType>
    {
        List<DelegateTypeInformation> delegateInformations;

        public DelegateTypesModule()
        {
            InitializeComponent();
        }

        public void Setup(ClrDump clrDump)
        {
            ClrDump = clrDump;
            Icon = Properties.Resources.macro_show_all_actions_small;
            Name = $"#{clrDump.Id} - Delegate Types";

            dlvDelegateTypes.InitColumns<DelegateTypeInformation>();
            dlvDelegateTypes.SetUpTypeColumn<DelegateTypeInformation>(this);
            dlvDelegateTypes.SetTypeNameFilter<DelegateTypeInformation>(regexFilterControl);
        }

        public override void Init()
        {
            delegateInformations = DelegatesAnalysis.GetDelegateTypeInformations(ClrDump);
        }

        public override void PostInit()
        {
            Summary = $"{delegateInformations.Count:###,###,###,##0} Delegates Types";
            dlvDelegateTypes.Objects = delegateInformations;
            dlvDelegateTypes.Sort(nameof(DelegateTypeInformation.Count), SortOrder.Descending);
        }

        public ClrDumpType Data
        {
            get
            {
                var delegateInformation = dlvDelegateTypes.SelectedObject<DelegateTypeInformation>();
                if (delegateInformation != null)
                {
                    return new ClrDumpType(ClrDump, delegateInformation.ClrType);
                }
                return null;
            }
        }

        private void dlvDelegates_CellClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
        {
            if (e.ClickCount != 2)
            {
                return;
            }

            var selectedDelegateType = Data;
            if(selectedDelegateType == null)
            {
                return;
            }

            DelegateInstancesCommand.Display(this, selectedDelegateType);
        }
    }
}
