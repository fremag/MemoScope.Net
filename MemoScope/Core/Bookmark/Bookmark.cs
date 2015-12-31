using BrightIdeasSoftware;
using MemoScope.Core.Data;

namespace MemoScope.Core.Bookmark
{
    public class Bookmark : IAddressData
    {
        [OLVColumn]
        public ulong Address { get; set; }
        [OLVColumn(Title="Type", IsVisible =false)]
        public string TypeName { get; set; }

        //XmlSerializer needs a parameter less constructor
        public Bookmark()
        {
        }

        public Bookmark(ulong address, string typeName)
        {
            Address = address;
            TypeName = typeName;
        }
    }
}
