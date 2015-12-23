using Microsoft.Diagnostics.Runtime;

namespace MemoScope.Core.Data
{
    public class ClrDumpObject : ClrDumpType
    {
        public ulong Address { get; }

        public ClrDumpObject(ClrDump dump, ClrType type, ulong address) : base(dump, type)
        {
            Address = address;
        }
    }
}
