using MemoScope.Core.Cache;
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
        public override bool CanExpand => false;
        public override List<AbstractDumpExplorerData> Children => null;
        public override string GetCachePath()
        {
            var cachePath = ClrDumpCache.GetCachePath(FileInfo.FullName);
            return cachePath;
        }

    }
}