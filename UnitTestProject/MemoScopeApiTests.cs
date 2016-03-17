using System.Diagnostics;
using System.ServiceModel;
using MemoScopeApi;
using NUnit.Framework;

namespace UnitTestProject
{
    [TestFixture]
    public class MemoScopeApiTests
    {
        [Test]
        public void DumpRequestTest()
        {
            var myService = new MockService();
            var processId = 1234;
            MemoScopeServer server = new MemoScopeServer(myService);

            MemoScopeClient client = new MemoScopeClient();
            Debug.WriteLine(server.State);
            client.DumpProcess(processId);

            Assert.That(myService.DumpMeReceived, Is.EqualTo(1));
        }
    }

    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    public class MockService : IMemoScopeService
    {
        public int DumpMeReceived { get; private set; }

        public void DumpMe(int processId)
        {
            DumpMeReceived ++;
        }
    }
}