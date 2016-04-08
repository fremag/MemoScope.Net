using BrightIdeasSoftware;
using System.Windows.Forms;

namespace WinFwk.UITools
{
    public class DoubleColumnAttribute : OLVColumnAttribute
    {
        public DoubleColumnAttribute(string format= "{0:n2}")
        {
            AspectToStringFormat = format;
            TextAlign = HorizontalAlignment.Right;
            Width = 150;
        }
    }
}
