using System.Collections.Generic;
using System.Windows.Forms;
using BrightIdeasSoftware;
using MemoScope.Core;
using WinFwk.UICommands;
using MemoScope.Core.Helpers;
using MemoScope.Core.Data;
using MemoScope.Modules.Instances;
using NLog;
using System.Reflection;
using MemoScope.Modules.Arrays;
using System;

namespace MemoScope.Modules.TypeStats
{
    public partial class TypeStatModule : UIClrDumpModule, 
        UIDataProvider<ClrDumpType>, 
        UIDataProvider<AddressList>,
        UIDataProvider<ArraysAddressList>
    {
        static Logger logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName);

        private List<ClrTypeStats> typeStats;
        public TypeStatModule()
        {
            InitializeComponent();
            Icon = Properties.Resources.application_view_list;
        }

        public override void Close()
        {
            base.Close();
            ClrDump?.Dispose();
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
            if (ClrDump.Runtime != null)
            {
                typeStats = ClrDump.GetTypeStats();
                Summary = $"{typeStats.Count:###,###,###,##0} types";
            }
            else
            {
                Summary = $"Error. Dump file not loaded !";
            }
            Log("Type statistics computed.", WinFwk.UITools.Log.LogLevelType.Info);
        }

        public override void PostInit()
        {
            dlvTypeStats.InitColumns<ClrTypeStats>();
            dlvTypeStats.SetUpTypeColumn<ClrTypeStats>(this);
            dlvTypeStats.SetObjects(typeStats);
            dlvTypeStats.Sort(nameof(ClrTypeStats.NbInstances), SortOrder.Descending);

            dlvTypeStats.SetTypeNameFilter<ClrTypeStats>(regexFilterControl);
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
                var dumpType = ((UIDataProvider<ClrDumpType>)this).Data;
                if( dumpType == null)
                {
                    return null;
                }
                TypeInstancesAddressList list = new TypeInstancesAddressList(dumpType);
                list.Init();
                return list;
            }
        }

        ArraysAddressList UIDataProvider<ArraysAddressList>.Data
        {
            get
            {
                var dumpType = ((UIDataProvider<ClrDumpType>)this).Data;
                if (dumpType == null)
                {
                    return null;
                }
                if( ! dumpType.IsArray)
                {
                    return null;
                }
                ArraysAddressList list = new ArraysAddressList(dumpType);
                return list;
            }
        }

        private void dlvTypeStats_CellClick(object sender, CellClickEventArgs e)
        {
            if( e.ClickCount != 2)
            {
                return;
            }
            var clrDumpType = ((UIDataProvider<ClrDumpType>)this).Data;
            if(clrDumpType != null)
            {
                TypeInstancesModule.Create(clrDumpType, this, mod => RequestDockModule(mod));
            }
        }
    }
}
