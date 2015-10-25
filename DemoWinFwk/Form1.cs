using System.Windows.Forms;
using WinFwk.UIModules;

namespace DemoWinFwk
{
    public partial class Form1 : UIModuleForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            InitToolBars();
            InitWorkplace();
            InitLog();

            DockModule(new StringModule());
            DockModule(new DoubleModule());
            DockModule(new StatusModule());
            DockModule(new LogTestsModule());

            this.WindowState = FormWindowState.Maximized;
        }
    }
}