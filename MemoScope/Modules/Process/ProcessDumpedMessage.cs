using WinFwk.UIMessages;

namespace MemoScope.Modules.Process
{
    public class ProcessDumpedMessage : AbstractUIMessage
    {
        public string DumpPath { get; }
        public int Id { get; }

        public ProcessDumpedMessage(string dumpPath, int id)
        {
            this.DumpPath = dumpPath;
            this.Id = id;
        }
    }
}
