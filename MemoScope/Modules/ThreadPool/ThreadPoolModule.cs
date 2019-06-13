using System;
using MemoScope.Core;
using MemoScope.Core.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace MemoScope.Modules.ThreadPool
{
    public partial class ThreadPoolModule : UIClrDumpModule
    {
        private ThreadPoolInformation ThreadPoolInformation;

        public List<NativeWorkItemInformation> NativeWorkItems { get; private set; }
        public List<ManagedWorkItemInformation> ManagedWorkItems { get; private set; }

        public ThreadPoolModule()
        {
            InitializeComponent();
        }

        public void Setup(ClrDump clrDump)
        {
            ClrDump = clrDump;
            Icon = Properties.Resources.candlestickchart_small;
            Name = $"#{clrDump.Id} - ThreadPool";
            dlvNativeWorkItem.InitColumns<NativeWorkItemInformation>();
            dlvNativeWorkItem.SetUpAddressColumn(nameof(NativeWorkItemInformation.Data), this);
            dlvManagedWorkItem.InitColumns<ManagedWorkItemInformation>();
            dlvManagedWorkItem.SetUpAddressColumn(nameof(ManagedWorkItemInformation.Object), this);
            dlvManagedWorkItem.SetUpTypeColumn<ManagedWorkItemInformation>(this);
        }

        public override void Init()
        {
            ThreadPoolInformation = new ThreadPoolInformation(ClrDump, ClrDump.ThreadPool);
            NativeWorkItems = ClrDump.ThreadPool.EnumerateNativeWorkItems().Select(workItem => new NativeWorkItemInformation(workItem)).ToList();

            try
            {
                ManagedWorkItems = ClrDump.ThreadPool.EnumerateManagedWorkItems().Select(workItem => new ManagedWorkItemInformation(workItem)).ToList();
            }
            catch (Exception)
            {
                // ClrMd does not yet support EnumerateManagedWorkItems with .net core dumps
                // see: https://github.com/Microsoft/clrmd/issues/131
                ManagedWorkItems = null;
            }
        }

        public override void PostInit()
        {
            pgThreadPool.SelectedObject = ThreadPoolInformation;
            dlvNativeWorkItem.Objects = NativeWorkItems;
            dlvManagedWorkItem.Objects = ManagedWorkItems;
            Summary = $"ThreadPool";
        }
    }
}
