using MemoScope.Core;
using Microsoft.Diagnostics.Runtime;
using MemoScope.Core.Data;
using BrightIdeasSoftware;

namespace MemoScope.Modules.ClrRoots
{
    public class ClrRootsInformation : IAddressData, ITypeNameData
    {
        ClrDump ClrDump { get; }
        ClrRoot ClrRoot { get; }
        public ClrRootsInformation(ClrDump clrDump, ClrRoot clrRoot)
        {
            ClrDump = clrDump;
            ClrRoot = clrRoot;
        }

        [OLVColumn]
        public ulong Address => ClrRoot.Address;

        [OLVColumn]
        public bool IsInterior => ClrRoot.IsInterior;
        [OLVColumn]
        public bool IsPinned => ClrRoot.IsPinned;
        [OLVColumn]
        public bool IsPossibleFalsePositive => ClrRoot.IsPossibleFalsePositive;
        [OLVColumn]
        public GCRootKind Kind => ClrRoot.Kind ;
        [OLVColumn]
        public ulong ObjectAddress => ClrRoot.Object;

        [OLVColumn(Title="Name")]
        public string TypeName => ClrRoot.Type?.Name;

        public ClrType Type => ClrRoot.Type;
    }
}