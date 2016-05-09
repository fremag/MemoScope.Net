using MemoScope.Core.Data;
using WinFwk.UICommands;

namespace MemoScope.Modules.Instances
{
    public class TypeInstancesCommand :  AbstractDataUICommand<ClrDumpType>
    {
        public TypeInstancesCommand() : base("All Instances", "Display all instances from type", "Dump", Properties.Resources.scroll_pane_list)
        {

        }

        protected override void HandleData(ClrDumpType clrDumpType)
        {
            TypeInstancesModule.Create(clrDumpType, selectedModule, mod => DockModule(mod));
        }
    }
}
