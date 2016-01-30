using MemoScope.Core.Data;
using System.Windows.Forms;
using WinFwk.UICommands;
using WinFwk.UIModules;

namespace MemoScope.Modules.Stack
{
    public class StackCommand : AbstractTypedUICommand<ClrDumpThread>
    {
        public StackCommand() : base("Stack", "Display Thread's Stack", "Threads", Properties.Resources.formatting_dublicate_value)
        {

        }

        protected override void HandleData(ClrDumpThread clrDumpThread)
        {
            if( clrDumpThread == null)
            {
                MessageBox.Show("Please, select a thread !");
                return;
            }
            UIModuleFactory.CreateModule<StackModule>(module => {
                module.UIModuleParent = selectedModule;
                module.Setup(clrDumpThread.ClrDump, clrDumpThread.ClrThread);
                module.Init();
            }, module => DockModule(module));
        }
    }
}
