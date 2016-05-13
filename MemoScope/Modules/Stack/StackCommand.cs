using MemoScope.Core.Data;
using System;
using WinFwk.UICommands;
using WinFwk.UIModules;

namespace MemoScope.Modules.Stack
{
    public class StackCommand : AbstractDataUICommand<ClrDumpThread>
    {
        public StackCommand() : base("Stack", "Display Thread's Stack", "Threads", Properties.Resources.formatting_dublicate_value)
        {

        }

        protected override void HandleData(ClrDumpThread clrDumpThread)
        {
            if( clrDumpThread == null)
            {
                throw new InvalidOperationException("No thread selected !");
            }

            UIModuleFactory.CreateModule<StackModule>(module => {
                module.UIModuleParent = selectedModule;
                module.Setup(clrDumpThread.ClrDump, clrDumpThread.ClrThread);
                module.Init();
            }, module => DockModule(module));
        }
    }
}
