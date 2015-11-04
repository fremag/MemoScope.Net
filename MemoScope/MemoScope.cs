using System.Windows.Forms;
using WinFwk.UIModules;

namespace MemoScope
{
    public partial class MemoScope : UIModuleForm
    {
        public MemoScope()
        {
            InitializeComponent();
        }

        private void MemoScope_Load(object sender, System.EventArgs e)
        {
            InitToolBars();
            InitWorkplace();
            InitLog();

            WindowState = FormWindowState.Maximized;
        }
    }
}