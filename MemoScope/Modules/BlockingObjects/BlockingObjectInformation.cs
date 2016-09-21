using System.Linq;
using MemoScope.Core;
using BrightIdeasSoftware;
using MemoScope.Core.Data;
using Microsoft.Diagnostics.Runtime;
using System.Collections.Generic;
using WinFwk.UITools;

namespace MemoScope.Modules.BlockingObjects
{
    public class BlockingObjectInformation : IAddressData, ITypeNameData
    {
        public ClrDump ClrDump { get; }
        public BlockingObject BlockingObject { get; }
        public HashSet<int> OwnersId { get; }
        public HashSet<int> WaitersId { get; }

        public BlockingObjectInformation(ClrDump clrDump, BlockingObject blockingObject)
        {
            ClrDump = clrDump;
            BlockingObject = blockingObject;
            
            if (blockingObject.HasSingleOwner && blockingObject.Owner != null)
            {
                OwnersId = new HashSet<int>();
                OwnersId.Add(blockingObject.Owner.ManagedThreadId);
            }
            else
            {
                OwnersId = new HashSet<int>(blockingObject.Owners.Where(thread  => thread != null).Select(thread => thread.ManagedThreadId));
            }
            if (blockingObject.Waiters != null)
            {
                WaitersId = new HashSet<int>(blockingObject.Waiters.Where(thread => thread != null).Select(thread => thread.ManagedThreadId));
            }
            else
            {
                WaitersId = new HashSet<int>();
            }
        }

        [OLVColumn]
        public ulong Address => BlockingObject.Object;

        [OLVColumn]
        public string TypeName => ClrDump.GetObjectTypeName(BlockingObject.Object);

        [IntColumn(Width=50)]
        public int Owners => BlockingObject.HasSingleOwner ? 1 : BlockingObject.Owners.Count;

        [BoolColumn(Width=50)]
        public bool Taken => BlockingObject.Taken;

        [OLVColumn]
        public BlockingReason Reason => BlockingObject.Reason;

        [OLVColumn(IsVisible =false)]
        public int RecursionCount => BlockingObject.RecursionCount;
    }
}