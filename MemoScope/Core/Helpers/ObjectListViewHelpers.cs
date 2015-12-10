using BrightIdeasSoftware;
using System.Drawing;
using System.Linq;

namespace MemoScope.Core.Helpers
{
    public static class ObjectListViewHelpers
    {
        public static void MakeTypeColumn(this ObjectListView listView, string colName)
        {
            var col = listView.AllColumns.First(c => c.Name == colName);
            listView.FormatCell += (sender, e) =>
            {
                if (e.Column == col)
                {
                    string val = e.SubItem.ModelValue as string;
                    if (val != null)
                    {
                        var colors = TypeHelpers.GetAliasColor(val);
                        if (colors.Item1 != Color.Transparent)
                        {
                            e.SubItem.BackColor = colors.Item1;
                        }
                        if (colors.Item2 != Color.Transparent)
                        {
                            e.SubItem.ForeColor = colors.Item2;
                        }
                    }
                }
            };
            listView.UseCellFormatEvents = true;
        }
    }
}
