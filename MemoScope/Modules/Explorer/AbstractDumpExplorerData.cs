using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BrightIdeasSoftware;
using WinFwk.UITools;
using System;

namespace MemoScope.Modules.Explorer
{
    public abstract class AbstractDumpExplorerData : TreeNodeInformationAdapter<AbstractDumpExplorerData>
    {
        [OLVColumn(Width = 350, ImageAspectName = nameof(Icon))]
        public string Name { get; protected set; }
        [IntColumn(Title = "Size (Mo)", Width = 50)]
        public abstract long Size { get; }
        public Image Icon { get; protected set; }

        [OLVColumn(Title = "Date", Width = 150, TextAlign = HorizontalAlignment.Center, AspectToStringFormat = "{0:yyyy/MM/dd HH:mm:ss}")]
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

        [OLVColumn(Title = "Machine", Width = 100)]
        public virtual string MachineName => null;
        [OLVColumn(Title = "User", Width = 50)]
        public virtual string UserName => null;
        [IntColumn(Title = "Virt Mem (Mo)", Width = 50)]
        public virtual long? VirtualMemory => null;
        [IntColumn(Title = "Peak Virt Mem (Mo)", Width = 50)]
        public virtual long? PeakVirtualMemory => null;
        [IntColumn(Title = "Paged Mem (Mo)", Width = 50)]
        public virtual long? PagedMemory => null;
        [IntColumn(Title = "Peak Paged Mem (Mo)", Width = 50)]
        public virtual long? PeakPagedMemory => null;
        [IntColumn(Title = "Peak Working Set (Mo)", Width = 50)]
        public virtual long? PeakWorkingSet => null;
        [IntColumn(Title = "Working Set (Mo)", Width = 50)]
        public virtual long? WorkingSet => null;
        [IntColumn(Title = "Private Mem", Width = 50)]
        public virtual long? PrivateMemory => null;
        [OLVColumn(Title = "Start Time", Width = 150, AspectToStringFormat = "{0:yyyy/MM/dd HH:mm:ss}")]
        public virtual DateTime? StartTime => null;
        [OLVColumn(Title = "Dump Time", Width = 150, AspectToStringFormat = "{0:yyyy/MM/dd HH:mm:ss}")]
        public virtual DateTime? DumpTime => null;
        [OLVColumn(Title = "Total Proc. Time", Width = 150)]
        public virtual TimeSpan? TotalProcessorTime => null;
        [OLVColumn(Title = "User Proc. Time", Width = 150)]
        public virtual TimeSpan? UserProcessorTime => null;
        [OLVColumn(Title = "Command Line", Width = 150)]
        public virtual string CommandLine => null;
        [IntColumn(Title = "Handles", Width = 50)]
        public virtual long? HandleCount => null;

        public virtual string GetCachePath()
        {
            return null;
        }

        public abstract FileInfo FileInfo { get; }

        public static List<AbstractDumpExplorerData> GetItems(string mainDir)
        {
            List<AbstractDumpExplorerData> items = new List<AbstractDumpExplorerData>();
            if (! Directory.Exists(mainDir))
            {
                return items;
            }
            try
            {
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
            }
            catch (UnauthorizedAccessException)
            {
                
            }
            return items;
        }
    }
}