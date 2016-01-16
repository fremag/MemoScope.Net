using MemoScope.Core;
using System.Collections.Generic;
using System.Linq;

namespace MemoScope.Modules.Regions
{
    public partial class RegionsModule : UIClrDumpModule
    {
        private List<RegionInformation> Regions;
        public RegionsModule()
        {
            InitializeComponent();
        }

        public void Setup(ClrDump clrDump)
        {
            ClrDump = clrDump;
            Icon = Properties.Resources.borders_accent_small;
            Name = $"#{clrDump.Id} - Regions";

            dlvRegions.InitColumns<RegionInformation>();
        }

        public override void Init()
        {
            base.Init();
            Regions = ClrDump.Regions.Select(reg=> new RegionInformation(reg)).ToList();
        }

        public override void PostInit()
        {
            base.PostInit();
            Summary = $"{Regions.Count} Regions";
            dlvRegions.Objects = Regions;
        }
    }
}
