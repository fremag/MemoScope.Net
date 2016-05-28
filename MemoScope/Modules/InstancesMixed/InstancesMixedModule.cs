using System.Collections.Generic;
using MemoScope.Core;
using MemoScope.Core.Helpers;
using MemoScope.Core.Data;
using System.Windows.Forms;
using WinFwk.UIModules;
using System;

namespace MemoScope.Modules.InstancesMixed
{
    public partial class InstancesMixedModule : UIClrDumpModule
    {
        IAddressContainer Instances { get; set; }
        public List<InstanceInformation> InstancesInformation { get; private set; }

        public InstancesMixedModule()
        {
            InitializeComponent();
        }

        public void Setup(ClrDump clrDump, IAddressContainer instances, UIClrDumpModule parentModule=null)
        {
            ClrDump = clrDump;
            Instances = instances;
            Icon = Properties.Resources.formatting_dublicate_value_small;
            Name = $"#{ClrDump.Id}";

            dlvInstances.InitColumns<InstanceInformation>();
            dlvInstances.SetUpAddressColumn<InstanceInformation>(parentModule ?? this);
            dlvInstances.SetUpTypeColumn<InstanceInformation>(parentModule ?? this);
            dlvInstances.AddSizeColumn(o => ((InstanceInformation)o).Address, ClrDump, o => ((InstanceInformation)o).ClrType);
            dlvInstances.AddSimpleValueColumn(o => ((InstanceInformation)o).Address, ClrDump, o => ((InstanceInformation)o).ClrType);
            dlvInstances.RebuildColumns();
            dlvInstances.SetTypeNameFilter<InstanceInformation>(regexFilterControl);
        }

        public override void PostInit()
        {
            base.PostInit();
            dlvInstances.Objects = InstancesInformation;
            Summary = $"{InstancesInformation.Count:###,###,###,##0} instances" ;
        }

        public override void Init()
        {
            InstancesInformation = new List<InstanceInformation>(Instances.Count);

            for (int i = 0; i < Instances.Count; i++)
            {
                var address = Instances[i];
                InstancesInformation.Add(new InstanceInformation(ClrDump, address));
            }
        }

        public static void Create(ClrDump clrDump, IAddressContainer addresses, UIModule parent, Action<InstancesMixedModule> postInit, string name = null)
        {
            if (addresses == null)
            {
                MessageBox.Show("No instances selected !", "Error", MessageBoxButtons.OK);
                return;
            }
            UIModuleFactory.CreateModule<InstancesMixedModule>(
                mod => {
                    mod.UIModuleParent = parent; mod.Setup(clrDump, addresses);
                    if (name != null)
                    {
                        mod.Name = name;
                    }
                },
                mod => postInit(mod)
                );
        }
    }
}
