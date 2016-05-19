using BrightIdeasSoftware;
using System;
using System.Linq;
using System.Windows.Forms;

namespace WinFwk.UITools
{
    public class DefaultListView : FastObjectListView
    {
        public DefaultListView()
        {
            this.Init();

            this.ContextMenuStrip = new ContextMenuStrip();
            var menuItem = new ToolStripMenuItem("Copy Selected rows");
            ContextMenuStrip.Items.Add(menuItem);
            menuItem.Click += (o, e) =>
            {
                string text = string.Join(Environment.NewLine, this.SelectedToTsv());
                Clipboard.SetText(text);
            };
        }

        public void BuildGroups(string colName, SortOrder order, bool colIsVisible=false)
        {
            var col = this[colName];
            col.IsVisible = colIsVisible;
            BuildGroups(col, order);
        }

        public void InitColumns<T>()
        {
            Generator.GenerateColumns(this, typeof(T), false);
        }

        public void Sort(string colName, SortOrder sortOrder= SortOrder.Ascending)
        {
            var col = this[colName];
            Sort(col, SortOrder.Descending);
        }

        public OLVColumn this[string columnName] => this.AllColumns.FirstOrDefault(col => col.Name == columnName);
    }
}