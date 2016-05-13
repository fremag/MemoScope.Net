using MemoScope.Core.Data;
using System;
using WinFwk.UICommands;

namespace MemoScope.Modules.Bookmarks
{
    public class AddBookmarkCommand : AbstractDataUICommand<ClrDumpObject>
    {
        public AddBookmarkCommand() : base("Add", "Add bookmark on instance", "Bookmarks", Properties.Resources.award_star_add)  
        {

        }
        protected override void HandleData(ClrDumpObject data)
        {
            if( data == null)
            {
                throw new InvalidOperationException("No instance selected !");
            }
            MessageBus.SendMessage(new BookmarkMessage(BookmarkAction.Add, data));
        }
    }
}
