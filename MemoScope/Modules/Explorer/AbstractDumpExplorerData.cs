using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BrightIdeasSoftware;
using WinFwk.UITools;

namespace MemoScope.Modules.Explorer
{
    public abstract class AbstractDumpExplorerData : ITreeNodeInformation<AbstractDumpExplorerData>
    {
        [OLVColumn(Width = 350, ImageAspectName = nameof(Icon))]
        public string Name { get; protected set; }
        [OLVColumn(Title="Size (Mo)", TextAlign = HorizontalAlignment.Right, AspectToStringFormat = "{0:###,###,###,##0}", Width = 50)]
        public abstract long Size { get; }
        public Image Icon { get; protected set; }

        public abstract FileInfo FileInfo { get; }

        public abstract bool CanExpand { get;  }
        public abstract List<AbstractDumpExplorerData> Children { get;  }

        public static List<AbstractDumpExplorerData> GetItems(string mainDir)
        {
            string[] dirs = Directory.GetDirectories(mainDir);
            List<AbstractDumpExplorerData> items = new List<AbstractDumpExplorerData>();
            foreach (var dir in dirs)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(dir);
                var x = new DirectoryData(dirInfo);
                items.Add(x);
            }
            string[] files = Directory.GetFiles(mainDir, "*.dmp");
            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                var f = new FileData(fileInfo);
                items.Add(f);
            }
            return items;
        }
    }
}