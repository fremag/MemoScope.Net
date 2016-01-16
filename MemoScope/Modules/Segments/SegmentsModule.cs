using MemoScope.Core;
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
    }
}
