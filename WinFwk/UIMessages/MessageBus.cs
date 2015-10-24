using System;
using System.Collections.Generic;

namespace WinFwk.UIMessages
{
    public class MessageBus
    {
        public event Action<Exception, object> ExceptionRaised;
        private readonly Dictionary<Type, List<object>> dicoSubscribers = new Dictionary<Type, List<object>>();

        static internal IEnumerable<Type> GetMessageTypes(object subscriber)
        {
            List<Type> types = WinFwkHelper.GetGenericInterfaceArguments(subscriber, typeof(IMessageListener<>));
            return types;
        }

        public List<object> GetSubscribers(Type msgType)
        {
            List<object> subscribers;
            if (!dicoSubscribers.TryGetValue(msgType, out subscribers))
            {
                subscribers = new List<object>();
                dicoSubscribers.Add(msgType, subscribers);
            }

            return subscribers;
        }

        public void Subscribe(object subscriber)
        {
            if (subscriber == null)
            {
                return;
            }

            var messageTypes = GetMessageTypes(subscriber);
            foreach (var msgType in messageTypes)
            {
                var subscribers = GetSubscribers(msgType);
                if (!subscribers.Contains(subscriber))
                {
                    subscribers.Add(subscriber);
                }
            }
        }

        public void Unsubscribe(object subscriber)
        {
            if (subscriber == null)
            {
                return;
            }

            var messageTypes = GetMessageTypes(subscriber);
            foreach (var msgType in messageTypes)
            {
                var subscribers = GetSubscribers(msgType);
                if (subscribers.Contains(subscriber))
                {
                    subscribers.Remove(subscriber);
                }
            }
        }

        public void SendMessage<T>(T message) where T : UIMessage
        {
            List<object> subscribers = GetSubscribers(typeof(T));
            if (subscribers.Count == 0)
            {
                return;
            }

            foreach (var subscriber in subscribers)
            {
                IMessageListener<T> sub = subscriber as IMessageListener<T>;
                try
                {
                    sub?.HandleMessage(message);
                }
                catch (Exception e)
                {
                    ExceptionRaised?.Invoke(e, sub);
                }
            }
        }
    }
}
