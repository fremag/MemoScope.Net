using System.ServiceModel;
using System.ServiceModel.Description;

namespace MemoScopeApi
{
    public class MemoScopeClient : ClientBase<IMemoScopeService>
    {
        public MemoScopeClient(int processId)
            : base(new ServiceEndpoint(ContractDescription.GetContract(typeof (IMemoScopeService)),
                new NetNamedPipeBinding(), new EndpointAddress("net.pipe://localhost/memoscope_" + processId)))
        {
        }

        public void DumpMe()
        {
            Channel.DumpMe();
        }
    }
}