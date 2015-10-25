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
            DockModule(new DoubleModule());
            DockModule(new StatusModule());
            DockModule(new LogTestsModule());
            DockModule(new LogModule(), DockState.DockBottom);
            InitToolBars();
        }
    }
}