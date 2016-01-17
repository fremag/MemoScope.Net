using System.Collections.Generic;
using System.Windows.Forms;
using BrightIdeasSoftware;
using MemoScope.Core;
using WinFwk.UICommands;
using MemoScope.Core.Helpers;
using MemoScope.Core.Data;
using MemoScope.Modules.Instances;

namespace MemoScope.Modules.TypeStats
{
    public partial class TypeStatModule : UIClrDumpModule, UIDataProvider<ClrDumpType>, UIDataProvider<AddressList>
    {
        private List<ClrTypeStats> typeStats;
        public TypeStatModule()
        {
            InitializeComponent();
            Icon = Properties.Resources.application_view_list;
        }

        public void Setup(ClrDump clrDump)
        {
            ClrDump = clrDump;
            Name = $"#{ClrDump.Id} - "+clrDump.DumpPath;
            tbDumpPath.Text = clrDump.DumpPath;
        }

        public override void  Init()
        {
            Log("Computing type statistics...", WinFwk.UITools.Log.LogLevelType.Info);
            typeStats = ClrDump.GetTypeStats();
            Summary = $"{typeStats.Count} types";
            Log("Type statistics computed.", WinFwk.UITools.Log.LogLevelType.Info);
        }

        public override void PostInit()
        {
            dlvTypeStats.InitColumns<ClrTypeStats>();
            dlvTypeStats.SetUpTypeColumn<ClrTypeStats>(this);
            dlvTypeStats.SetObjects(typeStats);
            dlvTypeStats.Sort(dlvTypeStats.AllColumns[2], SortOrder.Descending);
            dlvTypeStats.UseFilterIndicator = true;

            regexFilterControl.RegexApplied += (regex) => {
                dlvTypeStats.ModelFilter = new ModelFilter((o) =>
                {
                    var stat = o as ClrTypeStats;
                    if( o == null)
                    {
                        return true;
                    }
                    var b = regex.IsMatch(stat.TypeName);
                    return b;
                });
                dlvTypeStats.UseFiltering = true;
            };
            regexFilterControl.RegexCancelled += () => dlvTypeStats.UseFiltering = false;
        }

        ClrDumpType UIDataProvider<ClrDumpType>.Data
        {
            get
            {
                var obj = dlvTypeStats.SelectedObject as ClrTypeStats;
                if (obj != null)
                {
                    return new ClrDumpType(ClrDump, obj.Type);
                }
                return null;
            }
        }

        AddressList UIDataProvider<AddressList>.Data
        {
            get
            {
                var obj = dlvTypeStats.SelectedObject as ClrTypeStats;
                if (obj != null)
                {
                    return new AddressList(ClrDump, obj.Type);
                }
                return null;
            }
        }

        private void dlvTypeStats_CellClick(object sender, CellClickEventArgs e)
        {
            if( e.ClickCount != 2)
            {
                return;
            }
            var addresses = ((UIDataProvider<AddressList>)this).Data;
            if( addresses != null)
            {
                InstancesModule.Create(addresses, this, mod => RequestDockModule(mod));
            }
        }
    }
}
