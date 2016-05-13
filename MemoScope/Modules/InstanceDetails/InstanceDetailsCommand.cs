using MemoScope.Core.Data;
using MemoScope.Modules.Instances;
using System;
using WeifenLuo.WinFormsUI.Docking;
using WinFwk.UICommands;
using WinFwk.UIModules;

namespace MemoScope.Modules.InstanceDetails
{
    public class InstanceDetailsCommand :  AbstractDataUICommand<ClrDumpObject>
    {
        public InstanceDetailsCommand() : base("Instance", "Display instance details", "Dump", Properties.Resources.elements)
        {

        }

        protected override void HandleData(ClrDumpObject data)
        {
            if( data == null)
            {
                throw new InvalidOperationException("Can't show instance details: nothing selected !");
            }
            Display(selectedModule, data);
        }

        public static void Display(UIModule parentModule, ClrDumpObject data)
        {
            if (data.ClrType.IsArray)
            {
                var elementsAddresses = new ArrayElementsAddressContainer(data);
                var addresses = new AddressList(data.ClrDump, data.ClrType.ComponentType, elementsAddresses);
                string name = $"{data.ClrDump.Id} - Elements: {data.Address:X} [{data.ClrType.ComponentType.Name}]";
                InstancesModule.Create(addresses, parentModule, mod => DockModule(parentModule.MessageBus, mod), name);
            }
            else
            {
                UIModuleFactory.CreateModule<InstanceDetailsModule>(
                    mod => { mod.UIModuleParent = parentModule; mod.Setup(data); },
                    mod => DockModule(parentModule.MessageBus, mod, DockState.DockRight)
                 );
            }
        }
    }
}
