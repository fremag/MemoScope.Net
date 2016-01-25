using MemoScope.Core;
using MemoScope.Core.Helpers;
using Microsoft.Diagnostics.Runtime;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

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
            dlvThreads.SetUpAddressColumn<ThreadInformation>(this);
        }

        public override void Init()
        {
            base.Init();
            ClrType threadType = ClrDump.GetClrType(typeof(Thread).FullName);
            var threadsInstances = ClrDump.GetInstances(threadType);
            var nameField = threadType.GetFieldByName("m_Name");
            var priorityField = threadType.GetFieldByName("m_Priority");
            var idField = threadType.GetFieldByName("m_ManagedThreadId");
            Dictionary<int, ThreadProperty> properties = new Dictionary<int, ThreadProperty>();
            foreach(ulong threadAddress in threadsInstances)
            {
                string name = (string)ClrDump.GetFieldValue(threadAddress, threadType, nameField);
                int priority = (int)ClrDump.GetFieldValue(threadAddress, threadType, priorityField);
                int id = (int)ClrDump.GetFieldValue(threadAddress, threadType, idField);
                properties[id] = new ThreadProperty { Address = threadAddress,  ManagedId = id, Priority = priority, Name = name };
            }

            Threads = ClrDump.Threads.Select(thread =>
            {
                var threadInfo = new ThreadInformation(ClrDump, thread);
                ThreadProperty threadProp;
                if( properties.TryGetValue(thread.ManagedThreadId, out threadProp))
                {
                    threadInfo.Address = threadProp.Address;
                    threadInfo.Name = threadProp.Name;
                    threadInfo.Priority = threadProp.Priority;
                }
                return threadInfo;
            }).ToList();
        }

    internal class ThreadProperty
    {
        public ulong Address { get; set; }
        public string Name { get; set; }
        public int Priority { get;  set; }
        public int ManagedId { get; set; }
    }

    public override void PostInit()
        {
            base.PostInit();
            Summary = $"{Threads.Count} Threads";
            dlvThreads.Objects = Threads;
        }
    }
}
