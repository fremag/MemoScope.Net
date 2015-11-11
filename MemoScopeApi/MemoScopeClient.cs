using System.ServiceModel;
using System.ServiceModel.Description;

namespace MemoScopeApi
{
    public class MemoScopeClient : ClientBase<IMemoScopeService>
    {
        public MemoScopeClient()
            : base(new ServiceEndpoint(ContractDescription.GetContract(typeof (IMemoScopeService)),
                new NetNamedPipeBinding(), new EndpointAddress("net.pipe://localhost/memoscope")))
        {
        }

        public void DumpMe(int processId)
        {
            Channel.DumpMe(processId);
        }
    }
}