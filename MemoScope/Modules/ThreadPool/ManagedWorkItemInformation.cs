using BrightIdeasSoftware;
using Microsoft.Diagnostics.Runtime;

namespace MemoScope.Modules.ThreadPool
{
    public class ManagedWorkItemInformation
    {
        private ManagedWorkItem workItem;

        public ManagedWorkItemInformation(ManagedWorkItem workItem)
        {
            this.workItem = workItem;
        }

        [OLVColumn]
        public ulong Object => workItem.Object;
        [OLVColumn]
        public string Type => workItem.Type.Name;
    }
}