using WinFwk.UIMessages;

namespace MemoScope.Core.Data
{
    public class SelectedClrDumpObjectMessage : AbstractUIMessage
    {
        public ClrDumpObject SelectedInstance { get; }
        public SelectedClrDumpObjectMessage(ClrDumpObject selectedInstance)
        {
            SelectedInstance = selectedInstance;
        }
    }
}
