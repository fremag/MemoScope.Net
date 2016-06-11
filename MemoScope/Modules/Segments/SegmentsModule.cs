using MemoScope.Core;
using MemoScope.Core.Data;
using MemoScope.Core.Helpers;
using MemoScope.Modules.InstancesMixed;
using System.Collections.Generic;
using System.Linq;

namespace MemoScope.Modules.Segments
{
    public partial class SegmentsModule : UIClrDumpModule
    {
        private List<SegmentInformation> segments;
        public SegmentsModule()
        {
            InitializeComponent();
        }

        public void Setup(ClrDump clrDump)
        {
            ClrDump = clrDump;
            Icon = Properties.Resources.outline_wight_gallery_small;
            Name = $"#{clrDump.Id} - Segments";

            dlvSegments.InitColumns<SegmentInformation>();
        }

        public override void Init()
        {
            base.Init();
            segments = ClrDump.Segments.Select(seg => new SegmentInformation(seg)).ToList();
        }

        public override void PostInit()
        {
            base.PostInit();
            Summary = $"{segments.Count} segments";
            dlvSegments.Objects = segments;
        }

        private void dlvSegments_CellClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
        {
            if( e.ClickCount != 2)
            {
                return;
            }
            var segment = dlvSegments.SelectedObject<SegmentInformation>();
            if (segment == null)
            {
                return;
            }
            BeginTask("Looking for instances in segment...");
            var addressList = ClrDump.Eval(() => segment.Instances.ToList());
            var addresses = new AddressContainerList(addressList);
            Status("Displaying instances in segment...");
            InstancesMixedModule.Create(ClrDump, addresses, this, mod => RequestDockModule(mod), $"{ClrDump.Id} - {segment.Start:X}");
            EndTask("Segment instances displayed.");
        }
    }
}
