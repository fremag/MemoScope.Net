using MemoScope.Core.Data;

namespace MemoScope.Modules.Arrays
{
    public class ArraysAddressList : AddressList
    {
        public ArraysAddressList(ClrDumpType clrDumpType) : base(clrDumpType.ClrDump, clrDumpType.ClrType, clrDumpType.Instances)
        {

        }
    }
}