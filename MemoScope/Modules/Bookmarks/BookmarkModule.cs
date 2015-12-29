using MemoScope.Core;

namespace MemoScope.Modules.Bookmarks
{
    public partial class BookmarkModule : UIClrDumpModule
    {
        public BookmarkModule()
        {
            InitializeComponent();
        }
        public void SetUp(ClrDump clrDump)
        {
            ClrDump = clrDump;
        }
        public override void PostInit()
        {
            Icon = Properties.Resources.award_star_gold_blue;
            Name = $"#{ClrDump.Id} - Bookmarks";
        }
    }
}
