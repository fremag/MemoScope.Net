using MemoScope.Core.Data;
using System;
using System.Windows.Forms;
using WinFwk.UICommands;
using WinFwk.UIModules;

namespace MemoScope.Modules.Delegates.Instances
{
    public class DelegateInstancesCommand : AbstractDataUICommand<ClrDumpType>
    {
        public DelegateInstancesCommand() : base("Delegate Instances", "Display Delegate Instances", "Analysis", Properties.Resources.attributes_display, Keys.Control | Keys.Shift | Keys.I)
        {

        }

        protected override void HandleData(ClrDumpType clrDumpType)
        {
            if( clrDumpType == null || clrDumpType.ClrType == null)
            {
                throw new InvalidOperationException("No type selected !");
            }

            if( ! DelegatesAnalysis.IsDelegateType(clrDumpType))
            {
                throw new InvalidOperationException("Selected type is not a delegate !");
            }

            Display(selectedModule, clrDumpType);
        }

        public static void Display(UIModule parentModule, ClrDumpType clrDumpType)
        {
            UIModuleFactory.CreateModule<DelegateInstancesModule>(module => { module.UIModuleParent = parentModule; module.Setup(clrDumpType); }, module => DockModule(parentModule.MessageBus, module));
        }
    }
}
