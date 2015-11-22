using WinFwk.UIMessages;

namespace WinFwk.UIModules
{
    public enum StatusType { BeginTask, EndTask, Text }
    public class StatusMessage : AbstractUIMessage
    {
        public StatusType Status { get; private set; }
        public string Text { get; private set; }

        public StatusMessage(string text, StatusType status = StatusType.Text)
        {
            Status = status;
            Text = text;
        }
    }

    public static class StatusMessageHelper {
        public static void Status(this MessageBus msgBus, string text, StatusType status = StatusType.Text)
        {
            msgBus.SendMessage(new StatusMessage(text, status));
        }
    }
}
