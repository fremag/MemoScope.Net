using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoDummy
{
    public partial class MemoDummyForm : Form
    {
        public MemoDummyForm()
        {
            InitializeComponent();
        }

        private void MemoDummyForm_Load(object sender, System.EventArgs e)
        {
            var types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (var type in types)
            {
                if (type.IsSubclassOf(typeof (AbstractMemoScript)))
                {
                    var script = Activator.CreateInstance(type);
                    lbScripts.Items.Add(script);
                }
            }
        }

        private AbstractMemoScript script;
        private void lbScripts_SelectedIndexChanged(object sender, EventArgs e)
        {
            script = lbScripts.SelectedItem as AbstractMemoScript;
            propertyGrid1.SelectedObject = script ;
            btnRun.Enabled = script != null;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (script != null)
            {
                timer1.Enabled = true;
                var sched = TaskScheduler.FromCurrentSynchronizationContext();
                Task.Factory.StartNew(() => script.Run()).ContinueWith(task => {
                    timer1.Enabled = false;
                    propertyGrid1.Refresh();
                    }, sched);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (script != null)
                script.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            propertyGrid1.Refresh(); 
        }
    }
}