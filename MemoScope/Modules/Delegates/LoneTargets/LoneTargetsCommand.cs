using MemoScope.Core;
using System;
using System.Windows.Forms;
using WinFwk.UICommands;
using WinFwk.UIModules;

namespace MemoScope.Modules.Delegates.LoneHandlers
{
    public class LoneTargetsCommand : AbstractDataUICommand<ClrDump>
    {
        public LoneTargetsCommand() : base("Lone Targets", "Display Instances Referenced Only By A Delegate", "Analysis", Properties.Resources.lightning, Keys.Control | Keys.Shift | Keys.L)
        {

        }

        protected override void HandleData(ClrDump clrDump)
        {
            if( clrDump == null )
            {
                throw new InvalidOperationException("No dump selected !");
            }

            Display(selectedModule, clrDump);
        }

        public static void Display(UIModule parentModule, ClrDump clrDump)
        {
            UIModuleFactory.CreateModule<LoneTargetsModule>(module => { module.UIModuleParent = parentModule; module.Setup(clrDump); }, module => DockModule(parentModule.MessageBus, module));
        }
    }
}
