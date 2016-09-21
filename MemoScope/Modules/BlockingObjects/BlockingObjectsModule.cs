using MemoScope.Core;
using MemoScope.Core.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MemoScope.Modules.BlockingObjects
{
    public partial class BlockingObjectsModule : UIClrDumpModule
    {
        private List<BlockingObjectInformation> BlockingObjects { get; set; }
        private List<ThreadProperty> Threads { get; set; }

        public BlockingObjectsModule()
        {
            InitializeComponent();
        }

        public void Setup(ClrDump clrDump)
        {
            ClrDump = clrDump;
            Icon = Properties.Resources._lock_small;
            Name = $"#{clrDump.Id} - BlockingObjects";
            dlvBlockingObjects.InitColumns<BlockingObjectInformation>();
            dlvBlockingObjects.SetUpAddressColumn<BlockingObjectInformation>(this);
            dlvBlockingObjects.SetUpTypeColumn<BlockingObjectInformation>(this);
            dlvBlockingObjects.SetTypeNameFilter<BlockingObjectInformation>(regexFilterControl);
        }

        public override void Init()
        {
            base.Init();
            var objs = ClrDump.GetBlockingObjects();
            BlockingObjects = objs.Select( blockingObject => new BlockingObjectInformation(ClrDump, blockingObject)).ToList();
            Threads = ClrDump.ThreadProperties.Values.ToList();
        }

        public override void PostInit()
        {
            base.PostInit();
            foreach (var thread in Threads)
            {
                dlvBlockingObjects.AllColumns.Add(new ThreadColumn(thread));
            }
            dlvBlockingObjects.RebuildColumns();
            Summary = $"{BlockingObjects.Count} objects, {Threads.Count} threads";
            dlvBlockingObjects.Objects = BlockingObjects;
            dlvBlockingObjects.BuildGroups(nameof(BlockingObjectInformation.Taken), SortOrder.Descending) ;
            dlvBlockingObjects.ShowGroups = true;
        }
    }
}
