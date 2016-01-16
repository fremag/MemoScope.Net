using MemoScope.Core;
using System.Collections.Generic;
using System.Linq;

namespace MemoScope.Modules.Modules
{
    public partial class ModulesModule : UIClrDumpModule
    {
        private List<ModuleInformation> Modules;
        public ModulesModule()
        {
            InitializeComponent();
        }

        public void Setup(ClrDump clrDump)
        {
            ClrDump = clrDump;
            Icon = Properties.Resources.module_small;
            Name = $"#{clrDump.Id} - Modules";

            dlvModules.InitColumns<ModuleInformation>();
        }

        public override void Init()
        {
            base.Init();
            Modules = ClrDump.Modules.Select(mod=> new ModuleInformation(ClrDump, mod)).ToList();
        }

        public override void PostInit()
        {
            base.PostInit();
            Summary = $"{Modules.Count} Modules";
            dlvModules.Objects = Modules;
        }
    }
}
