using MemoScope.Core.Data;
using MemoScope.Modules.InstanceDetails;
using WinFwk.UICommands;
using WinFwk.UIModules;

namespace MemoScope.Modules.TypeDetails
{
    public class InstanceDetailsCommand :  AbstractTypedUICommand<ClrDumpObject>
    {
        public InstanceDetailsCommand() : base("Instance", "Display instance details", "Dump", Properties.Resources.elements)
        {

        }

        protected override void HandleData(ClrDumpObject data)
        {
            UIModuleFactory.CreateModule<InstanceDetailsModule>(
                mod => { mod.UIModuleParent = selectedModule; mod.Setup(data); },
                mod => DockModule(mod)
             );
        }
    }
}
