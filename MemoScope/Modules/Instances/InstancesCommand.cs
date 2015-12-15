using MemoScope.Core.Data;
using MemoScope.Modules.TypeStats;
using System.Collections.Generic;
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
            UIModuleFactory.CreateModule<InstancesModule>(
                mod => { mod.UIModuleParent = selectedModule; mod.Setup(addresses); },
                mod => DockModule(mod)
                );
        }
    }
}
