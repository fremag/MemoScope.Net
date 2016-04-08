using BrightIdeasSoftware;
using Microsoft.Diagnostics.Runtime;
using WinFwk.UITools;

namespace MemoScope.Modules.Regions
{
    public class RegionInformation
    {
        private ClrMemoryRegion region;

        public RegionInformation(ClrMemoryRegion region)
        {
            this.region = region;
        }

        [AddressColumn]
        public ulong Start => region.Address;
        [IntColumn]
        public ulong Size => region.Size;
        [OLVColumn]
        public ClrMemoryRegionType Type => region.Type;
        [IntColumn]
        public int HeapNumber => region.HeapNumber;
        [OLVColumn]
        public string Module => region.Module;
    }
}