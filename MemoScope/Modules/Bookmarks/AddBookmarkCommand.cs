using MemoScope.Core.Data;
using WinFwk.UICommands;

namespace MemoScope.Modules.Bookmarks
{
    public class AddBookmarkCommand : AbstractTypedUICommand<ClrDumpObject>
    {
        public AddBookmarkCommand() : base("Add", "Add bookmark on instance", "Bookmarks", Properties.Resources.award_star_add)  
        {

        }
        protected override void HandleData(ClrDumpObject data)
        {
            MessageBus.SendMessage(new BookmarkMessage(BookmarkAction.Add, data));
        }
    }
}
