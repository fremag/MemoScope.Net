using MemoScope.Core;
using System.Windows.Forms;
using WinFwk.UICommands;
using WinFwk.UIModules;

namespace MemoScope.Modules.Disposables
{
    public class DisposablesCommand : AbstractDataUICommand<ClrDump>
    {
        public DisposablesCommand() : base("Disposable Types", "Display Disposable Types (inherinting IDisposable interface)", "Analysis", Properties.Resources.recycle_bag, Keys.Control | Keys.Shift | Keys.B)
        {

        }

        protected override void HandleData(ClrDump clrDump)
        {
            UIModuleFactory.CreateModule<DisposableTypesModule>(module => { module.UIModuleParent = selectedModule; module.Setup(clrDump); }, module => DockModule(module));
        }
    }
}
