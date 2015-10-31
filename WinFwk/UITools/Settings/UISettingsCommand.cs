using WinFwk.UICommands;
using WinFwk.UIModules;

namespace WinFwk.UITools.Settings
{
    public class UISettingsCommand : AbstractVoidUICommand
    {
        public UISettingsCommand() : base("settings", "Edit settings", "File", Properties.Resources.gear_in)
        {
        }

        public override void Run()
        {
            MessageBus.SendMessage(new DockRequest(new UISettingsModule()));
        }
    }
}