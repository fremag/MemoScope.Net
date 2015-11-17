using System.Collections.Generic;
using System.IO;

namespace MemoScope.Modules.Explorer
{
    public class FileData : AbstractDumpExplorerData
    {
        public override FileInfo FileInfo { get; }
        public FileData(FileInfo fileInfo)
        {
            FileInfo = fileInfo;
            Name = fileInfo.Name;
            Icon = Properties.Resources.file_extension_bin;
        }

        public override long Size => FileInfo.Length/1000000;
        public override bool HasChildren => false;
        public override IEnumerable<AbstractDumpExplorerData> Children => null;
    }
}