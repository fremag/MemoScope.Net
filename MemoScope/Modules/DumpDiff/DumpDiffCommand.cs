using MemoScope.Core;
using System;
using System.Collections.Generic;
using WinFwk.UICommands;
using WinFwk.UIModules;

namespace MemoScope.Modules.DumpDiff
{
    public class DumpDiffCommand : AbstractDataUICommand<List<ClrDump>>
    {
        public DumpDiffCommand() : base("Diff", "Compare dumps", "Dump", Properties.Resources.subtotal)
        {

        }

        protected override void HandleData(List<ClrDump> clrDumps)
        {
            if( clrDumps == null || clrDumps.Count < 2)
            {
                throw new InvalidOperationException("Please, select two or more dumps in the workplace module !");
            }
            UIModuleFactory.CreateModule<DumpDiffModule>(module => { module.Setup(clrDumps); }, module => DockModule(module));
        }
    }
}
