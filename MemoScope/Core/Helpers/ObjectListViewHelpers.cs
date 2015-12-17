using BrightIdeasSoftware;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MemoScope.Core.Helpers
{
    public static class ObjectListViewHelpers
    {
        public static void SetUpTypeColumn(this ObjectListView listView, string colName)
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
            col.AspectToStringConverter = o => TypeHelpers.ManageAlias((string)o);
            listView.UseCellFormatEvents = true;
        }

        public static void AddAddressColumn(this ObjectListView listView, AspectGetterDelegate aspectGetter)
        {
            var col = new OLVColumn("Address", null) {
                AspectGetter = aspectGetter,
                AspectToStringFormat = "{0:X}",
                TextAlign = HorizontalAlignment.Right,
                Width = 110 };
            listView.AllColumns.Add(col);
        }
    }
}
