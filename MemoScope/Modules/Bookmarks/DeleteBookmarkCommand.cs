using MemoScope.Core.Data;
using System;
using WinFwk.UICommands;

namespace MemoScope.Modules.Bookmarks
{
    public class DeleteBookmarkCommand : AbstractDataUICommand<ClrDumpObject>
    {
        public DeleteBookmarkCommand() : base("Delete", "Delete bookmark on instance", "Bookmarks", Properties.Resources.award_star_delete)  
        {

        }

        protected override void HandleData(ClrDumpObject data)
        {
            if (data == null)
            {
                throw new InvalidOperationException("No instance selected !");
            }

            MessageBus.SendMessage(new BookmarkMessage(BookmarkAction.Remove, data));
        }
    }
}
