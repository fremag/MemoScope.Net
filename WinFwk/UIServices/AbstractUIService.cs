using System;
using System.Threading;
using WinFwk.UIMessages;
using WinFwk.UIModules;
using WinFwk.UITools.Log;

namespace WinFwk.UIServices
{
    public abstract class AbstractUIService
    {
        protected MessageBus MessageBus { get; set; }

        public virtual void Init(MessageBus messageBus)
        {
            MessageBus = messageBus;
            MessageBus.Subscribe(this);
        }

        protected void Log(string text, LogLevelType logLevel = LogLevelType.Info)
        {
            MessageBus.Log(this, text, logLevel);
        }

        protected void Log(string text, Exception exception)
        {
            MessageBus.Log(this, text, exception);
        }

        protected void Status(string text, StatusType status = StatusType.Text)
        {
            MessageBus.Status(text, status);
        }

        protected void BeginTask(string text, CancellationTokenSource cancellationTokenSource)
        {
            MessageBus.BeginTask(text, cancellationTokenSource);
        }

        protected void BeginTask(string text)
        {
            MessageBus.BeginTask(text, null);
        }

        protected void EndTask(string text)
        {
            Status(text, StatusType.EndTask);
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
