using System.Threading.Tasks;
using System.Threading;
using System;
using WinFwk.UITools.Log;

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
            var t1Bis = t1.ContinueWith(t => Setup(module, setup), UiScheduler);
            var t2 = t1Bis.ContinueWith(t => InitModule(module));
            var t3 = t2.ContinueWith(t => PostInit(module), UiScheduler);
            var t4 = t3.ContinueWith(t => Finish(module, finish), UiScheduler);
        }

        private static void Finish<T>(T module, Action<T> finish) where T : UIModule, new()
        {
            try
            {
                finish(module);
            }
            catch (Exception ex)
            {
                MessageBus.Log(module, "Failed to finish module", ex);
            }
        }

        private static void PostInit<T>(T module) where T : UIModule, new()
        {
            try
            {
                module.PostInit();
            }
            catch (Exception ex)
            {
                MessageBus.Log(module, "Failed to post init module", ex);
            }
        }

        private static void InitModule<T>(T module) where T : UIModule, new()
        {
            try
            {
                module.Init();
            }
            catch (Exception ex)
            {
                MessageBus.Log(module, "Failed to init module", ex);
            }
        }

        private static void Setup<T>(T module, Action<T> setup) where T : UIModule, new()
        {
            try
            {
                setup(module);
            }
            catch (Exception ex)
            {
                MessageBus.Log(module, "Failed to setup module", ex);
            }
        }
    }
}
