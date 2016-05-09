using MemoScope.Core;
using WinFwk.UICommands;
using WinFwk.UIModules;

namespace MemoScope.Modules.Modules
{
    public class ModulesCommand : AbstractDataUICommand<ClrDump>
    {
        public ModulesCommand() : base("Modules", "Display memory Modules", "Memory", Properties.Resources.module)
        {

        }

        protected override void HandleData(ClrDump clrDump)
        {
            UIModuleFactory.CreateModule<ModulesModule>(module => { module.UIModuleParent = selectedModule; module.Setup(clrDump); }, module => DockModule(module));
        }
    }
}
