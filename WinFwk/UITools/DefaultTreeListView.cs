using BrightIdeasSoftware;
using System;
using System.Drawing;
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
            CanExpandGetter = o =>
            {
                var item = (T)o;
                try
                {
                    return item.CanExpand;
                }
                catch (Exception e)
                {
                    item.BackColor = Color.Red;
                    item.ForeColor = Color.Black;
                    item.Tooltip = $"Error: {e.Message}";
                    return false;
                }
            };

            ChildrenGetter = o => 
            {
                var item = (T)o;
                try
                {
                    return item.Children;
                }
                catch (Exception e)
                {
                    item.BackColor = Color.Red;
                    item.ForeColor = Color.Black;
                    item.Tooltip = $"Error: ${e.Message}";
                    return null;
                }
            };

            CellToolTipGetter = (col, o) => ((T)o).Tooltip;


            FormatRow += (sender, arg) =>
            {
                var treeNode = (arg.Model) as ITreeNodeInformation<T>;
                if (treeNode.BackColor != Color.Transparent)
                {
                    arg.Item.BackColor = treeNode.BackColor;
                }
                if (treeNode.ForeColor != Color.Transparent)
                {
                    arg.Item.ForeColor = treeNode.ForeColor;
                }
            };
            UseCellFormatEvents = true;

            this.InitColumnTooltips();
        }


        public OLVColumn this[string columnName] => this.AllColumns.FirstOrDefault(col => col.Name == columnName);
    }
}