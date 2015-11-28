using MemoScope.Core;
using Microsoft.Diagnostics.Runtime;

namespace MemoScope.Modules.TypeDetails
{
    public class ClrDumpType
    {
        public ClrDump ClrDump {get;}
        public ClrType ClrType { get; }
        public ClrDumpType(ClrDump clrDump, ClrType clrType)
        {
            ClrDump = clrDump;
            ClrType = clrType;
        }
    }
}