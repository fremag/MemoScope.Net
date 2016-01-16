using BrightIdeasSoftware;
using Microsoft.Diagnostics.Runtime;
using System.Windows.Forms;

namespace MemoScope.Modules.Segments
{
    public class SegmentInformation
    {
        private ClrSegment segment;

        public SegmentInformation(ClrSegment segment)
        {
            this.segment = segment;
        }

        [OLVColumn(TextAlign = HorizontalAlignment.Right, AspectToStringFormat = "{0:X}")]
        public ulong Start => segment.Start;
        [OLVColumn(TextAlign = HorizontalAlignment.Right, AspectToStringFormat = "{0:###,###,###,##0}")]
        public ulong Length => segment.Length;
        [OLVColumn(TextAlign = HorizontalAlignment.Center)]
        public bool IsLarge => segment.IsLarge;
        [OLVColumn(TextAlign = HorizontalAlignment.Right, AspectToStringFormat = "{0:X}")]
        public ulong End => segment.End;
        [OLVColumn(Title = "Gen 0 Length", TextAlign = HorizontalAlignment.Right, AspectToStringFormat = "{0:###,###,###,##0}")]
        public ulong Gen0Length => segment.Gen0Length;
        [OLVColumn(Title = "Gen 1 Length", TextAlign = HorizontalAlignment.Right, AspectToStringFormat = "{0:###,###,###,##0}")]
        public ulong Gen1Length => segment.Gen1Length;
        [OLVColumn(Title="Gen 2 Length", TextAlign = HorizontalAlignment.Right, AspectToStringFormat = "{0:###,###,###,##0}")]
        public ulong Gen2Length => segment.Gen2Length;
        [OLVColumn(TextAlign = HorizontalAlignment.Center)]
        public bool IsEphemeral => segment.IsEphemeral;
    }
}