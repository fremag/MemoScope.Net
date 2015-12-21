using System.Drawing;
using System.Windows.Forms;
using WinFwk.UIModules;

namespace WinFwk.UICommands
{
    public abstract class AbstractTypedUICommand<T> : AbstractUICommand
    {
        protected UIDataProvider<T> dataProvider;
        protected UIModule selectedModule;

        protected AbstractTypedUICommand(string name, string toolTip, string group, Image icon, Keys shortcut=Keys.None ) : base(name, toolTip, group, icon, shortcut)
        {
            Enabled = false;
        }

        // Abstract
        protected abstract void HandleData(T data);

        public override void SetSelectedModule(UIModule module)
        {
            selectedModule = module;
            dataProvider = module as UIDataProvider<T>;
            Enabled = (dataProvider != null);
        }

        public override void Run()
        {
            if (dataProvider == null)
            {
                return;
            }

            var data = dataProvider.Data;
            HandleData(data);
        }
    }
}