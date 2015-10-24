using System.Drawing;
using System.Windows.Forms;
using WinFwk.UIMessages;

namespace WinFwk.UIModules
{
    public class UIModule : UserControl
    {
        private MessageBus MessageBus { get; set; }
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