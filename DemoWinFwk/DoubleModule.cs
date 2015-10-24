using WinFwk.UICommands;
using WinFwk.UIModules;

namespace DemoWinFwk
{
    public partial class DoubleModule : UIModule, UIDataProvider<double>
    {
        public DoubleModule()
        {
            InitializeComponent();
            this.Name = "DoubleModule";
            this.Text = "My Double Module";
            this.Summary = "Nothing";
        }

        public double Data => double.Parse(textBox1.Text);
    }
}
