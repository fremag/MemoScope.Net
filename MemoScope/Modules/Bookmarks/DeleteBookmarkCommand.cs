using MemoScope.Core.Data;
using System.Windows.Forms;
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
            if (data == null)
            {
                MessageBox.Show("No instance selected !");
                return;
            }

            MessageBus.SendMessage(new BookmarkMessage(BookmarkAction.Remove, data));
        }
    }
}
