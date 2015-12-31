using BrightIdeasSoftware;
using MemoScope.Core;
using MemoScope.Core.Bookmark;
using MemoScope.Core.Helpers;
using System.Windows.Forms;
using WinFwk.UIMessages;
using System;

namespace MemoScope.Modules.Bookmarks
{
    public partial class BookmarkModule : UIClrDumpModule, IMessageListener<BookmarkMessage>
    {
        public BookmarkModule()
        {
            InitializeComponent();
        }

        public void SetUp(ClrDump clrDump)
        {
            ClrDump = clrDump;
            Generator.GenerateColumns(dlvBookmarks, typeof(Bookmark), false);
            dlvBookmarks.SetUpAddressColumn<Bookmark>(nameof(Bookmark.Address), ClrDump, this);
            dlvBookmarks.SetUpTypeColumn(nameof(Bookmark.TypeName));
            LoadBookmarks();
        }

        private void LoadBookmarks()
        {
            dlvBookmarks.Objects = ClrDump.BookmarkMgr.GetBookmarks();
            dlvBookmarks.BuildGroups(nameof(Bookmark.TypeName), SortOrder.Ascending);
        }

        public override void PostInit()
        {
            Icon = Properties.Resources.award_star_gold_blue;
            Name = $"#{ClrDump.Id} - Bookmarks";
        }

        public void HandleMessage(BookmarkMessage message)
        {
            LoadBookmarks();
        }
    }
}
