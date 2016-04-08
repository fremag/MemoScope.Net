using BrightIdeasSoftware;
using System.Windows.Forms;

namespace WinFwk.UITools
{
    public class PercentColumnAttribute : OLVColumnAttribute
    {
        public PercentColumnAttribute(string format= "{0:p2}")
        {
            AspectToStringFormat = format;
            TextAlign = HorizontalAlignment.Right;
            Width = 150;
        }
    }
}
