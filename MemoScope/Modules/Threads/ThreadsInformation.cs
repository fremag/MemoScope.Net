using MemoScope.Core;
using Microsoft.Diagnostics.Runtime;
using MemoScope.Core.Data;
using BrightIdeasSoftware;
using System.Windows.Forms;

namespace MemoScope.Modules.Threads
{
    public class ThreadInformation
    {
        private ClrDump clrDump;
        private ClrThread thread;

        public ThreadInformation(ClrDump clrDump, ClrThread thread)
        {
            this.clrDump = clrDump;
            this.thread = thread;
        }

        [OLVColumn(TextAlign = HorizontalAlignment.Right)]
        public uint OSThreadId => thread.OSThreadId;

    }
}