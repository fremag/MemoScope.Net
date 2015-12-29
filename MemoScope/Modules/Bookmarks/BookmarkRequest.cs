namespace MemoScope.Modules.Bookmarks
{
    public enum BookmarkAction {Add, Remove, Update}
    public class BookmarkRequest
    {
        public BookmarkAction Action { get; }
        public BookmarkRequest(BookmarkAction action)
        {
            Action = action;
        }
    }
}