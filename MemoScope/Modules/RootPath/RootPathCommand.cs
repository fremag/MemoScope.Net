using MemoScope.Core.Data;
using System.Windows.Forms;
using WinFwk.UICommands;
using WinFwk.UIModules;

namespace MemoScope.Modules.RootPath
{
    public class RootPathCommand : AbstractDataUICommand<ClrDumpObject>
    {
        public RootPathCommand() : base("RootPath", "Display Shortest Path to a root object", "Analysis", Properties.Resources.molecule, Keys.ControlKey | Keys.Alt | Keys.P)
        {

        }

        protected override void HandleData(ClrDumpObject clrDumpObject)
        {
            if( clrDumpObject == null)
            {
                MessageBox.Show("No object selected !");
                return;
            }
            UIModuleFactory.CreateModule<RootPathModule>(module => { module.UIModuleParent = selectedModule; module.Setup(clrDumpObject); }, module => DockModule(module));
        }
    }
}
