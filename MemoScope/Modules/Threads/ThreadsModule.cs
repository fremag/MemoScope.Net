using MemoScope.Core;
using MemoScope.Core.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace MemoScope.Modules.Threads
{
    public partial class ThreadsModule : UIClrDumpModule
    {
        private List<ThreadInformation> Threads;

        public ThreadsModule()
        {
            InitializeComponent();
        }

        public void Setup(ClrDump clrDump)
        {
            ClrDump = clrDump;
            Icon = Properties.Resources.broom_small;
            Name = $"#{clrDump.Id} - Threads";

            dlvThreads.InitColumns<ThreadInformation>();
        }

        public override void Init()
        {
            base.Init();
            Threads = ClrDump.Threads.Select(thread => new ThreadInformation(ClrDump, thread)).ToList();
        }

        public override void PostInit()
        {
            base.PostInit();
            Summary = $"{Threads.Count} Threads";
            dlvThreads.Objects = Threads;
        }
    }
}
