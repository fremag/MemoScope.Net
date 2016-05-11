using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFwk.UICommands;
using WinFwk.UIModules;
using WinFwk.UITools.ToolBar;

namespace WinFwk.UITools.Commands
{
    public class CopyCommand : AbstractTypedUICommand<IDataExportable>
    {
        public CopyCommand() : base("Copy", "Copy to clipboard", UIToolBarSettings.Main.Name, Properties.Resources.page_copy, Keys.ControlKey | Keys.Shift | Keys.C)
        {

        }

        const int MAX_SIZE = 32 * 1024 * 1024;

        public override void HandleAction(IDataExportable module)
        {

            Task.Run(() => CopyData(module));
        }

        private void CopyData(IDataExportable module)
        {
            CancellationTokenSource token = new CancellationTokenSource();
            MessageBus.BeginTask("Start copy...", token);
            List<string> lines = new List<string>();
            int size = 0;
            foreach (var line in module.ExportableData())
            {
                if( token.IsCancellationRequested)
                {
                    MessageBus.EndTask("Copy cancelled");
                    return;
                }
                lines.Add(line);
                if(lines.Count % 1024 == 0)
                {
                    MessageBus.Status($"Copying: row #{lines.Count:###,###,###,###} (size: {size/1024:###,###,###,###} ko) ...");
                }
                size += line.Length;
                if (size > MAX_SIZE)
                {
                    lines.Add(">>>> Max Size reached !");
                    break;
                }
            }
            string s = string.Join(Environment.NewLine, lines);
            if (string.IsNullOrEmpty(s))
            {
                s = string.Empty;
            }
            new TaskFactory(MessageBus.UiScheduler).StartNew(() => Clipboard.SetText(s));
            MessageBus.EndTask($"Copy done. {lines.Count:###,###,###,###} rows.");
        }
    }
}
