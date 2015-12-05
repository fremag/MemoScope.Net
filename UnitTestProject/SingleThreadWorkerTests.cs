using System.Threading;
using MemoScope.Core;
using NUnit.Framework;

namespace UnitTestProject
{
    [TestFixture]
    public class SingleThreadWorkerTests
    {
        [Test]
        public void RunAsyncTest()
        {
            using (SingleThreadWorker worker = new SingleThreadWorker("Test"))
            {
                string msg = null;
                bool done = false;

                worker.RunAsync(() => { msg = "Yo !"; }, () => { done = true; });

                Thread.Sleep(100);

                Assert.That(msg, Is.EqualTo("Yo !"));
                Assert.That(done, Is.True);
            }
        }

        [Test]
        public void RunTest()
        {
            SingleThreadWorker worker = new SingleThreadWorker("Test");
            string msg = null;
            worker.Run(() => msg = "Yo !");
            Assert.That(msg, Is.EqualTo("Yo !"));
            worker.Run(() => msg = "Yo !!!");
            Assert.That(msg, Is.EqualTo("Yo !!!"));
        }
    }
}