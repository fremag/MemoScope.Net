using System.Diagnostics;
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

        public void DumpProcess(int processId)
        {
            Channel.DumpMe(processId);
        }

        public void DumpMe()
        {
            DumpProcess(Process.GetCurrentProcess().Id);
        }
    }
}