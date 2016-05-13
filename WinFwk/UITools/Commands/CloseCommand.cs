using System;
using System.Windows.Forms;
using WinFwk.UICommands;
using WinFwk.UIModules;
using WinFwk.UITools.ToolBar;

namespace WinFwk.UITools.Commands
{
    public class CloseCommand : AbstractVoidUICommand
    {
        public CloseCommand() : base("Close", "Close selected module", UIToolBarSettings.Main.Name, Properties.Resources.cross, Keys.ControlKey | Keys.Shift | Keys.W)
        {

        }

        public override void Run()
        {
            if (Module == null)
            {
                MessageBox.Show("No module selected !");
                return;
            }

            MessageBus.SendMessage(new CloseRequest(Module));
        }
    }
}
