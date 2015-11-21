using System.Collections.Generic;
using System.Windows.Forms;
using BrightIdeasSoftware;
using MemoScope.Core;
using WinFwk.UIModules;

namespace MemoScope.Modules.TypeStats
{
    public partial class TypeStatModule : UIModule
    {
        protected ClrDump Dump { get; set; }

        public TypeStatModule()
        {
            InitializeComponent();
        }

        public void Init(ClrDump dump)
        {
            Dump = dump;
            Name = $"#{Dump.Id} - Types";
            List<ClrTypeStats> typeStats = dump.GetTypeStats();
            Summary = $"{typeStats.Count} types";

            Generator.GenerateColumns(dlvTypeStats, typeof(ClrTypeStats), false);
            dlvTypeStats.SetObjects(typeStats);
            dlvTypeStats.Sort(dlvTypeStats.AllColumns[2], SortOrder.Descending);
        }
    }
}
