using MemoScope.Core;
using WinFwk.UICommands;

namespace MemoScope.Modules.Bookmarks
{
    public class BookmarkCommand : AbstractTypedUICommand<ClrDump>
    {
        public BookmarkCommand() : base("Bookmarks", "Open bookmark module", "Dump", Properties.Resources.award_star_gold_blue)  
        {

        }
        protected override void HandleData(ClrDump data)
        {
            
        }
    }
}
