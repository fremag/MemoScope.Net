using BrightIdeasSoftware;
using MemoScope.Core.Data;
using MemoScope.Modules.InstanceDetails;
using MemoScope.Tools.RegexFilter;
using Microsoft.Diagnostics.Runtime;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WinFwk;
using WinFwk.UICommands;
using WinFwk.UIModules;
using WinFwk.UITools.Log;

namespace MemoScope.Core.Helpers
{
    public static class ObjectListViewHelpers
    {
        public static void SetUpTypeColumn<T>(this ObjectListView listView, UIClrDumpModule dumpModule=null) where T : ITypeNameData
        {
            SetUpTypeColumn(listView, nameof(ITypeNameData.TypeName), dumpModule);
        }

        public static void SetUpTypeColumn(this ObjectListView listView, string colType, UIClrDumpModule dumpModule = null, string suffix=null) 
        {
            OLVColumn col = listView.AllColumns.First(c => c.Name == colType);
            SetUpTypeColumn(listView, col, dumpModule, suffix);
        }

        public static void SetUpTypeColumn(this ObjectListView listView, OLVColumn col, UIClrDumpModule dumpModule=null, string suffix = null)
        {
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
            col.Width = 600;
            if (dumpModule != null)
            {
                listView.RegisterDataProvider(() =>
                {
                    var cellItem = listView.SelectedItem.SubItems[col.Index];
                    var subItem = cellItem as OLVListSubItem;
                    if (subItem == null)
                    {
                        return null;
                    }
                    string typeName = subItem.ModelValue as string;
                    ClrType type = dumpModule.ClrDump.GetClrType(typeName);
                    if (type != null)
                    {
                        return new TypeInstancesAddressList(dumpModule.ClrDump, type);
                    }
                    return null;
                }, dumpModule, suffix != null ? "All" : "All - "+suffix);
                listView.RegisterDataProvider(() =>
                {
                    var cellItem = listView.SelectedItem.SubItems[col.Index];
                    var subItem = cellItem as OLVListSubItem;
                    if( subItem == null)
                    {
                        return null;
                    }
                    string typeName = subItem.ModelValue as string;

                    ClrType type = dumpModule.ClrDump.GetClrType(typeName);
                    if (type != null)
                    {
                        return new ClrDumpType(dumpModule.ClrDump, type);
                    }
                    throw new ArgumentException($"Can't find type: {typeName}");
                }, dumpModule, suffix);
                listView.AddMenuSeparator();
            }
            listView.UseCellFormatEvents = true;
        }

        public static void AddAddressColumn(this ObjectListView listView, AspectGetterDelegate addressGetter, UIClrDumpModule dumpModule)
        {
            var col = new OLVColumn("Address", null) {AspectGetter = addressGetter};

            SetUpAddressColumn(listView, col, dumpModule);
            listView.AllColumns.Add(col);
        }
        public static void SetUpAddressColumn<T>(this ObjectListView listView, UIClrDumpModule dumpModule, string suffix = null) where T : IAddressData
        {
            SetUpAddressColumn(listView, nameof(IAddressData.Address), dumpModule, suffix);
        }

        public static void SetUpAddressColumn(this ObjectListView listView, string colName, UIClrDumpModule dumpModule, string suffix = null)
        {
            var col = listView.AllColumns.First(c => c.Name == colName);
            SetUpAddressColumn(listView, col, dumpModule, suffix);
        }

        public static void SetUpAddressColumn(this ObjectListView listView, OLVColumn col, UIClrDumpModule dumpModule, string suffix = null)
        {
            col.AspectToStringFormat = "{0:X}";
            col.TextAlign = HorizontalAlignment.Right;
            col.Width = 150;

            listView.CellClick += (o, e) =>
            {
                if (e.ClickCount == 2 && e.Column == col)
                {
                    if (e.Model == null)
                    {
                        return;
                    }
                    var cellItem = listView.SelectedItem?.GetSubItem(col.Index);
                    if (cellItem == null)
                    {
                        return;
                    }
                    var addressObj = cellItem.ModelValue;
                    if (addressObj is ulong)
                    {
                        var address = (ulong)addressObj;
                        if (address == 0)
                        {
                            return;
                        }
                        var type = dumpModule.ClrDump.GetObjectType(address);
                        if( type == null)
                        {
                            dumpModule.Log($"Can't find type for instance: {address:X}", LogLevelType.Error);
                            return;
                        }
                        var clrDumpObject = new ClrDumpObject(dumpModule.ClrDump, type, address);
                        InstanceDetailsCommand.Display(dumpModule, clrDumpObject);
                    }
                }
            };
            listView.RegisterDataProvider(() =>
               {
                   var cellItem = listView.SelectedItem?.GetSubItem(col.Index);
                   if (cellItem == null)
                   {
                       return null;
                   }
                   var addressObj = cellItem.ModelValue;
                   if (addressObj is ulong)
                   {
                       var address = (ulong)addressObj;
                       var type = dumpModule.ClrDump.GetObjectType(address);
                       var clrDumpObject = new ClrDumpObject(dumpModule.ClrDump, type, address);
                       return clrDumpObject;
                   }
                   return null;
               }, dumpModule, suffix
            );
            listView.FormatCell += (o, e) =>
            {
                if (e.Column != col || e.SubItem.ModelValue == null)
                {
                    return;
                }
                var addressObj = e.SubItem.ModelValue;
                if (addressObj is ulong)
                {
                    var address = (ulong)addressObj;
                    var bookmark = dumpModule.ClrDump.ClrDumpInfo.GetBookmark(address);
                    if (bookmark != null)
                    {
                        e.SubItem.BackColor = bookmark.Color;
                    }
                }
            };
            var tooltipGetter = listView.CellToolTipGetter;
            listView.CellToolTipGetter = (column, modelObject) =>
            {
                if (column == col)
                {
                    if (modelObject == null || !(modelObject is ulong))
                    {
                        return null;
                    }
                    if (modelObject is ulong)
                    {
                        var address = (ulong)modelObject;
                        var bookmark = dumpModule.ClrDump.ClrDumpInfo.GetBookmark(address);
                        if (bookmark != null)
                        {
                            return bookmark.Comment;
                        }
                    }
                }
                if (tooltipGetter != null)
                {
                    return tooltipGetter(column, modelObject);
                }
                return null;
            };
            listView.UseCellFormatEvents = true;
            listView.AddMenuSeparator();
            listView.SelectedIndexChanged += (sender, evt) =>
            {
                var cellItem = listView.SelectedItem?.GetSubItem(col.Index);
                if (cellItem == null)
                {
                    return;
                }
                var addressObj = cellItem.ModelValue;
                if (addressObj is ulong)
                {
                    var address = (ulong)addressObj;
                    var type = dumpModule.ClrDump.GetObjectType(address);
                    var clrDumpObject = new ClrDumpObject(dumpModule.ClrDump, type, address);
                    dumpModule.MessageBus.SendMessage(new SelectedClrDumpObjectMessage(clrDumpObject));
                }
            };
            var menuItem = new ToolStripMenuItem("Copy Address");
            //            menuItem.Image = command.Icon;
            listView.ContextMenuStrip.Items.Add(menuItem);
            menuItem.Click += (o, e) =>
            {
                var cellItem = listView.SelectedItem?.GetSubItem(col.Index);
                if (cellItem == null)
                {
                    return;
                }
                var addressObj = cellItem.ModelValue;
                if (addressObj is ulong)
                {
                    var address = (ulong)addressObj;
                    Clipboard.SetText(address.ToString("X"));
                }
            };
        }

        public static void AddSimpleValueColumn(this ObjectListView listView, Func<object, ulong> addressGetter, ClrDump dump, ClrType type)
        {
            if (!dump.IsPrimitive(type) && !dump.IsString(type))
            {
                return;
            }
            AddSimpleValueColumn(listView, addressGetter, dump, o => type);
        }

        public static void AddSimpleValueColumn(this ObjectListView listView, Func<object, ulong> addressGetter, ClrDump dump, Func<object, ClrType> typeGetter)
        {
            var col = new OLVColumn("Value", null)
            {
                Width = 150
            };

            col.AspectGetter = o =>
            {
                ClrType type = typeGetter(o);
                ulong address = addressGetter(o);
                object result = dump.Eval(
                    () => {
                        if (type.IsPrimitive || type.IsString)
                            return type.GetValue(address);
                        return address;
                    }
                );
                return result;
            };
            listView.AllColumns.Add(col);
            var menuItem = new ToolStripMenuItem("Copy Value");
            listView.ContextMenuStrip.Items.Add(menuItem);
            menuItem.Click += (o, e) =>
            {
                if(listView.SelectedItem==null)
                {
                    return;
                }

                int index = listView.SelectedItem.Index;
                var modelObject = listView.GetModelObject(index);
                string val = col.GetStringValue(modelObject);
                string escapeVal = StringHelpers.Escape(val);
                if( string.IsNullOrEmpty(escapeVal))
                {
                    Clipboard.SetText("null");
                }
                else
                {
                    Clipboard.SetText(escapeVal);
                }
            };
        }
        public static void AddSizeColumn(this ObjectListView listView, Func<object, ulong> addressGetter, ClrDump dump, ClrType type)
        {
            AddSizeColumn(listView, addressGetter, dump, o => type);
        }

        public static void AddSizeColumn(this ObjectListView listView, Func<object, ulong> addressGetter, ClrDump dump, Func<object, ClrType> clrTypeGetter)
        {
            var col = new OLVColumn("Size", null)
            {
                Width = 60, TextAlign = HorizontalAlignment.Right
            };

            col.AspectGetter = o =>
            {
                if( o == null)
                {
                    return null;
                }

                ulong address = addressGetter(o);
                if(address ==0)
                {
                    return 0;
                }
                object result = dump.Eval(
                    () => {
                        var type = clrTypeGetter(o);
                        if (type != null)
                        {
                            return type.GetSize(address);
                        }
                        return (ulong)0;
                    }
                );
                return result;
            };
            col.AspectToStringFormat = "{0:###,###,###,##0}";
            listView.AllColumns.Add(col);
        }

        public static void AddRefInColumn(this ObjectListView listView, Func<object, ulong> addressGetter, ClrDump dump)
        {
            var col = new OLVColumn("RefIn", null)
            {
                Width = 60,
                TextAlign = HorizontalAlignment.Right
            };

            col.AspectGetter = o =>
            {
                if (o == null)
                {
                    return null;
                }

                ulong address = addressGetter(o);
                if (address == 0)
                {
                    return 0;
                }
                object result = dump.CountReferers(address );
                return result;
            };
            col.AspectToStringFormat = "{0:###,###,###,##0}";
            listView.AllColumns.Add(col);
        }

        public static void RegisterDataProvider<T>(this ObjectListView listView, Func<T> dataProvider, UIModule parentModule, string suffix = null)
        {
            if (listView.ContextMenuStrip == null)
            {
                listView.ContextMenuStrip = new ContextMenuStrip();
            }
            var types = WinFwkHelper.GetDerivedTypes(typeof(AbstractDataUICommand<T>));
            foreach (var type in types)
            {
                var command = Activator.CreateInstance(type, null) as AbstractDataUICommand<T>;
                command.InitBus(parentModule.MessageBus);
                command.SetMasterModule(parentModule);
                command.InitDataProvider(new UIDataProviderAdapter<T>(dataProvider));
                string menuItemText = command.ToolTip;
                if( suffix != null)
                {
                    menuItemText += " ("+suffix+")";
                }
                var menuItem = new ToolStripMenuItem(menuItemText);
                menuItem.Image = command.Icon;
                listView.ContextMenuStrip.Items.Add(menuItem);
                menuItem.Click += (o, e) => OnMenuItemClick(command, dataProvider);
            }
        }

        private static void OnMenuItemClick<T>(AbstractDataUICommand<T> command, Func<T> dataProvider)
        {
            try
            {
                command.Run();
            }
            catch (Exception e)
            {
                command.MessageBus.Log(command, $"Command ({command.Name}) failed !", e);
            }
        }

        public static T SelectedObject<T>(this ObjectListView listView) where T : class
        {
            return (listView.SelectedObject) as T;
        }

        public static void AddMenuSeparator(this ObjectListView listView)
        {
            if( listView.ContextMenuStrip != null)
            {
                listView.ContextMenuStrip.Items.Add("-");
            }
        }

        public static void AddRowNumberColumn(this ObjectListView listView)
        {
            var col = new OLVColumn("#", null);
            col.TextAlign = HorizontalAlignment.Right;
            listView.AllColumns.Add(col);
            listView.FormatRow += delegate (object sender, FormatRowEventArgs args) {
                args.Item.Text = args.RowIndex.ToString("###,###,###,###,##0");
            };
        }

        public static void SetTypeNameFilter<T>(this ObjectListView listView, RegexFilterControl regexFilterControl) where T : ITypeNameData
        {
            SetRegexFilter(listView, regexFilterControl, o => ((T)o).TypeName);
        }

        public static void SetRegexFilter(this ObjectListView listView, RegexFilterControl regexFilterControl, Func<object, string> typeNameGetter)
        {
            regexFilterControl.RegexApplied += (regex) => {
                listView.ModelFilter = new ModelFilter((o) =>
                {
                    if (o == null)
                    {
                        return true;
                    }
                    var typeName = typeNameGetter(o);
                    var b = regex.IsMatch(typeName);
                    return b;
                });
                listView.UseFiltering = true;
            };
            regexFilterControl.RegexCancelled += () => listView.UseFiltering = false;
        }
    }
}
