using System;
using System.Windows.Forms;
using WinFwk.UICommands;
using WinFwk.UITools.ToolBar;

namespace WinFwk.UITools.Commands
{
    public class GCCommand : AbstractVoidUICommand
    {
        public GCCommand() : base("GC", "Garbage collect", UIToolBarSettings.Main.Name, Properties.Resources.cross, Keys.Control | Keys.Shift | Keys.G)
        {

        }

        public override void Run()
        {
            System.GC.Collect(2, GCCollectionMode.Forced, true);
        }
    }
}
