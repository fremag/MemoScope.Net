using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFwk.UICommands;
using WinFwk.UIModules;
using WinFwk.UITools.ToolBar;

namespace WinFwk.UITools.Commands
{
    public class ExportCommand : AbstractTypedUICommand<IDataExportable>
    {
        public ExportCommand() : base("Export", "Export data to file", UIToolBarSettings.Main.Name, Properties.Resources.text_exports, Keys.ControlKey | Keys.Shift | Keys.E)
        {

        }

        public override void HandleAction(IDataExportable module)
        {
            SaveFileDialog sdf = new SaveFileDialog() { DefaultExt="csv"};
            if(sdf.ShowDialog() == DialogResult.OK)
            {
                Task.Run(() => ExportData(sdf.FileName, module));
            }
        }

        private void ExportData(string fileName, IDataExportable module)
        {
            CancellationTokenSource token = new CancellationTokenSource();
            MessageBus.BeginTask("Start export...", token);
            int size = 0;
            int count = 0;
            using (var writer = new StreamWriter(fileName))
            {
                foreach (var line in module.ExportableData())
                {
                    if (token.IsCancellationRequested)
                    {
                        MessageBus.EndTask("Export cancelled.");
                        return;
                    }
                    if (count++ % 1024 == 0)
                    {
                        MessageBus.Status($"Exporting: row #{count:###,###,###,###} (size: {size / 1024:###,###,###,###} ko) ...");
                    }
                    size += line.Length;
                    writer.WriteLine(line);
                }
            }
            MessageBus.EndTask($"Export done. {count:###,###,###,###} rows.");
        }
    }
}
