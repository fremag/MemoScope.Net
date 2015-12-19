using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WinFwk.UITools;

namespace WinFwk.UIMessages
{
    public class MessageBus
    {
        private readonly Dictionary<Type, List<object>> dicoSubscribers = new Dictionary<Type, List<object>>();
        private TaskScheduler uiScheduler;
        private TaskFactory taskFactory;
        public event Action<Exception, object> ExceptionRaised;

        public TaskScheduler UiScheduler
        {
            get { return uiScheduler; }
            set
            {
                uiScheduler = value;
                taskFactory = new TaskFactory(value);
            }
        }

        internal static IEnumerable<Type> GetMessageTypes(object subscriber)
        {
            List<Type> types = WinFwkHelper.GetGenericInterfaceArguments(subscriber, typeof (IMessageListener<>));
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

        public void SendMessage<T>(T message) where T : AbstractUIMessage
        {
            List<object> subscribers = GetSubscribers(typeof (T));
            if (subscribers.Count == 0)
            {
                return;
            }

            Type interfaceType = typeof(IMessageListener<T>);
            foreach (var subscriber in subscribers)
            {
                IMessageListener<T> sub = subscriber as IMessageListener<T>;
                if (sub == null)
                {
                    // this should not happen !
                    continue;
                }

                Type subscriberType = subscriber.GetType();
                var map = subscriberType.GetInterfaceMap(interfaceType);
                bool sched = false;
                foreach (var m in map.TargetMethods)
                {
                    var x= m.GetCustomAttributes(typeof(UIScheduler));
                    sched = x.Any();
                }

                try
                {
                    //Debug.WriteLine(subscriberType+", "+interfaceType+" : "+sched);
                    if (sched)
                    {
                        taskFactory.StartNew(() => sub.HandleMessage(message));
                    }
                    else
                    {
                        sub.HandleMessage(message);
                    }
                }
                catch (Exception e)
                {
                    ExceptionRaised?.Invoke(e, sub);
                }
            }
        }
    }
}