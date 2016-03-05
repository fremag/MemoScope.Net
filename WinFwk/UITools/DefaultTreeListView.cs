using BrightIdeasSoftware;
using System.Linq;

namespace WinFwk.UITools
{
    public class DefaultTreeListView : DataTreeListView
    {
        public DefaultTreeListView()
        {
            FullRowSelect = true;
            HideSelection = false;
            ShowImagesOnSubItems = true;
        }

        public void InitData<T>() where T : ITreeNodeInformation<T>
        {
            Generator.GenerateColumns(this, typeof(T), false);
            CanExpandGetter = o => ((T)o).CanExpand;
            ChildrenGetter = o => ((T)o).Children;
        }
    }
}