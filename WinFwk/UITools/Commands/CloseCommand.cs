using System;
using System.Windows.Forms;
using WinFwk.UICommands;
using WinFwk.UIModules;
using WinFwk.UITools.ToolBar;

namespace WinFwk.UITools.Commands
{
    public class CloseCommand : AbstractVoidUICommand
    {
        public CloseCommand() : base("Close", "Close selected module", UIToolBarSettings.Main.Name, Properties.Resources.cross, Keys.Control | Keys.Shift | Keys.W)
        {

        }

        public override void Run()
        {
            if (selectedModule == null)
            {
                throw new InvalidOperationException("No module selected !");
            }

            MessageBus.SendMessage(new CloseRequest(selectedModule));
        }
    }
}
