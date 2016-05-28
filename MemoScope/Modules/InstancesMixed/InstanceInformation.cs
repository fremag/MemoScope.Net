using BrightIdeasSoftware;
using MemoScope.Core;
using MemoScope.Core.Data;
using Microsoft.Diagnostics.Runtime;

namespace MemoScope.Modules.InstancesMixed
{
    public class InstanceInformation : IAddressData, ITypeNameData
    {
        ClrDump ClrDump { get; }
        public ClrType ClrType { get; }

        public InstanceInformation(ClrDump clrDump, ulong address)
        {
            ClrDump = clrDump;
            Address = address;
            ClrType = ClrDump.GetObjectType(Address);
            if (ClrType != null)
            {
                TypeName = ClrType.Name;
            }
        }

        [OLVColumn]
        public ulong Address { get; }

        [OLVColumn(Title = "Name")]
        public string TypeName { get; }
    }
}