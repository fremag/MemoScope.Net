using System.Drawing;
using System.Windows.Forms;
using WinFwk.UIModules;

namespace WinFwk.UICommands
{
    public abstract class AbstractTypedUICommand<T> : AbstractUICommand where T : class
    {
        public T TypedModule { get; private set; }

        protected AbstractTypedUICommand(string name, string toolTip, string group, Image icon, Keys shortcut=Keys.None ) : base(name, toolTip, group, icon, shortcut)
        {
            Enabled = false;
        }

        // Abstract
        public abstract void HandleAction(T typedModule);

        public override void SetSelectedModule(UIModule module)
        {
            selectedModule = module;
            TypedModule = module as T;
            Enabled = TypedModule != null;
        }

        public override void Run()
        {
            if (TypedModule == null)
            {
                return;
            }

            HandleAction(TypedModule);
        }
    }
}