using WinFwk.UICommands;
using WinFwk.UIModules;

namespace MemoScope.Core
{
    public partial class UIClrDumpModule : UIModule, UIDataProvider<ClrDump>
    {
        protected ClrDump ClrDump { get; set; }

        public UIClrDumpModule()
        {
            InitializeComponent();
        }

        ClrDump UIDataProvider<ClrDump>.Data => ClrDump;
    }
}
