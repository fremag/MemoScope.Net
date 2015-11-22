using WinFwk.UICommands;
using WinFwk.UIModules;

namespace WinFwk.UITools.Settings
{
    public class UISettingsCommand : AbstractVoidUICommand
    {
        public UISettingsCommand() : base("Settings", "Edit settings", "File", Properties.Resources.gear_in)
        {
        }

        public override void Run()
        {
            UIModuleFactory.CreateModule<UISettingsModule>(module => { }, module => DockModule(module));
        }
    }
}