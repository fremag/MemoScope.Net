using WinFwk.UICommands;
using WinFwk.UIModules;

namespace DemoWinFwk
{
    public partial class StringModule : UIModule, UIDataProvider<string>
    {
        public StringModule()
        {
            InitializeComponent();
            this.Name = "StringModule";
            this.Text = "My String Module";
            this.Summary = "Nothing";
        }

        public string Data => textBox1.Text;
    }
}
