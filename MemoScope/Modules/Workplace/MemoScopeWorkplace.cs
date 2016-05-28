using MemoScope.Core;
using System.Collections.Generic;
using WinFwk.UICommands;
using WinFwk.UITools.Workplace;
using System.Linq;

namespace MemoScope.Modules.Workplace
{
    public class MemoScopeWorkplace : WorkplaceModule, UIDataProvider<List<ClrDump>>
    {
        public List<ClrDump> Data
        {
            get
            {
                var modules = SelectedModules;
                return modules.OfType<UIClrDumpModule>().Select(mod => mod.ClrDump).ToList();
            }
        }
    }
}
