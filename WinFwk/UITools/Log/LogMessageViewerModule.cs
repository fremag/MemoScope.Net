using System.Reflection;
using WinFwk.UIModules;

namespace WinFwk.UITools.Log
{
    public partial class LogMessageViewerModule : UIModule
    {
        public LogMessageViewerModule()
        {
            InitializeComponent();
        }

        public void Init(LogMessage logMessage)
        {
            tbTimeStamp.Text = logMessage.TimeStamp.ToString("HH:mm:ss");
            tbLevel.Text = logMessage.LogLevel.ToString();
            tbText.Text = logMessage.Text;

            var exception = logMessage.Exception;
            if (exception != null)
            {
                tbType.Text = exception.GetType().FullName;
                tbMessage.Text = exception.Message;
                tbStackTrace.Text = exception.StackTrace;
            }

            Name = tbTimeStamp.Text;
            Summary = tbLevel.Text;
        }
    }
}