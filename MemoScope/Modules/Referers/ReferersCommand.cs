using MemoScope.Core.Data;
using System.Windows.Forms;
using WinFwk.UICommands;
using WinFwk.UIModules;

namespace MemoScope.Modules.Referers
{
    public class ReferersCommand : AbstractDataUICommand<AddressList>
    {
        public ReferersCommand() : base("Referers", "Display Referers", "Analysis", Properties.Resources.chart_organisation, Keys.ControlKey | Keys.Alt | Keys.R)
        {

        }

        protected override void HandleData(AddressList addressList)
        {
            if( addressList == null)
            {
                MessageBox.Show("No instances selected !");
                return;
            }
            UIModuleFactory.CreateModule<ReferersModule>(module => { module.UIModuleParent = selectedModule; module.Setup(addressList); }, module => DockModule(module));
        }
    }
}
