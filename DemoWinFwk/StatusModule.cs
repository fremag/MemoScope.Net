using System.Threading;
using System.Threading.Tasks;
using WinFwk.UICommands;
using WinFwk.UIModules;
using WinFwk.UITools;

namespace DemoWinFwk
{
    public partial class StatusModule : UIModule
    {
        public StatusModule()
        {
            InitializeComponent();
            this.Name = "DoubleModule";
            this.Text = "My Double Module";
            this.Summary = "Nothing";
        }

        public double Data => double.Parse(textBox1.Text);

        private void button1_Click(object sender, System.EventArgs e)
        {
            MessageBus.SendMessage(new StatusMessage(textBox1.Text));
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            MessageBus.SendMessage(new StatusMessage(textBox1.Text, StatusType.BeginTask));
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            MessageBus.SendMessage(new StatusMessage(textBox1.Text, StatusType.EndTask));
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            var msg = new StatusMessage(textBox1.Text, StatusType.EndTask);
            Thread t = new Thread(() =>
            {
                Thread.Sleep(1000);
                MessageBus.SendMessage(msg);
            });
            t.Start();
        }
    }
}