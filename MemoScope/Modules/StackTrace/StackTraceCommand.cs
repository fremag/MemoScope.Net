using MemoScope.Core.Data;
using System.Windows.Forms;
using WinFwk.UICommands;
using WinFwk.UIModules;

namespace MemoScope.Modules.StackTrace
{
    public class StackTraceCommand : AbstractDataUICommand<ClrDumpThread>
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
                module.Setup(clrDumpThread.ClrDump, clrDumpThread.ClrThread);
                module.Init();
            }, module => DockModule(module));
        }
    }
}
