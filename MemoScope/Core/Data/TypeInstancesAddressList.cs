using Microsoft.Diagnostics.Runtime;

namespace MemoScope.Core.Data
{
    public class TypeInstancesAddressList : AddressList
    {
        public TypeInstancesAddressList(ClrDumpType clrDumpType) : this(clrDumpType.ClrDump, clrDumpType.ClrType)
        {

        }

        public TypeInstancesAddressList(ClrDump clrDump, ClrType clrType) : base(clrDump, clrType, clrDump.GetInstances(clrType))
        {
        }
        public TypeInstancesAddressList(ClrDump clrDump, string typeName) : this(clrDump, clrDump.GetClrType(typeName))
        {
        }
    }
}