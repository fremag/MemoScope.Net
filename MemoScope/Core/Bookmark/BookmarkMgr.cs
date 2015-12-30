using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Microsoft.Diagnostics.Runtime;
using System.Linq;

namespace MemoScope.Core.Bookmark
{
    public class BookmarkMgr
    {
        private string bookmarkPath;
        private XmlSerializer xml;
        private List<Bookmark> bookmarks = new List<Bookmark>();
        public BookmarkMgr(string dumpPath)
        {
            bookmarkPath = Path.ChangeExtension(dumpPath, "xml");
            xml = new XmlSerializer(typeof(List<Bookmark>));
        }

        public List<Bookmark> GetBookmarks()
        {
            if (File.Exists(bookmarkPath))
            {
                using (var reader = new StreamReader(bookmarkPath))
                {
                    var bookmarksObj = xml.Deserialize(reader);
                    bookmarks = bookmarksObj as List<Bookmark>;
                }
            }
            return bookmarks;
        }

        public void Remove(ulong address, ClrType clrType)
        {
            var bookmark = bookmarks.FirstOrDefault(b => b.Address == address);
            if (bookmark != null)
            {
                bookmarks.Remove(bookmark);
                SaveBookmarks();
            }
        }

        public void Add(ulong address, ClrType clrType)
        {
            var bookmark = bookmarks.FirstOrDefault(b => b.Address == address);
            if (bookmark == null)
            {
                bookmark = new Bookmark(address, clrType.Name);
                bookmarks.Add(bookmark);
                SaveBookmarks();
            }
        }

        public void SaveBookmarks()
        {
            if(bookmarks == null)
            {
                return;
            }

            var dir = Path.GetDirectoryName(bookmarkPath);
            if (dir != null && !Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            using (var reader = new StreamWriter(bookmarkPath))
            {
                xml.Serialize(reader, bookmarks);
            }
        }
    }
}
