using BrightIdeasSoftware;
using System.Windows.Forms;

namespace WinFwk.UITools
{
    public class AddressColumnAttribute : OLVColumnAttribute
    {
        public AddressColumnAttribute()
        {
            AspectToStringFormat = "{0:X}";
            TextAlign = HorizontalAlignment.Right;
            Width = 150;
        }
    }
}
