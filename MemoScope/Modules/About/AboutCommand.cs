using WinFwk.UICommands;
using WinFwk.UITools.ToolBar;

namespace MemoScope.Modules.About
{
    public class AboutCommand : AbstractVoidUICommand
    {
        public AboutCommand() : base("About", "About the application", UIToolBarSettings.Help.Name, Properties.Resources.help)
        {
        }

        public override void Run()
        {
            AboutModule mod = new AboutModule();
            DockModule(mod);
        }
    }
}
