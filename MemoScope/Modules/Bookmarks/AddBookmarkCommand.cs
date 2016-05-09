using MemoScope.Core.Data;
using System.Windows.Forms;
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
                MessageBox.Show("No instance selected !");
                return;
            }
            MessageBus.SendMessage(new BookmarkMessage(BookmarkAction.Add, data));
        }
    }
}
