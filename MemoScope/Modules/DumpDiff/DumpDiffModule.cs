using MemoScope.Core;
using System.Collections.Generic;
using WinFwk.UIModules;

namespace MemoScope.Modules.DumpDiff
{
    public partial class DumpDiffModule : UIModule
    {
        private List<ClrDump> ClrDumps { get; set; }
        public DumpDiffModule()
        {
            InitializeComponent();
        }

        public void Setup(List<ClrDump> clrDumps)
        {
            ClrDumps = clrDumps;
            Icon = Properties.Resources.subtotal_small;
            Name = $"Dump diff";

        }

        public override void Init()
        {
            base.Init();
        }

        public override void PostInit()
        {
            base.PostInit();
            Summary = $"";
        }
    }
}
