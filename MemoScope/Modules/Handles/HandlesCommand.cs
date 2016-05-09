using MemoScope.Core;
using WinFwk.UICommands;
using WinFwk.UIModules;

namespace MemoScope.Modules.Handles
{
    public class HandlesCommand : AbstractDataUICommand<ClrDump>
    {
        public HandlesCommand() : base("Handles", "Display Handles", "Memory", Properties.Resources.plugin_link)
        {

        }

        protected override void HandleData(ClrDump clrDump)
        {
            UIModuleFactory.CreateModule<HandlesModule>(module => { module.UIModuleParent = selectedModule; module.Setup(clrDump); }, module => DockModule(module));
        }
    }
}
