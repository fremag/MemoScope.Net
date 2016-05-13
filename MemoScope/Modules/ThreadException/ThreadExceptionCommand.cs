using MemoScope.Core.Data;
using System;
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
                throw new InvalidOperationException("No thread selected !");
            }

            var ex = clrDumpThread.ClrDump.Eval(() => clrDumpThread.ClrThread.CurrentException);
            if( ex == null)
            {
                throw new InvalidOperationException("No exception for this thread !");
            }

            UIModuleFactory.CreateModule<ThreadExceptionModule>(module => {
                module.UIModuleParent = selectedModule;
                module.Setup(clrDumpThread.ClrDump, clrDumpThread.ClrThread);
                module.Init();
            }, module => DockModule(module));
        }
    }
}
