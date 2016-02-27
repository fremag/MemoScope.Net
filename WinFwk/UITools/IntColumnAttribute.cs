using BrightIdeasSoftware;
using System.Windows.Forms;

namespace WinFwk.UITools
{
    public class IntColumnAttribute : OLVColumnAttribute
    {
        public IntColumnAttribute()
        {
            AspectToStringFormat = "{0:###,###,###,##0}";
            TextAlign = HorizontalAlignment.Right;
            Width = 150;
        }
    }
}
