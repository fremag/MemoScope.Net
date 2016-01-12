using System.Threading;
using WinFwk.UIMessages;

namespace WinFwk.UIModules
{
    public enum StatusType { BeginTask, EndTask, Text }
    public class StatusMessage : AbstractUIMessage
    {
        public StatusType Status { get; }
        public string Text { get; }
        public CancellationTokenSource CancellationTokenSource { get; }
        public StatusMessage(string text, StatusType status = StatusType.Text)
        {
            Status = status;
            Text = text;
            CancellationTokenSource = null;
        }
        public StatusMessage(string text, CancellationTokenSource cancellationTokenSource) : this (text, StatusType.BeginTask)
        {
            CancellationTokenSource = cancellationTokenSource;
        }
    }

    public static class StatusMessageHelper {
        public static void Status(this MessageBus msgBus, string text, StatusType status = StatusType.Text)
        {
            msgBus.SendMessage(new StatusMessage(text, status));
        }
        public static void BeginTask(this MessageBus msgBus, string text, CancellationTokenSource cancellationTokenSource=null)
        {
            msgBus.SendMessage(new StatusMessage(text, cancellationTokenSource));
        }
        public static void EndTask(this MessageBus msgBus, string text)
        {
            Status(msgBus, text, StatusType.EndTask);
        }
    }
}
