using System.Windows.Forms;
using MemoScope.Modules.Explorer;
using WeifenLuo.WinFormsUI.Docking;
using WinFwk.UIModules;
using WinFwk.UIServices;

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
            InitWorkplace(DockState.DockLeftAutoHide);
            InitLog();
            UIServiceHelper.InitServices(msgBus);
            DockModule(new ExplorerModule(), DockState.DockLeft, false);
            WindowState = FormWindowState.Maximized;
        }
    }
}