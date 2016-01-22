using MemoScope.Core.Data;
using WinFwk.UICommands;

namespace MemoScope.Modules.Bookmarks
{
    public class DeleteBookmarkCommand : AbstractTypedUICommand<ClrDumpObject>
    {
        public DeleteBookmarkCommand() : base("Delete", "Delete bookmark on instance", "Bookmarks", Properties.Resources.award_star_delete)  
        {

        }

        protected override void HandleData(ClrDumpObject data)
        {
            MessageBus.SendMessage(new BookmarkMessage(BookmarkAction.Remove, data));
        }
    }
}
