using MemoScope.Core;
using MemoScope.Core.Data;
using MemoScope.Core.Helpers;
using System.Collections.Generic;

namespace MemoScope.Modules.RootPath
{
    public partial class RootPathModule : UIClrDumpModule
    {
        private List<RootPathInformation> RootPath { get; set; }
        private ClrDumpObject ClrDumpObject { get; set; }
        public RootPathModule()
        {
            InitializeComponent();
        }

        public override void Init()
        {
            dtlvDistribution.InitColumns<RootPathInformation>();
            dtlvDistribution.SetUpTypeColumn<RootPathInformation>(this);
            dtlvDistribution.SetUpAddressColumn<RootPathInformation>(this);
        }

        internal void Setup(ClrDumpObject clrDumpObject)
        {
            ClrDump = clrDumpObject.ClrDump;
            Icon = Properties.Resources.molecule_small;
            ClrDumpObject = clrDumpObject;

            Name = $"#{ClrDump.Id} - RootPath- {ClrDumpObject.Address:X}";
        }

        public override void PostInit()
        {
            Summary = $"";
        }
    }
}
