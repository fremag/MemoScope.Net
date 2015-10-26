using WinFwk.UIMessages;

namespace WinFwk.UIModules
{
    public class ActivationRequest : AbstractUIMessage
    {
        public UIModule Module { get; private set; }

        public ActivationRequest(UIModule module)
        {
            Module = module;
        }
    }
}