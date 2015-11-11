using System.Drawing;
using System.Windows.Forms;
using WinFwk.UIMessages;
using WinFwk.UIModules;

namespace WinFwk.UICommands
{
    public abstract class AbstractUICommand
    {
        // Properties
        public string Name { get; private set; }
        public string Group { get; private set; }
        public string ToolTip { get; private set; }
        public Image Icon { get; private set; }
        public bool Enabled { get; protected set; }
        public MessageBus MessageBus { get; private set; }
        public Keys Shortcut { get; private set; }

        protected AbstractUICommand(string name, string toolTip, string group, Image icon, Keys shortcut=Keys.None)
        {
            Name = name;
            ToolTip = toolTip;
            Group = group;
            Icon = icon;
            Shortcut = shortcut;
        }

        public abstract void SetSelectedModule(UIModule module);
        public abstract void Run();

        public void InitBus(MessageBus msgBus)
        {
            MessageBus = msgBus;
            MessageBus.Subscribe(this);
        }

        protected void DockModule(UIModule uiModule)
        {
            MessageBus.SendMessage(new DockRequest(uiModule));
        }

        public T GetModule<T>() where T : UIModule, new()
        {
            T uiModule = new T();
            uiModule.InitBus(MessageBus);
            return uiModule;
        }
    }
}