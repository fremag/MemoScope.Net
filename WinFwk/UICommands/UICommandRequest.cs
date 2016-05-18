using WinFwk.UIMessages;

namespace WinFwk.UICommands
{
    public class UICommandRequest : AbstractUIMessage
    {
        public IUICommandRequestor Requestor { get; }
        public UICommandRequest(IUICommandRequestor requestor)
        {
            Requestor = requestor;
        }
    }
}
