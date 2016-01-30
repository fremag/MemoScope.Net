using MemoScope.Core;
using MemoScope.Core.Helpers;
using Microsoft.Diagnostics.Runtime;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using WinFwk.UICommands;
using System;
using MemoScope.Modules.StackTrace;

namespace MemoScope.Modules.Threads
{
    public partial class ThreadsModule : UIClrDumpModule, UIDataProvider<ClrDumpThread>
    {
        private List<ThreadInformation> Threads;

        public ThreadsModule()
        {
            InitializeComponent();
        }

        public void Setup(ClrDump clrDump)
        {
            ClrDump = clrDump;
            Icon = Properties.Resources.processor_small;
            Name = $"#{clrDump.Id} - Threads";

            dlvThreads.InitColumns<ThreadInformation>();
            dlvThreads.SetUpAddressColumn<ThreadInformation>(this);
            dlvThreads.SelectedIndexChanged += (s, e) =>
            {
                var thread = dlvThreads.SelectedObject<ThreadInformation>();
                if( thread == null)
                {
                    return;
                }
                stackTraceModule.Init(thread);
                stackTraceModule.PostInit();
            };
            stackTraceModule.Setup(clrDump);
        }

        public override void Init()
        {
            base.Init();

            Threads = ClrDump.Threads.Select(thread =>
            {
                var threadInfo = new ThreadInformation(ClrDump, thread);
                ThreadProperty threadProp;
                if( ClrDump.ThreadProperties.TryGetValue(thread.ManagedThreadId, out threadProp))
                {
                    threadInfo.Address = threadProp.Address;
                    threadInfo.Name = threadProp.Name;
                    threadInfo.Priority = threadProp.Priority;
                }
                return threadInfo;
            }).ToList();
        }
        public ClrDumpThread Data
        {
            get
            {
                var thread = dlvThreads.SelectedObject<ThreadInformation>();
                if( thread == null)
                {
                    return null;
                }
                return new ClrDumpThread(thread.ClrDump, thread.Thread, thread.Name);
            }
        }

    public override void PostInit()
        {
            base.PostInit();
            Summary = $"{Threads.Count} Threads";
            dlvThreads.Objects = Threads;
        }
    }
}
