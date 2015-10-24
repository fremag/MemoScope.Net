using WinFwk.UIMessages;

namespace WinFwk.UIModules
{
    public class ActiveModuleMessage : UIMessage
    {
        public UIModule Module { get; private set; }

        public ActiveModuleMessage(UIModule module)
        {
            Module = module;
        }
    }
}