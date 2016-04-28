using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using WinFwk.UICommands;
using WinFwk.UIModules;
using WinFwk.UITools.ToolBar;

namespace MemoScope.Modules.Explorer
{
    public class ExplorerCommand : AbstractVoidUICommand
    {
        public ExplorerCommand() : base("Explorer", "Display explorer", UIToolBarSettings.Main.Name, Properties.Resources.folders_explorer, Keys.Control|Keys.Shift|Keys.E)
        {
        }

        public override void Run()
        {
            UIModuleFactory.CreateModule<ExplorerModule>(module => { }, module => DockModule(module, DockState.DockLeft));
        }
    }
}