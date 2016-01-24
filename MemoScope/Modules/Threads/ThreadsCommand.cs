using MemoScope.Core;
using WinFwk.UICommands;
using WinFwk.UIModules;

namespace MemoScope.Modules.Threads
{
    public class ThreadsCommand : AbstractTypedUICommand<ClrDump>
    {
        public ThreadsCommand() : base("Threads", "Display Threads", "Threads", Properties.Resources.processor)
        {

        }

        protected override void HandleData(ClrDump clrDump)
        {
            UIModuleFactory.CreateModule<ThreadsModule>(module => { module.UIModuleParent = selectedModule; module.Setup(clrDump); }, module => DockModule(module));
        }
    }
}
