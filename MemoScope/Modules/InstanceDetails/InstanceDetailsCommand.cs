using MemoScope.Core.Data;
using MemoScope.Modules.InstanceDetails;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
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
            if( data == null)
            {
                MessageBox.Show("Can't show instance details: nothing selected !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UIModuleFactory.CreateModule<InstanceDetailsModule>(
                mod => { mod.UIModuleParent = selectedModule; mod.Setup(data); },
                mod => DockModule(mod, DockState.DockRight)
             );
        }
    }
}
