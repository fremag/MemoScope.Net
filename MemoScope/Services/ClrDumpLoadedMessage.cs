using MemoScope.Core;
using WinFwk.UIMessages;

namespace MemoScope.Services
{
    public class ClrDumpLoadedMessage : AbstractUIMessage
    {
        public ClrDump ClrDump { get; }

        public ClrDumpLoadedMessage(ClrDump clrDump)
        {
            ClrDump = clrDump;
        }
    }
}
