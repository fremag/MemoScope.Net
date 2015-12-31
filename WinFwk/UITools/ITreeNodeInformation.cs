using System.Collections.Generic;

namespace WinFwk.UITools
{
    public interface ITreeNodeInformation<T>
    {
        bool CanExpand { get; }
        List<T> Children { get; }
    }
}