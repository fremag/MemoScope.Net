using BrightIdeasSoftware;
using MemoScope.Core;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Diagnostics.Runtime;
using WinFwk.UITools;
using MemoScope.Core.Data;
using MemoScope.Core.Helpers;

namespace MemoScope.Modules.InstanceDetails
{
    public class ReferenceInformation : TreeNodeInformationAdapter<ReferenceInformation>, IAddressData, ITypeNameData
    {
        ClrDump ClrDump { get; }

        [OLVColumn(Title = "Address")]
        public ulong Address { get; }

        [OLVColumn]
        public string FieldName { get; }

        [OLVColumn(Title = "Type")]
        public string TypeName => ClrDump.GetObjectTypeName(Address);

        public ClrType ClrType => ClrDump.GetObjectType(Address);

        public ReferenceInformation(ClrDump clrDump, ulong address, ulong refAddress) : this(clrDump, address)
        {
            FieldName = ClrDump.GetFieldNameReference(refAddress, address);
            FieldName = TypeHelpers.RealName(FieldName);
       }

        public ReferenceInformation(ClrDump clrDump, ulong address)
        {
            ClrDump = clrDump;
            Address = address;
        }

        public override bool CanExpand => ClrDump.HasReferers(Address);
        public override List<ReferenceInformation> Children => ClrDump.GetReferers(Address).Select(address => new ReferenceInformation(ClrDump, address, Address)).ToList();
    }
}
