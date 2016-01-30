using MemoScope.Core;
using Microsoft.Diagnostics.Runtime;
using System.Windows.Forms;
using WinFwk.UICommands;
using WinFwk.UIModules;

namespace MemoScope.Modules.StackTrace
{
    public class StackTraceCommand : AbstractTypedUICommand<ClrDumpThread>
    {
        public StackTraceCommand() : base("Stack Trace", "Display Thread's Stack Trace", "Threads", Properties.Resources.red_line)
        {

        }

        protected override void HandleData(ClrDumpThread clrDumpThread)
        {
            if( clrDumpThread == null)
            {
                MessageBox.Show("Please, select a thread !");
                return;
            }
            UIModuleFactory.CreateModule<StackTraceModule>(module => {
                module.UIModuleParent = selectedModule;
                module.Setup(clrDumpThread.ClrDump);
                module.Init(clrDumpThread.ClrThread);
            }, module => DockModule(module));
        }
    }
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
