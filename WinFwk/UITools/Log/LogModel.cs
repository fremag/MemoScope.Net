using System;

namespace WinFwk.UITools.Log
{
    public class LogModel : DefaultModel<LogMessage>
    {
        
        public DateTime GetTimeStamp(object o)
        {
            return GetObject(o).TimeStamp;
        }

        public LogLevelType GetLogLevel(object o)
        {
            return GetObject(o).LogLevel;
        }

        public object GetText(object o)
        {
            return GetObject(o).Text;
        }

        public object GetException(object o)
        {
            return GetObject(o).Exception;
        }

    }
}