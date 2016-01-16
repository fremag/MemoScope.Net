using BrightIdeasSoftware;
using Microsoft.Diagnostics.Runtime;
using System.Windows.Forms;

namespace MemoScope.Modules.Regions
{
    public class RegionInformation
    {
        private ClrMemoryRegion region;

        public RegionInformation(ClrMemoryRegion region)
        {
            this.region = region;
        }

        [OLVColumn(TextAlign = HorizontalAlignment.Right, AspectToStringFormat = "{0:X}")]
        public ulong Start => region.Address;
        [OLVColumn(TextAlign = HorizontalAlignment.Right, AspectToStringFormat = "{0:###,###,###,##0}")]
        public ulong Size => region.Size;
        [OLVColumn]
        public ClrMemoryRegionType Type => region.Type;
        [OLVColumn(TextAlign = HorizontalAlignment.Right, AspectToStringFormat = "{0:###,###,###,##0}")]
        public int HeapNumber => region.HeapNumber;
        [OLVColumn]
        public string Module => region.Module;
    }
}