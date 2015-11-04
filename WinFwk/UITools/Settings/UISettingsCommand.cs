using WinFwk.UICommands;

namespace WinFwk.UITools.Settings
{
    public class UISettingsCommand : AbstractVoidUICommand
    {
        public UISettingsCommand() : base("Settings", "Edit settings", "File", Properties.Resources.gear_in)
        {
        }

        public override void Run()
        {
            DockModule(new UISettingsModule());
        }
    }
}