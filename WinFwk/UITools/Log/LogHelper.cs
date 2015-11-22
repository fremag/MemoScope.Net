using System;
using WinFwk.UIMessages;

namespace WinFwk.UITools.Log
{
    public static class LogHelper
    {
        public static void Log(this MessageBus msgBus, object sender, string text, LogLevelType logLevel = LogLevelType.Info)
        {
            msgBus.SendMessage(new LogMessage(sender, text, logLevel));
        }

        public static void Log(this MessageBus msgBus, object sender, string text, Exception exception)
        {
            msgBus.SendMessage(new LogMessage(sender, text, exception));
        }
    }
}
