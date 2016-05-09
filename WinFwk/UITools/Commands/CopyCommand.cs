using System.Windows.Forms;
using WinFwk.UICommands;
using WinFwk.UITools.ToolBar;

namespace WinFwk.UITools.Commands
{
    public class CopyCommand : AbstractDataUICommand<ICopyData>
    {
        public CopyCommand() : base("Copy", "Copy to clipboard", UIToolBarSettings.Main.Name, Properties.Resources.page_copy, Keys.ControlKey | Keys.Shift | Keys.C)
        {

        }

        protected override void HandleData(ICopyData data)
        {
            Clipboard.SetText(data.Data);
        }
    }
}
