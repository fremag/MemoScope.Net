using MemoScope.Core.Bookmarks;
using System.IO;
using System.Xml.Serialization;
using Microsoft.Diagnostics.Runtime;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace MemoScope.Core.ProcessInfo
{
    public class ClrDumpInfo
    {
        private readonly static XmlSerializer XML = new XmlSerializer(typeof(ClrDumpInfo));

        [XmlIgnore]
        public string DumpPath { get; private set; }
        private Dictionary<ulong, Bookmark> dicoBookmarks;

        public List<Bookmark> Bookmarks { get; internal set; }
        public ProcessInfo ProcessInfo { get; set; }

        public ClrDumpInfo()
        {
            Bookmarks = new List<Bookmark>();
        }

        public ClrDumpInfo(string dumpPath) : this()
        {
            DumpPath = dumpPath;
        }

        public static ClrDumpInfo Load(string dumpPath)
        {
            ClrDumpInfo clrDumpInfo = null;
            string clrDumpInfoPath = GetClrDumpInfoPath(dumpPath);
            try
            {
                if (File.Exists(clrDumpInfoPath))
                {
                    using (var reader = new StreamReader(clrDumpInfoPath))
                    {
                        var processInfoObj = XML.Deserialize(reader);
                        clrDumpInfo = processInfoObj as ClrDumpInfo;
                        clrDumpInfo.Init(dumpPath);
                    }
                }
            }
            finally
            {
                if (clrDumpInfo == null)
                {
                    clrDumpInfo = new ClrDumpInfo(dumpPath);
                    clrDumpInfo.ProcessInfo = new ProcessInfo();
                    clrDumpInfo.Init();
                    clrDumpInfo.Save();
                }
            }

            return clrDumpInfo;
        }

        private void Init(string dumpPath)
        {
            DumpPath = dumpPath;
            Init();
        }

        private void Init()
        {
            dicoBookmarks = Bookmarks.ToDictionary(bookmark => bookmark.Address);
        }

        private static string GetClrDumpInfoPath(string dumpPath)
        {
            var clrDumpInfoPath = Path.ChangeExtension(dumpPath, "xml");
            return clrDumpInfoPath;
        }

        public void  Save()
        {
            var dir = Path.GetDirectoryName(DumpPath);
            if (dir != null && !Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            string clrDumpInfoPath = GetClrDumpInfoPath(DumpPath);
            using (var writer = new StreamWriter(clrDumpInfoPath))
            {
                XML.Serialize(writer, this);
            }
        }

        internal void RemoveBookmark(ulong address)
        {
            Bookmark bookmark;
            if( dicoBookmarks.TryGetValue(address, out bookmark) )
            {
                dicoBookmarks.Remove(address);
                Bookmarks.Remove(bookmark);
                Save();
            }
        }

        internal void AddBookmark(ulong address, ClrType clrType)
        {
            if (dicoBookmarks != null && !dicoBookmarks.ContainsKey(address))
            {
                var bookmark = new Bookmark(address, clrType.Name);
                dicoBookmarks[address] = bookmark;
                Bookmarks.Add(bookmark);
                Save();
            }
        }

        public Bookmark GetBookmark(ulong address)
        {
            Bookmark bookmark;
            dicoBookmarks.TryGetValue(address, out bookmark);
            return bookmark;
        }

        internal void InitProcessInfo(Process process)
        {
            ProcessInfo = new ProcessInfo(process);
        }
    }
}
