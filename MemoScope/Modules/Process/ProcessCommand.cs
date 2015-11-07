using WinFwk.UICommands;
using WinFwk.UITools.ToolBar;

namespace MemoScope.Modules.Process
{
    public class ProcessCommand : AbstractVoidUICommand
    {
        public ProcessCommand() : base("Process", "Display process", UIToolBarSettings.File.Name, Properties.Resources.ddr_memory)
        {
        }

        public override void Run()
        {
            ProcessModule mod = new ProcessModule();
            mod.Init();
            DockModule(mod);
        }
    }
}