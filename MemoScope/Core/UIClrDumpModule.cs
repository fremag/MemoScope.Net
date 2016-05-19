using System.Linq;
using BrightIdeasSoftware;
using WinFwk.UICommands;
using WinFwk.UIModules;
using WinFwk.UITools.Commands;
using System.Collections.Generic;
using WinFwk.UITools;

namespace MemoScope.Core
{
    public partial class UIClrDumpModule : UIModule, 
        UIDataProvider<ClrDump>,
        IDataExportable
    {
        public  ClrDump ClrDump { get; protected set; }

        public UIClrDumpModule()
        {
            InitializeComponent();
        }

        ClrDump UIDataProvider<ClrDump>.Data => ClrDump;

        public virtual IEnumerable<ObjectListView> ListViews => Controls.OfType<ObjectListView>();

        IEnumerable<string> IDataExportable.ExportableData()
        {
            if (this.ListViews.Any())
            {
                foreach (var listView in ListViews)
                {
                    foreach (var data in listView.ToTsv())
                    {
                        yield return data;
                    }
                    yield return "";
                }
            }
        }
    }
}
