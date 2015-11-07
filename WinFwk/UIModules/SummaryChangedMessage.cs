using WinFwk.UIMessages;

namespace WinFwk.UIModules
{
    public class SummaryChangedMessage : AbstractUIMessage
    {
        public UIModule Module { get; private set; }

        public SummaryChangedMessage(UIModule module)
        {
            Module = module;
        }
    }
}