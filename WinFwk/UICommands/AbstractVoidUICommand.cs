using System.Drawing;
using WinFwk.UIModules;

namespace WinFwk.UICommands
{
    public abstract class AbstractVoidUICommand : AbstractUICommand
    {
        public UIModule Module { get; private set; }

        protected AbstractVoidUICommand(string name, string toolTip, string @group, Image icon) : base(name, toolTip, @group, icon)
        {
        }

        public override void SetSelectedModule(UIModule module)
        {
            Module = module;
            Enabled = true;
        }
    }
}