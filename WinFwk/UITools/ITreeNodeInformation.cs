using System.Collections.Generic;
using System.Drawing;

namespace WinFwk.UITools
{
    public interface ITreeNodeInformation<T>
    {
        bool CanExpand { get; }
        List<T> Children { get; }

        string Tooltip { get; set; }
        Color ForeColor { get; set; }
        Color BackColor { get; set; }
    }

    public class TreeNodeInformationAdapter<T> : ITreeNodeInformation<T>
    {
        public virtual bool CanExpand { get; set; } = false;
        public virtual List<T> Children { get; set; } = null;
        public virtual string Tooltip { get; set; } = null;
        public virtual Color ForeColor { get; set; } = Color.Transparent;
        public virtual Color BackColor { get; set; } = Color.Transparent;
    }
}