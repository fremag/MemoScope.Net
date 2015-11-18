using System;
using WinFwk.UIMessages;

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
