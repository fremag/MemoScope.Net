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
            col.Width = 300;

            listView.UseCellFormatEvents = true;
        }

        public static void AddAddressColumn(this ObjectListView listView, AspectGetterDelegate addressGetter, ClrDump dump, UIModule parentModule)
        {
            var col = new OLVColumn("Address", null) {AspectGetter = addressGetter};

            SetupAddressColumn(listView, col, addressGetter, dump, parentModule);
            listView.AllColumns.Add(col);
        }

        public static void SetUpAddressColumn(this ObjectListView listView, string colName, AspectGetterDelegate addressGetter, ClrDump dump, UIModule parentModule)
        {
            var col = listView.AllColumns.First(c => c.Name == colName);
            SetupAddressColumn(listView, col, addressGetter, dump, parentModule);
        }

        public static void SetupAddressColumn(ObjectListView listView, OLVColumn col, AspectGetterDelegate aspectGetter, ClrDump dump, UIModule parentModule)
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
                    var addressObj = aspectGetter(e.Model);
                    if (addressObj is ulong)
                    {
                        var address = (ulong)addressObj;
                        var type = dump.GetObjectType(address);
                        var clrDumpObject = new ClrDumpObject(dump, type, address);
                        UIModuleFactory.CreateModule<InstanceDetailsModule>(
                            mod => { mod.UIModuleParent = parentModule; mod.Setup(clrDumpObject); },
                            mod => mod.RequestDockModule()
                         );
                    }
                }
            };
            listView.RegisterDataProvider( () =>
                {
                    var selectedObject = listView.SelectedObject;
                    if(selectedObject == null)
                    {
                        return null;
                    }
                    var addressObj = aspectGetter(selectedObject);
                    if (addressObj is ulong)
                    {
                        var address = (ulong)addressObj;
                        var type = dump.GetObjectType(address);
                        var clrDumpObject = new ClrDumpObject(dump, type, address);
                        return clrDumpObject;
                    }
                    return null;
                }, parentModule
            );

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

        public static void RegisterDataProvider<T>(this ObjectListView listView, Func<T> dataProvider, UIModule parentModule)
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
                var menuItem = new ToolStripMenuItem(command.ToolTip);
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

    }
}
