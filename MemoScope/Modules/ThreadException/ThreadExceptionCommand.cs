using MemoScope.Core.Data;
using System.Windows.Forms;
using WinFwk.UICommands;
using WinFwk.UIModules;

namespace MemoScope.Modules.ThreadException
{
    public class ThreadExceptionCommand : AbstractDataUICommand<ClrDumpThread>
    {
        public ThreadExceptionCommand() : base("Exception", "Display Thread's Exception", "Threads", Properties.Resources.exclamation)
        {

        }

        protected override void HandleData(ClrDumpThread clrDumpThread)
        {
            if( clrDumpThread == null)
            {
                MessageBox.Show("Please, select a thread !");
                return;
            }
            var ex = clrDumpThread.ClrDump.Eval(() => clrDumpThread.ClrThread.CurrentException);
            if( ex == null)
            {
                MessageBox.Show("No exception for this thread !");
                return;
            }
            UIModuleFactory.CreateModule<ThreadExceptionModule>(module => {
                module.UIModuleParent = selectedModule;
                module.Setup(clrDumpThread.ClrDump, clrDumpThread.ClrThread);
                module.Init();
            }, module => DockModule(module));
        }
    }
}
