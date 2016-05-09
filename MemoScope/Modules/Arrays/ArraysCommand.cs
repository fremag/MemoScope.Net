using MemoScope.Core;
using WinFwk.UICommands;
using WinFwk.UIModules;

namespace MemoScope.Modules.Arrays
{
    public class ArraysCommand : AbstractDataUICommand<ClrDump>
    {
        public ArraysCommand() : base("Arrays", "Display Arrays", "Analysis", Properties.Resources.recommended_summart_table)
        {

        }

        protected override void HandleData(ClrDump clrDump)
        {
            UIModuleFactory.CreateModule<ArraysModule>(module => { module.UIModuleParent = selectedModule; module.Setup(clrDump); }, module => DockModule(module));
        }
    }
}
