using System;
using System.Collections.Generic;

namespace WinFwk
{
    public interface IMessageListener<T>
    {
        void HandleMessage(T message);
    }

    public class MessageBus
    {
        Dictionary<Type, List<object>> dicoSubscribers = new Dictionary<Type, List<object>>();
        static internal IEnumerable<Type> GetMessageTypes(object subscriber)
        {
            List<Type> types = new List<Type>();

            if (subscriber == null)
            {
                return types;
            }

            Type type = subscriber.GetType();
            var interfaces = type.GetInterfaces();
            foreach (var interfType in interfaces)
            {
                if (interfType.IsGenericType && interfType.GetGenericTypeDefinition().IsAssignableFrom(typeof(IMessageListener<>)))
                {
                    var genArgs = interfType.GetGenericArguments();
                    foreach (var genArg in genArgs)
                    {
                        types.Add(genArg);
                    }
                }
            }
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
            if(subscriber == null)
            {
                return;
            }

            var messageTypes = GetMessageTypes(subscriber);
            foreach(var msgType in messageTypes)
            {
                var subscribers = GetSubscribers(msgType);
                if( ! subscribers.Contains(subscriber)  )
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
                if (!subscribers.Contains(subscriber))
                {
                    subscribers.Remove(subscriber);
                }
            }
        }
    }
}
