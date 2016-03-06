using MemoScope.Core;
using MemoScope.Core.Helpers;
using WinFwk.UICommands;
using MemoScope.Core.Data;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MemoScope.Modules.Delegates
{
    public partial class DelegateModule : UIClrDumpModule, UIDataProvider<ClrDumpType>
    {
        List<DelegateInformation> delegateInformations;

        public DelegateModule()
        {
            InitializeComponent();
        }

        public void Setup(ClrDump clrDump)
        {
            ClrDump = clrDump;
            Icon = Properties.Resources.macro_show_all_actions_small;
            Name = $"#{clrDump.Id} - Delegates";

            dlvDelegates.InitColumns<DelegateInformation>();
            dlvDelegates.SetUpTypeColumn<DelegateInformation>(this);
            dlvDelegates.SetTypeNameFilter<DelegateInformation>(regexFilterControl);

        }

        public override void Init()
        {
            base.Init();
            var types = DelegatesAnalysis.GetDelegateTypes(ClrDump);
            delegateInformations = types.Select(t => new DelegateInformation(ClrDump, t)).ToList();
        }

        public override void PostInit()
        {
            base.PostInit();
            Summary = $"Delegates";
            dlvDelegates.Objects = delegateInformations;
            dlvDelegates.Sort(nameof(DelegateInformation.Count), SortOrder.Descending);
        }

        ClrDumpType UIDataProvider<ClrDumpType>.Data
        {
            get
            {
                var delegateInformation = dlvDelegates.SelectedObject<DelegateInformation>();
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
// TODO
        }
    }
}
