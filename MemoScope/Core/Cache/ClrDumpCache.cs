using System.Data.SQLite;

namespace MemoScope.Core.Cache
{
    public class ClrDumpCache
    {
        ClrDump ClrDump { get; }
        SQLiteConnection cxion;
        public ClrDumpCache(ClrDump clrDump)
        {
            ClrDump = clrDump;
        }
    }
}
