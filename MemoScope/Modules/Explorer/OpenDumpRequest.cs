using System.Collections.Generic;
using System.IO;
using WinFwk.UIMessages;

namespace MemoScope.Modules.Explorer
{
    internal class OpenDumpRequest : AbstractUIMessage
    {
        IEnumerable<FileInfo> FileInfos { get; }
        public OpenDumpRequest(IEnumerable<FileInfo> fileInfos)
        {
            FileInfos = fileInfos;
        }
    }
}