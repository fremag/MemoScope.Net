using System;
using WinFwk.UIMessages;

namespace WinFwk.UITools.Log
{
    public enum LogLevelType { Debug, Info, Warn, Error, Exception, Notify }
    public class LogMessage : AbstractUIMessage
    {
        public DateTime TimeStamp { get; private set; }
        public LogLevelType LogLevel { get; private set; }
        public string Text { get; private set; }
        public Exception Exception { get; private set; }
        public string LoggerName { get; private set; }

        public LogMessage(object sender, string text, Exception exception) : this(sender, text, LogLevelType.Exception)
        {
            Exception = exception;
        }

        public LogMessage(object sender, string text, LogLevelType logLevel= LogLevelType.Info)
        {
            LoggerName = sender.GetType().Name;
            TimeStamp = DateTime.Now;
            LogLevel = logLevel;
            Text = text;
        }
    }
}
