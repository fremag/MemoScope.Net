using MemoScope.Core.Data;
using BrightIdeasSoftware;
using MemoScope.Core;
using Microsoft.Diagnostics.Runtime;
using ClrObject = MemoScope.Core.Data.ClrObject;

namespace MemoScope.Modules.Delegates
{
    public class LoneTargetInformation : IAddressData, ITypeNameData
    {
        private ClrDump clrDump;
        private ClrMethod methInfo;
        private ClrObject target;
        ClrObject owner;
        public LoneTargetInformation(ClrDump clrDump, ClrObject target, ClrMethod methInfo, ClrObject owner)
        {
            this.clrDump = clrDump;
            this.target = target;
            this.methInfo = methInfo;
            this.owner = owner;
        }

        [OLVColumn]
        public ulong Address => target.Address;

        [OLVColumn]
        public string TypeName => target.Type.Name;

        [OLVColumn]
        public string Method => methInfo?.GetFullSignature();

        [OLVColumn]
        public ulong OwnerAddress => owner.Address;

        [OLVColumn]
        public string OwnerType => owner.Type?.Name;
    }
}