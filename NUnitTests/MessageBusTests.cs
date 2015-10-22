using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using WinFwk;

namespace NUnitTests
{
    [TestFixture]
    public class MessageBusTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [TearDown] 
        public void Teardown()
        {

        }

        [Test]
        public void GetSimpleMessageTypesTest()
        {
            var l = MessageBus.GetMessageTypes(new MockSimpleSubscriber()).ToList();
            Assert.That(l, Is.Not.Null);
            Assert.That(l.Count(), Is.EqualTo(1));
            Assert.That(l.ElementAt(0), Is.EqualTo(typeof(StatusMsg)));
        }

        [Test]
        public void GetDualMessageTypesTest()
        {
            var l = MessageBus.GetMessageTypes(new MockDualSubscriber()).ToList();
            Assert.That(l, Is.Not.Null);
            Assert.That(l.Count(), Is.EqualTo(2));
            Assert.That(l.ElementAt(0), Is.EqualTo(typeof(StatusMsg)));
            Assert.That(l.Contains(typeof(ResetMsg)), Is.True);
            Assert.That(l.Contains(typeof(StatusMsg)), Is.True);
        }

    }

    public class StatusMsg
    {
        public string Text { get; set; }
    }

    public class ResetMsg
    {
        public string Reason { get; set; }
    }

    public class MockSimpleSubscriber : IMessageListener<StatusMsg>
    {
        public List<StatusMsg> StatusMsgs { get; } = new List<StatusMsg>();
        void IMessageListener<StatusMsg>.HandleMessage(StatusMsg message)
        {
            StatusMsgs.Add(message);
        }
    }

    public class MockDualSubscriber : MockSimpleSubscriber , IMessageListener<ResetMsg>
    {
        public List<ResetMsg> ResetMsgs { get; } = new List<ResetMsg>();
        void IMessageListener<ResetMsg>.HandleMessage(ResetMsg message)
        {
            ResetMsgs.Add(message);
        }
    }
}
