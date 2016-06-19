using System.Windows.Forms;
using WinFwk.UICommands;
using WinFwk.UIModules;
using WinFwk.UITools.ToolBar;

namespace MemoScope.Modules.Process
{
    public class ProcessCommand : AbstractVoidUICommand
    {
        public ProcessCommand() : base("Dump Process", "Display & Dump process", UIToolBarSettings.Main.Name, Properties.Resources.action_log, Keys.Control|Keys.F2)
        {
        }

        public override void Run()
        {
            UIModuleFactory.CreateModule<ProcessModule>(module => { }, module => DockModule(module));
        }
    }
}