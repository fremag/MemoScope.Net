using NUnit.Framework;
using System.Collections.Generic;
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
        public void teardown()
        {

        }

        [Test]
        public void GetMessageTypesTest()
        {
            var l = MessageBus.GetMessageTypes(new MockSimpleSubscriber());
            Assert.That(l, Is.Not.Null);

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

    public class MockdualSubscriber : MockSimpleSubscriber , IMessageListener<ResetMsg>
    {
        public List<ResetMsg> ResetMsgs { get; } = new List<ResetMsg>();
        void IMessageListener<ResetMsg>.HandleMessage(ResetMsg message)
        {
            ResetMsgs.Add(message);
        }
    }
}
