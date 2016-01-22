using MemoScope.Core;
using System.Collections.Generic;
using System.Windows.Forms;
using WinFwk.UICommands;
using WinFwk.UIModules;

namespace MemoScope.Modules.DumpDiff
{
    public class DumpDiffCommand : AbstractTypedUICommand<List<ClrDump>>
    {
        public DumpDiffCommand() : base("Diff", "Compare dumps", "Dump", Properties.Resources.subtotal)
        {

        }

        protected override void HandleData(List<ClrDump> clrDumps)
        {
            if( clrDumps == null || clrDumps.Count < 2)
            {
                MessageBox.Show("Please, select two or more dumps in the workplace module !");
                return;
            }
            UIModuleFactory.CreateModule<DumpDiffModule>(module => { module.Setup(clrDumps); }, module => DockModule(module));
        }
    }
}
