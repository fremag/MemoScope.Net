using MemoScope.Core.Data;
using System;
using System.Windows.Forms;
using WinFwk.UIModules;

namespace MemoScope.Modules.Instances
{
    public class TypeInstancesModule : InstancesModule
    {
        public static void Create(ClrDumpType clrDumpType, UIModule parent, Action<InstancesModule> postInit)
        {
            if (clrDumpType == null)
            {
                MessageBox.Show("No type selected !", "Error", MessageBoxButtons.OK);
                return;
            }
            UIModuleFactory.CreateModule<TypeInstancesModule>(
                mod => { mod.UIModuleParent = parent; mod.Setup(clrDumpType); },
                mod => postInit(mod)
                );
        }

        TypeInstancesAddressList addressList;
        public TypeInstancesModule()
        {
            Icon = Properties.Resources.scroll_pane_list_small;
        }

        internal void Setup(ClrDumpType clrDumpType)
        {
            addressList = new TypeInstancesAddressList(clrDumpType);
            Setup(addressList);
        }

        public override void Init()
        {
            addressList.Init();
            base.Init();
        }
    }
}
