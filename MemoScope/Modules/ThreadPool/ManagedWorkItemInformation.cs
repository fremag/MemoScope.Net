using BrightIdeasSoftware;
using MemoScope.Core.Data;
using Microsoft.Diagnostics.Runtime;

namespace MemoScope.Modules.ThreadPool
{
    public class ManagedWorkItemInformation : ITypeNameData
    {
        private ManagedWorkItem workItem;

        public ManagedWorkItemInformation(ManagedWorkItem workItem)
        {
            this.workItem = workItem;
        }

        [OLVColumn]
        public ulong Object => workItem.Object;
        [OLVColumn(Title="Type")]
        public string TypeName => workItem.Type.Name;
    }
}