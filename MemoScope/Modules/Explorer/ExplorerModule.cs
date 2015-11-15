using System.Drawing;
using System.IO;
using WinFwk.UIModules;

namespace MemoScope.Modules.Explorer
{
    public partial class ExplorerModule : UIModule
    {
        public ExplorerModule()
        {
            InitializeComponent();

            Icon = Properties.Resources.folders_explorer_small;
            Name = "Explorer";

            RefreshRootDir();
        }

        private void RefreshRootDir()
        {
            if (MemoScopeSettings.Instance != null)
            {
                tbRootDir.Text = MemoScopeSettings.Instance.RootDir;
            }

            tbRootDir.BackColor = Directory.Exists(tbRootDir.Text) ? Color.LightGreen : Color.OrangeRed;
        }
    }
}
