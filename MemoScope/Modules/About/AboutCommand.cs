using System.Windows.Forms;
using WinFwk.UICommands;
using WinFwk.UIModules;
using WinFwk.UITools.ToolBar;

namespace MemoScope.Modules.About
{
    public class AboutCommand : AbstractVoidUICommand
    {
        public AboutCommand() : base("About", "About the application", UIToolBarSettings.Help.Name, Properties.Resources.help, Keys.Control|Keys.F1)
        {
        }

        public override void Run()
        {
            UIModuleFactory.CreateModule<AboutModule>(tsm => { }, tsm => DockModule(tsm));
        }
    }
}
