using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BrightIdeasSoftware;
using WinFwk.UITools;
using System;

namespace MemoScope.Modules.Explorer
{
    public abstract class AbstractDumpExplorerData : ITreeNodeInformation<AbstractDumpExplorerData>
    {
        [OLVColumn(Width = 350, ImageAspectName = nameof(Icon))]
        public string Name { get; protected set; }
        [IntColumn(Title = "Size (Mo)", Width = 50)]
        public abstract long Size { get; }
        public Image Icon { get; protected set; }

        [OLVColumn(Title = "Date", Width = 100, TextAlign = HorizontalAlignment.Center, AspectToStringFormat = "{0:yyyy/MM/dd}")]
        public DateTime? Date => FileInfo?.LastWriteTime;

        [IntColumn(Title = "Cache Size (Mo)", Width = 50)]
        public long? CacheSize
        {
            get
            {
                string cachePath = GetCachePath();
                if (File.Exists(cachePath))
                {
                    FileInfo cacheFileInfo = new FileInfo(cachePath);
                    return Math.Max(cacheFileInfo.Length / (long)1e6, 1) ;
                }

                return null;
            }
        }
        [OLVColumn(Title = "Delete Cache", Width=100, TextAlign =HorizontalAlignment.Center)]
        public string DeleteCache => CacheSize != null ? "Delete" : null;

        public virtual string GetCachePath()
        {
            return null;
        }

        public abstract FileInfo FileInfo { get; }

        public abstract bool CanExpand { get;  }
        public abstract List<AbstractDumpExplorerData> Children { get;  }

        public static List<AbstractDumpExplorerData> GetItems(string mainDir)
        {
            List<AbstractDumpExplorerData> items = new List<AbstractDumpExplorerData>();
            if (! Directory.Exists(mainDir))
            {
                return items;
            }
            string[] dirs = Directory.GetDirectories(mainDir);
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