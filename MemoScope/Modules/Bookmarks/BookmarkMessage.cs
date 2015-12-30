using MemoScope.Core.Data;
using WinFwk.UIMessages;

namespace MemoScope.Modules.Bookmarks
{
    public enum BookmarkAction {Add, Remove, Update}

    public class BookmarkMessage : AbstractUIMessage
    {
        public BookmarkAction Action { get; }
        public ClrDumpObject ClrDumpObject { get; }
        public BookmarkMessage(BookmarkAction action, ClrDumpObject clrDumpObject)
        {
            Action = action;
            ClrDumpObject = clrDumpObject;
        }
    }
}