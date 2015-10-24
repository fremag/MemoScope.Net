using System.Drawing;
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
        public Icon Icon { get; private set; }
        public bool Enabled { get; protected set; }
        public MessageBus MessageBus { get; set; }

        public abstract void SetSelectedModule(UIModule module);

        protected AbstractUICommand(string name, string toolTip, string group, Icon icon)
        {
            Name = name;
            ToolTip = toolTip;
            Group = group;
            Icon = icon;
        }

        public void InitBus(MessageBus msgBus)
        {
            MessageBus = msgBus;
            MessageBus.Subscribe(this);
        }
    }

    public abstract class AbstractUICommand<T> : AbstractUICommand
    {
        private UIDataProvider<T> dataProvider;

        // Abstract
        protected abstract void HandleData(T data);

        public override void SetSelectedModule(UIModule module)
        {
            dataProvider = module as UIDataProvider<T>;
            Enabled = (dataProvider != null);
        }

        public virtual void Run()
        {
            if (dataProvider != null)
            {
                T data = dataProvider.Data;
                HandleData(data);
            }
        }

        protected AbstractUICommand(string name, string toolTip, string @group, Icon icon) : base(name, toolTip, @group, icon)
        {
        }

    }
}
