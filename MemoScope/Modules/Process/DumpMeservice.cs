using System;
using System.ServiceModel;
using MemoScopeApi;

namespace MemoScope.Modules.Process
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    public class MemoScopeService : IMemoScopeService
    {
        public static MemoScopeService Instance { get; set; }

        public event Action<int> DumpRequested;

        static MemoScopeService()
        {
            Instance = new MemoScopeService();
        }

        private MemoScopeService()
        {
            
        }
        public void DumpMe(int processId)
        {
            DumpRequested?.Invoke(processId);
        }
    }
}
