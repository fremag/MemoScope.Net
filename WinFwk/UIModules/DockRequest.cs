using WeifenLuo.WinFormsUI.Docking;
using WinFwk.UIMessages;

namespace WinFwk.UIModules
{
    public class DockRequest : AbstractUIMessage
    {
        public UIModule UIModule { get; private set; }
        public DockState DockState { get; internal set; }

        public DockRequest(UIModule uiModule, DockState dockState = DockState.Document)
        {
            UIModule = uiModule;
            DockState = dockState;
        }
    }
}