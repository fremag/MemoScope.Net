using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using WinFwk.UIMessages;
using WinFwk.UITools.Log;

namespace WinFwk.UIModules
{
    public class UIModule : UserControl
    {
        private string summary;
        public MessageBus MessageBus { get; private set; }
        public Bitmap Icon { get; protected set; }

        public string Summary
        {
            get { return summary; }
            protected set
            {
                summary = value; 
                if(MessageBus!=null) MessageBus.SendMessage(new SummaryChangedMessage(this));
            }
        }

        public UIModule UIModuleParent { get; set; }

        public UIModule()
        {
            UIModuleParent = this;
        }

        public virtual void Init()
        {

        }
        public virtual void PostInit()
        {

        }

        public void InitBus(MessageBus bus)
        {
            MessageBus = bus;
            MessageBus.Subscribe(this);
        }

        protected void Status(string text, StatusType status = StatusType.Text )
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

        protected void Log(string text, LogLevelType logLevel = LogLevelType.Info)
        {
            MessageBus.SendMessage(new LogMessage(this, text, logLevel));
        }

        protected void Log(string text, Exception exception)
        {
            MessageBus.SendMessage(new LogMessage(this, text, exception));
        }

        public void RequestDockModule(UIModule uiModule)
        {
            MessageBus.SendMessage(new DockRequest(uiModule));
        }
        public void RequestDockModule()
        {
            RequestDockModule(this);
        }
    }
}