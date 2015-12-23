using MemoScope.Core;
using Microsoft.Diagnostics.Runtime;

namespace MemoScope.Modules.InstanceDetails
{
    public class ClrDumpObject
    {
        public ClrDump Dump { get; }
        public ClrType Type { get; }
        public ulong Address { get; }

        public ClrDumpObject(ClrDump dump, ClrType type, ulong address)
        {
            Dump = dump;
            Type = type;
            Address = address;
        }
    }
}
