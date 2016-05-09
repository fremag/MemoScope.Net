using MemoScope.Core;
using System.Windows.Forms;
using WinFwk.UICommands;
using WinFwk.UIModules;

namespace MemoScope.Modules.Threads
{
    public class ThreadsCommand : AbstractDataUICommand<ClrDump>
    {
        public ThreadsCommand() : base("Threads", "Display Threads", "Threads", Properties.Resources.processor, Keys.Control|Keys.T)
        {

        }

        protected override void HandleData(ClrDump clrDump)
        {
            UIModuleFactory.CreateModule<ThreadsModule>(module => { module.UIModuleParent = selectedModule; module.Setup(clrDump); }, module => DockModule(module));
        }
    }
}
