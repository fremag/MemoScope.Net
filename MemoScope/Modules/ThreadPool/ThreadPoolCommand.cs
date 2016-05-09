using MemoScope.Core;
using WinFwk.UICommands;
using WinFwk.UIModules;

namespace MemoScope.Modules.ThreadPool
{
    public class ThreadPoolCommand : AbstractDataUICommand<ClrDump>
    {
        public ThreadPoolCommand() : base("Thread Pool", "Display Thread Pool Information", "Threads", Properties.Resources.candlestickchart)
        {

        }

        protected override void HandleData(ClrDump clrDump)
        {
            UIModuleFactory.CreateModule<ThreadPoolModule>(module => { module.UIModuleParent = selectedModule; module.Setup(clrDump); }, module => DockModule(module));
        }
    }
}
