using WinFwk.UIMessages;

namespace WinFwk.UIModules
{
    public class ActiveModuleMessage : AbstractUIMessage
    {
        public UIModule Module { get; private set; }

        public ActiveModuleMessage(UIModule module)
        {
            Module = module;
        }
    }
}