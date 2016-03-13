using BrightIdeasSoftware;
using MemoScope.Core.Data;
using Microsoft.Diagnostics.Runtime;

namespace MemoScope.Modules.Delegates
{
    public class DelegateTargetInformation : IAddressData, ITypeNameData
    {
        private ClrMethod methInfo;

        ClrDumpType ClrDumpType { get; }

        public DelegateTargetInformation(ulong address, ClrDumpType clrDumpType)
        {
            Address = address;
            ClrDumpType = clrDumpType;
        }

        public DelegateTargetInformation(ulong address, ClrDumpType clrDumpType, ClrMethod methInfo) : this(address, clrDumpType)
        {
            this.methInfo = methInfo;
        }

        [OLVColumn]
        public ulong Address { get; }

        [OLVColumn(Title="Type")]
        public string TypeName => ClrDumpType?.TypeName;

        [OLVColumn(Width=500)]
        public string Method => methInfo?.GetFullSignature();
    }
}