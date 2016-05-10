using System.Linq;
using BrightIdeasSoftware;
using WinFwk.UICommands;
using WinFwk.UIModules;
using WinFwk.UITools.Commands;
using MemoScope.Core.Helpers;
using System.Collections.Generic;
using System;

namespace MemoScope.Core
{
    public partial class UIClrDumpModule : UIModule, 
        UIDataProvider<ClrDump>,
        UIDataProvider<ICopyData>
    {
        public  ClrDump ClrDump { get; protected set; }

        public UIClrDumpModule()
        {
            InitializeComponent();
        }

        ClrDump UIDataProvider<ClrDump>.Data => ClrDump;

        public virtual IEnumerable<ObjectListView> ListViews => Controls.OfType<ObjectListView>();
        public virtual ICopyData Data
        {
            get
            {
                if( this.ListViews.Any())
                {
                    string data = "";
                    foreach(var listView in ListViews)
                    {
                        data += listView.ToTsv() + Environment.NewLine;
                    }
                    return new BasicCopyData(data);
                }
                return null;
            }
        }
    }
}
