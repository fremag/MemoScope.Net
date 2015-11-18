using System;
using WinFwk.UIMessages;
using WinFwk.UITools.Log;

namespace WinFwk.UIServices
{
    public abstract class AbstractUIService
    {
        private MessageBus MessageBus { get; set; }

        public virtual void Init(MessageBus messageBus)
        {
            MessageBus = messageBus;
            MessageBus.Subscribe(this);
        }

        protected void Log(string text, LogLevelType logLevel = LogLevelType.Info)
        {
            MessageBus.SendMessage(new LogMessage(this, text, logLevel));
        }

        protected void Log(string text, Exception exception)
        {
            MessageBus.SendMessage(new LogMessage(this, text, exception));
        }

    }

    public static class UIServiceHelper
    {
        public static void InitServices(MessageBus messageBus)
        {
            var types = WinFwkHelper.GetDerivedTypes(typeof (AbstractUIService));
            foreach (var type in types)
            {
                var constructor = type.GetConstructor(Type.EmptyTypes);
                var service = constructor?.Invoke(null) as AbstractUIService;
                if (service != null)
                {
                    service.Init(messageBus);
                }
            }
        }
    }
}
