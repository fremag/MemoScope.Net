using MemoScope.Core.Data;
using WinFwk.UICommands;
using WinFwk.UIModules;

namespace MemoScope.Modules.Instances
{
    public class InstancesCommand :  AbstractTypedUICommand<AddressList>
    {
        public InstancesCommand() : base("Instances", "Display instances", "Dump", Properties.Resources.scroll_pane_list_large)
        {

        }

        protected override void HandleData(AddressList addresses)
        {
            InstancesModule.Create(addresses, selectedModule, mod => DockModule(mod) );
        }
    }
}
