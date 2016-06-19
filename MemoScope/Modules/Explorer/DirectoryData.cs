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

        public override long Size => Children.Count();

        public override FileInfo FileInfo => null;

        public override bool CanExpand
        {
            get
            {
                DirInfo.Refresh();
                if (DirInfo.Exists)
                {
                    var files = DirInfo.GetFiles("*.dmp");
                    return files.Length > 0;
                } 
                else
                {
                    return false;
                }
            } 
        }

        public override List<AbstractDumpExplorerData> Children => GetItems(DirInfo.FullName);
    }
}