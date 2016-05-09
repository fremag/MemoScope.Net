using MemoScope.Core;
using WinFwk.UICommands;
using WinFwk.UIModules;

namespace MemoScope.Modules.Finalizer
{
    public class FinalizerCommand : AbstractDataUICommand<ClrDump>
    {
        public FinalizerCommand() : base("Finalizer", "Display Finalizer Queue", "Memory", Properties.Resources.broom)
        {

        }

        protected override void HandleData(ClrDump clrDump)
        {
            UIModuleFactory.CreateModule<FinalizerModule>(module => { module.UIModuleParent = selectedModule; module.Setup(clrDump); }, module => DockModule(module));
        }
    }
}
