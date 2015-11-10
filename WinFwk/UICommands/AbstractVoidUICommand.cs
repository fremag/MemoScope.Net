using System.Drawing;
using System.Windows.Forms;
using WinFwk.UIModules;

namespace WinFwk.UICommands
{
    public abstract class AbstractVoidUICommand : AbstractUICommand
    {
        public UIModule Module { get; private set; }

        protected AbstractVoidUICommand(string name, string toolTip, string @group, Image icon, Keys shortcut=Keys.None) : base(name, toolTip, @group, icon, shortcut)
        {
        }

        public override void SetSelectedModule(UIModule module)
        {
            Module = module;
            Enabled = true;
        }
    }
}