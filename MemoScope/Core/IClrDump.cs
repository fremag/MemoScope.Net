using System.Collections.Generic;

namespace MemoScope.Core
{
    public interface IClrDump
    {
        IEnumerable<ulong> EnumerateReferers(ulong address);
    }
}