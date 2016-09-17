using WinFwk.UIMessages;
using WinFwk.UIServices;

namespace MemoScope.Modules.Bookmarks
{
    public class BookmarkService : AbstractUIService, IMessageListener<BookmarkMessage>
    {
        public void HandleMessage(BookmarkMessage message)
        {
            var clrDumpObject = message.ClrDumpObject;
            var address = clrDumpObject.Address;
            var clrDump = clrDumpObject.ClrDump;

            Log($"Bookmark: {message.Action}, {address:X}#{clrDump.Id}");

            switch(message.Action)
            {
                case BookmarkAction.Add:
                    clrDump.ClrDumpInfo.AddBookmark(address, clrDumpObject.ClrType);
                    break;
                case BookmarkAction.Remove:
                    clrDump.ClrDumpInfo.RemoveBookmark(address);
                    break;
            }
        }
    }
}
