using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MemoScope.Modules.Explorer
{
    public class DirectoryData : AbstractDumpExplorerData
    {
        private DirectoryInfo DirInfo { get; }
        public DirectoryData(DirectoryInfo dirInfo)
        {
            DirInfo = dirInfo;
            Name = dirInfo.Name;
            Icon = Properties.Resources.folder;
        }

        public override long Size => GetChildren.Count();

        public override bool HasChildren
        {
            get
            {
                var files = DirInfo.GetFiles("*.dmp");
                return files.Length > 0;
            } 
        }

        public override IEnumerable<AbstractDumpExplorerData> GetChildren => GetItems(DirInfo.FullName);
    }
}