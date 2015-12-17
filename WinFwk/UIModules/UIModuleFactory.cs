using System.Threading.Tasks;
using System.Threading;
using System;

namespace WinFwk.UIModules
{
    public static class UIModuleFactory
    {
        private static TaskScheduler UiScheduler { get; set; }
        private static UIMessages.MessageBus MessageBus { get; set; }

        public static void Init(UIMessages.MessageBus messageBus, TaskScheduler uiScheduler)
        {
            MessageBus = messageBus;
            UiScheduler = uiScheduler;
        }

        public static void CreateModule<T>(Action<T> setup, Action<T> finish) where T : UIModule, new()
        {
            T module = null;
            var t0 = Task.Factory.StartNew(() => module = new T(), CancellationToken.None, TaskCreationOptions.None, UiScheduler);
            var t1 = t0.ContinueWith(t => module.InitBus(MessageBus), UiScheduler);
            var t1Bis = t1.ContinueWith(t => setup(module), UiScheduler);
            var t2 = t1Bis.ContinueWith(t => module.Init());
            var t3 = t2.ContinueWith(t => module.PostInit(), UiScheduler);
            var t4 = t3.ContinueWith(t => finish(module), UiScheduler);
        }
    }
}
