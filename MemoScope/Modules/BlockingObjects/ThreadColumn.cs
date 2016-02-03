using BrightIdeasSoftware;
using MemoScope.Core;
using System.Windows.Forms;

namespace MemoScope.Modules.BlockingObjects
{
    internal class ThreadColumn : OLVColumn
    {
        private ThreadProperty thread;

        public ThreadColumn(ThreadProperty thread)
        {
            this.thread = thread;
            ImageGetter = GetData;
            Name = $"THREAD_{thread.ManagedId} - {thread.Name}";
            Text = $"{thread.ManagedId} - {thread.Name}";
            ToolTipText = Text;
            TextAlign = HorizontalAlignment.Center;
        }

        private object GetData(object rowObject)
        {
            var blockingObjectInfo = rowObject as BlockingObjectInformation;
            if( blockingObjectInfo == null)
            {
                return null;
            }
            if (blockingObjectInfo.OwnersId.Contains(thread.ManagedId))
            {
                return Properties.Resources._lock_small;
            }
            if (blockingObjectInfo.WaitersId.Contains(thread.ManagedId))
            {
                return Properties.Resources.hourglass;
            }
            return null;
        }
    }
}