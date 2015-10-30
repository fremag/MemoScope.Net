using System.Threading;
using WinFwk.UIModules;
using WinFwk.UITools;
using WinFwk.UITools.Log;

namespace DemoWinFwk
{
    public partial class LogTestsModule : UIModule
    {
        public LogTestsModule()
        {
            InitializeComponent();
            this.Name = "Log Test";
            this.Text = "Test log messages";
            this.Summary = "Nothing";
        }

        public double Data => double.Parse(textBox1.Text);

        private void button1_Click(object sender, System.EventArgs e)
        {
            Log(textBox1.Text, LogLevelType.Debug);
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            Log(textBox1.Text);
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            Log(textBox1.Text, LogLevelType.Warn);
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            Log(textBox1.Text, LogLevelType.Error);
        }

        private void button5_Click(object sender, System.EventArgs e)
        {
            var msg = new LogMessage(this, textBox1.Text, new LockRecursionException());
            Thread t = new Thread(() =>
            {
                Thread.Sleep(1000);
                MessageBus.SendMessage(msg);
            });
            t.Start();
        }

        private void button6_Click(object sender, System.EventArgs e)
        {
            Log(textBox1.Text, LogLevelType.Notify);
        }
    }
}