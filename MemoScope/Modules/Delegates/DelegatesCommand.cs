using MemoScope.Core;
using System.Windows.Forms;
using WinFwk.UICommands;
using WinFwk.UIModules;

namespace MemoScope.Modules.Delegates
{
    public class DelegatesCommand : AbstractTypedUICommand<ClrDump>
    {
        public DelegatesCommand() : base("Delegates", "Display Delegates", "Analysis", Properties.Resources.macro_show_all_actions, Keys.Control | Keys.Shift | Keys.D)
        {

        }

        protected override void HandleData(ClrDump clrDump)
        {
            UIModuleFactory.CreateModule<DelegateModule>(module => { module.UIModuleParent = selectedModule; module.Setup(clrDump); }, module => DockModule(module));
        }
    }
}
