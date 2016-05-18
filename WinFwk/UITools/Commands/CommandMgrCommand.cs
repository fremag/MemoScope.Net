using WinFwk.UICommands;
using WinFwk.UIModules;
using WinFwk.UITools.ToolBar;

namespace WinFwk.UITools.Commands
{
    public class CommandMgrCommand : AbstractVoidUICommand
    {

        public CommandMgrCommand() : base("Commands", "Open commands manager", UIToolBarSettings.Main.Name, Properties.Resources.update_contact_info)
        {

        }
        public override void Run()
        {
            UIModuleFactory.CreateModule<CommandMgrModule>(module => { }, module => DockModule(module));
        }
    }
}
