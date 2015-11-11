using System.ServiceModel;

namespace MemoScopeApi
{
    [ServiceContract]
    public interface IMemoScopeService
    {
        [OperationContract]
        void DumpMe(int processId);
    }
}