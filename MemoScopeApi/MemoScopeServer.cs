using System;
using System.ServiceModel;

namespace MemoScopeApi
{
    public class MemoScopeServer : ServiceHost
    {
        public MemoScopeServer(IMemoScopeService service) :
            base(service, new Uri("net.pipe://localhost/"))
        {
            AddServiceEndpoint(typeof (IMemoScopeService), new NetNamedPipeBinding(), "memoscope");
            Open();
        }
    }
}