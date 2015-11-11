using System.Diagnostics;
using System.ServiceModel;
using MemoScopeApi;
using NUnit.Framework;

namespace NUnitTests
{
    [TestFixture]
    public class MemoScopeApiTests
    {
        [Test]
        public void Test()
        {
            var myService = new MockService();
            var processId = 1234;
            MemoScopeServer server = new MemoScopeServer(myService, processId);

            MemoScopeClient client = new MemoScopeClient(processId);
            Debug.WriteLine(server.State);
            client.DumpMe();

            Assert.That(myService.DumpMeReceived, Is.EqualTo(1));
        }
    }

    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    public class MockService : IMemoScopeService
    {
        public int DumpMeReceived { get; private set; }

        public void DumpMe()
        {
            DumpMeReceived ++;
        }
    }
}