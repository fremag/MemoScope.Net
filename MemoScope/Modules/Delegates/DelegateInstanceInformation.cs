using BrightIdeasSoftware;
using MemoScope.Core.Data;
using WinFwk.UITools;

namespace MemoScope.Modules.Delegates
{
    public class DelegateInstanceInformation : IAddressData, ITypeNameData
    {
        ClrDumpType ClrDumpType { get; }

        public DelegateInstanceInformation(ulong address, ClrDumpType clrDumpType, long targetCount)
        {
            Address = address;
            ClrDumpType = clrDumpType;
            Targets = targetCount;
        }

        [OLVColumn]
        public ulong Address { get; }

        [OLVColumn(Title="Type")]
        public string TypeName => ClrDumpType.TypeName;

        [IntColumn]
        public long Targets { get; }
    }
}