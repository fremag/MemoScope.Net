using System.Collections.Generic;

namespace MemoScope.Core
{
    public interface IClrDump
    {
        bool HasReferers(ulong address);
        IEnumerable<ulong> EnumerateReferers(ulong address);
    }
}