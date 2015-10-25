using WinFwk.UIMessages;

namespace WinFwk.UIModules
{
    public class ModuleDocked : AbstractUIMessage
    {
        public UIModule UiModule { get; private set; }

        public ModuleDocked(UIModule uiModule)
        {
            UiModule = uiModule;
        }
    }
}