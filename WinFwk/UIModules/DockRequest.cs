using WinFwk.UIMessages;

namespace WinFwk.UIModules
{
    public class DockRequest : AbstractUIMessage
    {
        public UIModule UIModule { get; private set; }

        public DockRequest(UIModule uiModule)
        {
            UIModule = uiModule;
        }
    }
}