using Microsoft.Diagnostics.Runtime;

namespace MemoScope.Core.Data
{
    public class ClrDumpThread
    {
        public ClrDumpThread(ClrDump clrDump, ClrThread thread, string name)
        {
            ClrDump = clrDump;
            ClrThread = thread;
            Name = name;
        }

        public ClrDump ClrDump { get; }
        public ClrThread ClrThread { get; }
        public string Name { get; }
    }
}
