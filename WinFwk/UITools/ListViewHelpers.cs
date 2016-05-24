using BrightIdeasSoftware;
using System.Collections.Generic;
using System.Linq;

namespace WinFwk.UITools
{
    public static class ListViewHelpers
    {
        public static IEnumerable<string> ToTsv(this ObjectListView listView)
        {
            return listView.ToTsv(Enumerable.Range(0, listView.GetItemCount()));
        }

        public static IEnumerable<string> SelectedToTsv(this ObjectListView listView)
        {
            return listView.ToTsv(listView.SelectedIndices.Cast<int>());
        }

        public static IEnumerable<string> ToTsv(this ObjectListView listView, IEnumerable<int> rows)
        {
            var columns = listView.ColumnsInDisplayOrder;
            int nbCol = columns.Count;
            string[] values = new string[nbCol];
            yield return GetHeaders(listView, values);

            foreach (int i in rows)
            {
                yield return RowToString(listView, i, values);
            }
        }

        private static string GetHeaders(ObjectListView listView, string[] values)
        {
            var columns = listView.ColumnsInDisplayOrder;
            int nbCol = columns.Count;
            for (int i = 0; i < nbCol; i++)
            {
                var col = columns[i];
                values[i] = col.Text;
            }
            return string.Join("\t", values);
        }

        private static string RowToString(ObjectListView listView, int rowIndex, string[] values)
        {
            var columns = listView.ColumnsInDisplayOrder;
            int nbCol = columns.Count;

            var modelObject = listView.GetModelObject(rowIndex);
            for (int i = 0; i < nbCol; i++)
            {
                var col = columns[i];
                string val = col.GetStringValue(modelObject);
                string escapeVal = StringHelpers.Escape(val);
                values[i] = escapeVal;
            }
            return string.Join("\t", values);
        }

        public static void InitColumnTooltips(this ObjectListView listView)
        {
            foreach(OLVColumn col in listView.AllColumns)
            {
                if( string.IsNullOrEmpty( col.ToolTipText ))
                {
                    col.ToolTipText = col.Text;
                }
            }
        }
    }
}
