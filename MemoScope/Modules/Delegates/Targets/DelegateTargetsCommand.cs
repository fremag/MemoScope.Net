using MemoScope.Core.Data;
using System;
using System.Windows.Forms;
using WinFwk.UICommands;
using WinFwk.UIModules;

namespace MemoScope.Modules.Delegates.Targets
{
    public class DelegateTargetsCommand : AbstractDataUICommand<ClrDumpObject>
    {
        public DelegateTargetsCommand() : base("Delegate Target", "Display Delegate Targets / Invocation list", "Analysis", Properties.Resources.table_lightning, Keys.Control | Keys.Shift | Keys.T)
        {

        }

        protected override void HandleData(ClrDumpObject clrDumpObject)
        {
            if(clrDumpObject == null || clrDumpObject.ClrType == null)
            {
                throw new InvalidOperationException("No instance selected !");
            }

            if( ! DelegatesAnalysis.IsDelegateType(clrDumpObject))
            {
                throw new InvalidOperationException("Selected instance's type is not a delegate !");
            }

            Display(selectedModule, clrDumpObject);
        }

        public static void Display(UIModule parentModule, ClrDumpObject clrDumpObject)
        {
            UIModuleFactory.CreateModule<DelegateTargetsModule>(module => { module.UIModuleParent = parentModule; module.Setup(clrDumpObject); }, module => DockModule(parentModule.MessageBus, module));
        }
    }
}
