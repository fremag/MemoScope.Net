using WeifenLuo.WinFormsUI.Docking;
using WinFwk.UIModules;

namespace DemoWinFwk
{
    public partial class Form1 : UIModuleForm
    {
        public Form1()
        {
            InitializeComponent();
            DockModule(new StringModule());
            DockModule(new DoubleModule(), DockState.DockLeft);
            InitToolbars();
        }
    }
}