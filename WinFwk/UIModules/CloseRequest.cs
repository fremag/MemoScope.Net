using WinFwk.UIMessages;

namespace WinFwk.UIModules
{
    public class CloseRequest : AbstractUIMessage
    {
        public UIModule Module { get; private set; }

        public CloseRequest(UIModule module)
        {
            Module = module;
        }
    }
}