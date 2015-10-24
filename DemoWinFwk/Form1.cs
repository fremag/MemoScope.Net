using WeifenLuo.WinFormsUI.Docking;
using WinFwk.UIModules;
using WinFwk.UITools;

namespace DemoWinFwk
{
    public partial class Form1 : UIModuleForm
    {
        public Form1()
        {
            InitializeComponent();
            DockModule(new StringModule());
            DockModule(new DoubleModule(), DockState.DockLeft);
            DockModule(new StatusModule(), DockState.DockRight);
            DockModule(new LogTestsModule());
            DockModule(new LogModule(), DockState.DockBottom);
            InitToolBars();
        }
    }
}