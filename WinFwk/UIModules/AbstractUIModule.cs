using System.Drawing;
using System.Windows.Forms;
using WinFwk.UIMessages;

namespace WinFwk.UIModules
{
    public class UIModule : UserControl
    {
        protected MessageBus MessageBus { get; private set; }
        public Bitmap Icon { get; protected set; }
        public string Info { get; protected set; }
        public string Summary { get; protected set; }

        public void InitBus(MessageBus bus)
        {
            MessageBus = bus;
            MessageBus.Subscribe(this);
        }
    }
}