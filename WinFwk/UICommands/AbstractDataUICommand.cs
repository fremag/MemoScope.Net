using System.Drawing;
using System.Windows.Forms;
using WinFwk.UIModules;

namespace WinFwk.UICommands
{
    public abstract class AbstractDataUICommand<T> : AbstractUICommand
    {
        protected UIDataProvider<T> dataProvider;

        protected AbstractDataUICommand(string name, string toolTip, string group, Image icon, Keys shortcut=Keys.None ) : base(name, toolTip, group, icon, shortcut)
        {
            Enabled = false;
        }

        // Abstract
        protected abstract void HandleData(T data);

        public override void SetSelectedModule(UIModule module)
        {
            selectedModule = module;
            InitDataProvider(module as UIDataProvider<T>);
        }

        public void InitDataProvider(UIDataProvider<T> uiDataProvider)
        {
            dataProvider = uiDataProvider;
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