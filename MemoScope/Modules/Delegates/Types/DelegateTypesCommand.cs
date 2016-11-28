using MemoScope.Core;
using System.Windows.Forms;
using WinFwk.UICommands;
using WinFwk.UIModules;

namespace MemoScope.Modules.Delegates.Types
{
    public class DelegatesCommand : AbstractDataUICommand<ClrDump>
    {
        public DelegatesCommand() : base("Delegate Types", "Display Delegate Types (inherinting MultiCastDelegate type)", "Analysis", Properties.Resources.macro_show_all_actions, Keys.Control | Keys.Shift | Keys.D)
        {

        }

        protected override void HandleData(ClrDump clrDump)
        {
            UIModuleFactory.CreateModule<DelegateTypesModule>(module => { module.UIModuleParent = selectedModule; module.Setup(clrDump); }, module => DockModule(module));
        }
    }
}
