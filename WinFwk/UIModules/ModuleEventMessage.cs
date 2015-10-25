using WinFwk.UIMessages;

namespace WinFwk.UIModules
{
    public enum ModuleEventType
    {
        Added,
        Removed,
        Activated
    }

    public class ModuleEventMessage : AbstractUIMessage
    {
        public UIModule Module { get; private set; }
        public ModuleEventType ModuleEvent { get; private set; }

        public ModuleEventMessage(UIModule module, ModuleEventType moduleEvent)
        {
            Module = module;
            ModuleEvent = moduleEvent;
        }
    }
}