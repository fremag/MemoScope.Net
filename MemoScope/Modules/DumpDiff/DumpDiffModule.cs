using MemoScope.Core;
using MemoScope.Core.Helpers;
using System.Collections.Generic;
using WinFwk.UIModules;

namespace MemoScope.Modules.DumpDiff
{
    public partial class DumpDiffModule : UIModule
    {
        private List<ClrDump> ClrDumps { get; set; }
        public DumpDiffModule()
        {
            InitializeComponent();
        }

        public void Setup(List<ClrDump> clrDumps)
        {
            ClrDumps = clrDumps;
            Icon = Properties.Resources.subtotal_small;
            Name = $"Dump diff";
            dlvTypes.SetUpTypeColumn(colType);
            colType.Text = "Type";
            colType.AspectGetter = o => (string)o;
            ClrDump prevClrDump = null;
            for(int i=0; i< ClrDumps.Count; i++)
            {
                var clrDump = ClrDumps[i];
                var stats = clrDump.GetTypeStats();
                DiffColumn diffCol = new DiffColumn(clrDump, stats, prevClrDump?.GetTypeStats());
                dlvTypes.AllColumns.Add(diffCol);
                prevClrDump = clrDump;
            }
            dlvTypes.RebuildColumns();
        }
        HashSet<string> typeNames = new HashSet<string>();
        public override void Init()
        {
            foreach (var clrDump in ClrDumps)
            {
                var stats = clrDump.GetTypeStats();
                foreach (var stat in stats)
                {
                    typeNames.Add(stat.TypeName);
                }
            }
        }

        public override void PostInit()
        {
            base.PostInit();
            Summary = $"{ClrDumps.Count} dumps, {typeNames.Count} types";

            dlvTypes.Objects = typeNames;
            dlvTypes.Sort(colType);
        }
    }
}
