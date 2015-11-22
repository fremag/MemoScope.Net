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
        private List<ClrTypeStats> typeStats;
        public TypeStatModule()
        {
            InitializeComponent();
            Icon = Properties.Resources.application_view_list;
        }

        public void Setup(ClrDump dump)
        {
            Dump = dump;
            Name = $"#{Dump.Id} - Types";
        }

        public override void  Init()
        {
            Log("Computing type statistics...", WinFwk.UITools.Log.LogLevelType.Info);
            typeStats = Dump.GetTypeStats();
            Summary = $"{typeStats.Count} types";
            Log("Type statistics computed.", WinFwk.UITools.Log.LogLevelType.Info);
        }

        public override void PostInit()
        {
            Generator.GenerateColumns(dlvTypeStats, typeof(ClrTypeStats), false);
            dlvTypeStats.SetObjects(typeStats);
            dlvTypeStats.Sort(dlvTypeStats.AllColumns[2], SortOrder.Descending);
        }
    }
}
