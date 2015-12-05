using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using WinFwk.UIMessages;

namespace UnitTestProject
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
        public void DualSendMessageTest()
        {
            MessageBus bus = new MessageBus();
            var singleSub = new MockSingleSubscriber();
            bus.Subscribe(singleSub);
            var dualSub = new MockDualSubscriber();
            bus.Subscribe(dualSub);

            StatusMsg statusMsg = new StatusMsg() {Text = "Test"};
            bus.SendMessage(statusMsg);

            Assert.That(singleSub.StatusMsgs[0], Is.EqualTo(statusMsg));
            Assert.That(dualSub.StatusMsgs[0], Is.EqualTo(statusMsg));

            ResetMsg resetMsg = new ResetMsg() {Reason = "Test2"};
            bus.SendMessage(resetMsg);

            Assert.That(singleSub.StatusMsgs.Count, Is.EqualTo(1));
            Assert.That(dualSub.StatusMsgs.Count, Is.EqualTo(1));

            Assert.That(dualSub.ResetMsgs.Count, Is.EqualTo(1));
        }

        [Test]
        public void ExceptionSendMessageTest()
        {
            MessageBus bus = new MessageBus();
            var failSubscriber = new FailSubscriber();
            bus.Subscribe(failSubscriber);
            Exception e = null;
            bus.ExceptionRaised += (exception, o) => e = exception;

            StatusMsg statusMsg = new StatusMsg() {Text = "Test"};
            bus.SendMessage(statusMsg);

            Assert.That(e, Is.Not.Null);
            Assert.That(e, Is.EqualTo(failSubscriber.Ex));
        }

        [Test]
        public void GetDualMessageTypesTest()
        {
            var l = MessageBus.GetMessageTypes(new MockDualSubscriber()).ToList();
            Assert.That(l, Is.Not.Null);
            Assert.That(l.Count(), Is.EqualTo(2));
            Assert.That(l.ElementAt(0), Is.EqualTo(typeof (StatusMsg)));
            Assert.That(l.Contains(typeof (ResetMsg)), Is.True);
            Assert.That(l.Contains(typeof (StatusMsg)), Is.True);
        }

        [Test]
        public void GetSimpleMessageTypesTest()
        {
            var l = MessageBus.GetMessageTypes(new MockSingleSubscriber()).ToList();
            Assert.That(l, Is.Not.Null);
            Assert.That(l.Count(), Is.EqualTo(1));
            Assert.That(l.ElementAt(0), Is.EqualTo(typeof (StatusMsg)));
        }

        [Test]
        public void SingleSendMessageTest()
        {
            MessageBus bus = new MessageBus();
            var singleSub = new MockSingleSubscriber();

            bus.Subscribe(singleSub);
            StatusMsg statusMsg = new StatusMsg() {Text = "Test"};
            bus.SendMessage(statusMsg);

            Assert.That(singleSub.StatusMsgs.Count, Is.EqualTo(1));
            Assert.That(singleSub.StatusMsgs[0], Is.EqualTo(statusMsg));

            StatusMsg statusMsg2 = new StatusMsg() {Text = "Test2"};
            bus.SendMessage(statusMsg2);

            Assert.That(singleSub.StatusMsgs.Count, Is.EqualTo(2));
            Assert.That(singleSub.StatusMsgs[0], Is.EqualTo(statusMsg));
            Assert.That(singleSub.StatusMsgs[1], Is.EqualTo(statusMsg2));
        }

        [Test]
        public void SubscribeTest()
        {
            MessageBus bus = new MessageBus();
            var singleSub = new MockSingleSubscriber();
            var dualSub = new MockDualSubscriber();

            bus.Subscribe(singleSub);
            var statSubs = bus.GetSubscribers(typeof (StatusMsg));
            Assert.That(statSubs, Is.Not.Null);
            Assert.That(statSubs.Count, Is.EqualTo(1));
            var resetSubs = bus.GetSubscribers(typeof (ResetMsg));
            Assert.That(resetSubs, Is.Not.Null);
            Assert.That(resetSubs.Count, Is.EqualTo(0));

            bus.Subscribe(dualSub);
            statSubs = bus.GetSubscribers(typeof (StatusMsg));
            Assert.That(statSubs.Count, Is.EqualTo(2));
            resetSubs = bus.GetSubscribers(typeof (ResetMsg));
            Assert.That(resetSubs.Count, Is.EqualTo(1));
        }

        [Test]
        public void UnsubscribeTest()
        {
            MessageBus bus = new MessageBus();
            var singleSub = new MockSingleSubscriber();
            var dualSub = new MockDualSubscriber();

            bus.Subscribe(singleSub);
            bus.Subscribe(dualSub);
            bus.Unsubscribe(singleSub);

            var statSubs = bus.GetSubscribers(typeof (StatusMsg));
            var resetSubs = bus.GetSubscribers(typeof (ResetMsg));
            Assert.That(statSubs.Count, Is.EqualTo(1));
            Assert.That(resetSubs.Count, Is.EqualTo(1));

            bus.Unsubscribe(dualSub);
            statSubs = bus.GetSubscribers(typeof (StatusMsg));
            resetSubs = bus.GetSubscribers(typeof (ResetMsg));
            Assert.That(statSubs.Count, Is.EqualTo(0));
            Assert.That(resetSubs.Count, Is.EqualTo(0));
        }
    }

    public class StatusMsg : AbstractUIMessage
    {
        public string Text { get; set; }
    }

    public class ResetMsg : AbstractUIMessage
    {
        public string Reason { get; set; }
    }

    public class MockSingleSubscriber : IMessageListener<StatusMsg>
    {
        public List<StatusMsg> StatusMsgs { get; } = new List<StatusMsg>();

        void IMessageListener<StatusMsg>.HandleMessage(StatusMsg message)
        {
            StatusMsgs.Add(message);
        }
    }

    public class MockDualSubscriber : MockSingleSubscriber, IMessageListener<ResetMsg>
    {
        public List<ResetMsg> ResetMsgs { get; } = new List<ResetMsg>();

        void IMessageListener<ResetMsg>.HandleMessage(ResetMsg message)
        {
            ResetMsgs.Add(message);
        }
    }

    public class FailSubscriber : IMessageListener<StatusMsg>
    {
        public Exception Ex = new ArgumentNullException();

        void IMessageListener<StatusMsg>.HandleMessage(StatusMsg message)
        {
            throw Ex;
        }
    }
}