using BrightIdeasSoftware;
using MemoScope.Core;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Diagnostics.Runtime;

namespace MemoScope.Modules.InstanceDetails
{
    public class ReferenceInformation 
    {
        ClrDump ClrDump { get; }

        [OLVColumn(Title="Address")]
        public ulong Address { get; }

        [OLVColumn(Title = "Type")]
        public string TypeName => ClrDump.GetObjectTypeName(Address);

        public ClrType ClrType => ClrDump.GetObjectType(Address);

        public ReferenceInformation(ClrDump dump, ulong address) 
        {
            ClrDump = dump;
            Address = address;
        }

        public bool HasChildren => ClrDump.HasReferences(Address);
        public List<ReferenceInformation> Children => ClrDump.GetReferences(Address).Select(address => new ReferenceInformation(ClrDump, address)).ToList();

    }
}