using MemoScope.Core.Data;
using WinFwk.UICommands;

namespace MemoScope.Modules.Instances
{
    public class TypeInstancesCommand :  AbstractTypedUICommand<ClrDumpType>
    {
        public TypeInstancesCommand() : base("All Instances", "Display all instances from type", "Dump", Properties.Resources.scroll_pane_list)
        {

        }

        protected override void HandleData(ClrDumpType clrDumpType)
        {
            var addresses = new TypeInstancesAddressList(clrDumpType);
            InstancesModule.Create(addresses, selectedModule, mod => DockModule(mod) );
        }
    }
}
