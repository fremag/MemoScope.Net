using System.Collections.Generic;
using System.IO;
using WinFwk.UIMessages;

namespace MemoScope.Modules.Explorer
{
    public class OpenDumpRequest : AbstractUIMessage
    {
        public IEnumerable<FileInfo> FileInfos { get; }
        public OpenDumpRequest(IEnumerable<FileInfo> fileInfos)
        {
            FileInfos = fileInfos;
        }
    }
}