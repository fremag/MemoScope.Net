using MemoScope.Core;
using MemoScope.Core.Helpers;
using System.Collections.Generic;
using WinFwk.UIModules;
using BrightIdeasSoftware;
using System.Drawing;

namespace MemoScope.Modules.DumpDiff
{
    public partial class DumpDiffModule : UIModule
    {
        private List<ClrDump> ClrDumps { get; set; }
        HashSet<string> typeNames = new HashSet<string>();

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
            dlvTypes.UseCellFormatEvents = true;
            dlvTypes.FormatCell += OnFormatCell;
        }

        private void OnFormatCell(object sender, FormatCellEventArgs e)
        {
            if (e.Column == colType || e.ColumnIndex <= 1 || e.CellValue == null || ! (e.CellValue is long))
            {
                return;
            }

            var value = (long)e.CellValue;
            if (value > 0)
            {
                e.SubItem.BackColor = Color.LightGreen;
            }
            else if (value < 0)
            {
                e.SubItem.BackColor = Color.LightPink;
            }
            else
            {
                e.SubItem.BackColor = Color.LightGray;
            }
        }

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
