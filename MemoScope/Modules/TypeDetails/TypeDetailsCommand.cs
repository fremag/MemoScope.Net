using MemoScope.Core.Data;
using System.Windows.Forms;
using WinFwk.UICommands;
using WinFwk.UIModules;

namespace MemoScope.Modules.TypeDetails
{
    public class TypeDetailsCommand :  AbstractDataUICommand<ClrDumpType>
    {
        public TypeDetailsCommand() : base("Type", "Display type details", "Dump", Properties.Resources.blueprint_large)
        {

        }

        protected override void HandleData(ClrDumpType data)
        {
            if( data == null)
            {
                MessageBox.Show("Type Details: no type selected !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UIModuleFactory.CreateModule<TypeDetailsModule>(
                mod => { mod.UIModuleParent = selectedModule; mod.Setup(data); },
                mod => DockModule(mod)
                );
        }
    }
}
