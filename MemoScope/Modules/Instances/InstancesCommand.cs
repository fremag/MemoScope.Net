using MemoScope.Core.Data;
using WinFwk.UICommands;

namespace MemoScope.Modules.Instances
{
    public class InstancesCommand :  AbstractDataUICommand<AddressList>
    {
        public InstancesCommand() : base("Instances", "Display instances", "Dump", Properties.Resources.legend)
        {

        }

        protected override void HandleData(AddressList addresses)
        {
            InstancesModule.Create(addresses, selectedModule, mod => DockModule(mod) );
        }
    }
}
