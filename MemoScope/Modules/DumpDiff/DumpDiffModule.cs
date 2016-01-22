using MemoScope.Core;
using MemoScope.Core.Helpers;
using System.Collections.Generic;
using WinFwk.UIModules;
using BrightIdeasSoftware;
using System.Drawing;
using System;
using MemoScope.Core.Data;
using MemoScope.Modules.Instances;

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
            dlvDumpDiff.SetUpTypeColumn(colType);
            colType.Text = "Type";
            colType.AspectGetter = o => (string)o;
            ClrDump prevClrDump = null;
            for(int i=0; i< ClrDumps.Count; i++)
            {
                var clrDump = ClrDumps[i];
                var stats = clrDump.GetTypeStats();
                DiffColumn diffCol = new DiffColumn(clrDump, stats, prevClrDump?.GetTypeStats());
                dlvDumpDiff.AllColumns.Add(diffCol);
                prevClrDump = clrDump;
                dlvDumpDiff.RegisterDataProvider(() => SelectedTypeInstancesAddressList(clrDump), this, $"#{clrDump.Id}");
            }
            dlvDumpDiff.RebuildColumns();
            dlvDumpDiff.UseCellFormatEvents = true;
            dlvDumpDiff.FormatCell += OnFormatCell;
            dlvDumpDiff.CellClick += OnCellClick;

            regexFilterControl.RegexApplied += (regex) => {
                dlvDumpDiff.ModelFilter = new ModelFilter((o) =>
                {
                    var typeName = o as string;
                    if (o == null)
                    {
                        return true;
                    }
                    var b = regex.IsMatch(typeName);
                    return b;
                });
                dlvDumpDiff.UseFiltering = true;
            };
            regexFilterControl.RegexCancelled += () => dlvDumpDiff.UseFiltering = false;

        }

        private void OnCellClick(object sender, CellClickEventArgs e)
        {
            if(e.ClickCount != 2)
            {
                return;
            }
            var col = e.Column as DiffColumn;
            if( col == null)
            {
                return;
            }
            var clrDumpType = SelectedTypeInstancesAddressList(col.ClrDump);
            var addresses = new TypeInstancesAddressList(clrDumpType);
            InstancesModule.Create(addresses, this, mod => RequestDockModule(mod));
        }

        private ClrDumpType SelectedTypeInstancesAddressList(ClrDump clrDump)
        {
            var selectedType = dlvDumpDiff.SelectedObject<string>();
            return new ClrDumpType(clrDump, selectedType);
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
                    typeNames.Add(stat.Type.Name);
                }
            }
        }

        public override void PostInit()
        {
            base.PostInit();
            Summary = $"{ClrDumps.Count} dumps, {typeNames.Count} types";

            dlvDumpDiff.Objects = typeNames;
            dlvDumpDiff.Sort(colType);
        }
    }
}
