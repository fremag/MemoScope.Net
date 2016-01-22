using BrightIdeasSoftware;
using MemoScope.Core.Data;
using MemoScope.Modules.InstanceDetails;
using Microsoft.Diagnostics.Runtime;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WinFwk;
using WinFwk.UICommands;
using WinFwk.UIModules;

namespace MemoScope.Core.Helpers
{
    public static class ObjectListViewHelpers
    {
        public static void SetUpTypeColumn<T>(this ObjectListView listView, UIClrDumpModule dumpModule=null) where T : ITypeNameData
        {
            SetUpTypeColumn(listView, nameof(ITypeNameData.TypeName), dumpModule);
        }

        public static void SetUpTypeColumn(this ObjectListView listView, string colName, UIClrDumpModule dumpModule=null)
        {
            OLVColumn col = listView.AllColumns.First(c => c.Name == colName);
            SetUpTypeColumn(listView, col, dumpModule);
        }

        public static void SetUpTypeColumn(this ObjectListView listView, OLVColumn col, UIClrDumpModule dumpModule=null)
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
            col.Width = 300;
            if (dumpModule != null)
            {
                listView.RegisterDataProvider(() =>
                {
                    var cellItem = listView.SelectedItem.SubItems[col.Index];
                    string typeName = cellItem.Text;
                    ClrType type = dumpModule.ClrDump.GetClrType(typeName);
                    if (type != null)
                    {
                        return new TypeInstancesAddressList(dumpModule.ClrDump, type);
                    }
                    return null;
                }, dumpModule, "All");
                listView.RegisterDataProvider(() =>
                {
                    var cellItem = listView.SelectedItem.SubItems[col.Index];
                    string typeName = cellItem.Text;

                    ClrType type = dumpModule.ClrDump.GetClrType(typeName);
                    if (type != null)
                    {
                        return new ClrDumpType(dumpModule.ClrDump, type);
                    }
                    return null;
                }, dumpModule);
            }
            listView.UseCellFormatEvents = true;
        }

        public static void AddAddressColumn(this ObjectListView listView, AspectGetterDelegate addressGetter, UIClrDumpModule dumpModule)
        {
            var col = new OLVColumn("Address", null) {AspectGetter = addressGetter};

            SetUpAddressColumn(listView, col, dumpModule);
            listView.AllColumns.Add(col);
        }
        public static void SetUpAddressColumn<T>(this ObjectListView listView, UIClrDumpModule dumpModule) where T : IAddressData
        {
            SetUpAddressColumn(listView, nameof(IAddressData.Address), dumpModule);
        }

        public static void SetUpAddressColumn(this ObjectListView listView, string colName, UIClrDumpModule dumpModule)
        {
            var col = listView.AllColumns.First(c => c.Name == colName);
            SetUpAddressColumn(listView, col, dumpModule);
        }

        public static void SetUpAddressColumn(this ObjectListView listView, OLVColumn col, UIClrDumpModule dumpModule)
        {
            col.AspectToStringFormat = "{0:X}";
            col.TextAlign = HorizontalAlignment.Right;
            col.Width = 150;

            listView.CellClick += (o, e) =>
            {
                if (e.ClickCount == 2 && e.Column == col)
                {
                    if( e.Model == null)
                    {
                        return;
                    }
                    var cellItem = listView.SelectedItem?.GetSubItem(col.Index);
                    if( cellItem == null)
                    {
                        return;
                    }
                    var addressObj = cellItem.ModelValue;
                    if (addressObj is ulong)
                    {
                        var address = (ulong)addressObj;
                        var type = dumpModule.ClrDump.GetObjectType(address);
                        var clrDumpObject = new ClrDumpObject(dumpModule.ClrDump, type, address);
                        UIModuleFactory.CreateModule<InstanceDetailsModule>(
                            mod => { mod.UIModuleParent = dumpModule; mod.Setup(clrDumpObject); },
                            mod => mod.RequestDockModule()
                         );
                    }
                }
            };
            listView.RegisterDataProvider( () =>
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
                }, dumpModule
            );
            listView.FormatCell += (o, e) =>
            {
                if( e.Column != col || e.SubItem.ModelValue == null)
                {
                    return;
                }
                var address = (ulong)e.SubItem.ModelValue;
                var bookmark = dumpModule.ClrDump.BookmarkMgr.Get(address);
                if (bookmark != null)
                {
                    e.SubItem.BackColor = bookmark.Color;
                }
            };
            listView.UseCellFormatEvents = true;
            listView.AddMenuSeparator();
        }
        public static void AddSimpleValueColumn(this ObjectListView listView, Func<object, ulong> addressGetter, ClrDump dump, ClrType type)
        {
            if (! dump.IsPrimitive(type) && ! dump.IsString(type))
            {
                return;
            }

            var col = new OLVColumn("Value", null)
            {
                Width = 150
            };

            col.AspectGetter = o =>
            {
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
            col.AspectToStringFormat = "{0:X}";
            listView.AllColumns.Add(col);
        }

        public static void AddSizeColumn(this ObjectListView listView, Func<object, ulong> addressGetter, ClrDump dump, ClrType type)
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
                object result = dump.Eval(
                    () => {
                        return type.GetSize(address);
                    }
                );
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
            var types = WinFwkHelper.GetDerivedTypes(typeof(AbstractTypedUICommand<T>));
            foreach (var type in types)
            {
                var command = Activator.CreateInstance(type, null) as AbstractTypedUICommand<T>;
                command.InitBus(parentModule.MessageBus);
                command.SetSelectedModule(parentModule);
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

        private static void OnMenuItemClick<T>(AbstractTypedUICommand<T> command, Func<T> dataProvider)
        {
            command.Run();
        }

        public static T SelectedObject<T>(this ObjectListView listView) where T : class
        {
            return (listView.SelectedObject) as T;
        }

        public static void AddMenuSeparator(this ObjectListView listView) {
            if( listView.ContextMenuStrip != null)
            {
                listView.ContextMenuStrip.Items.Add("-");
            }
       }
    }
}
