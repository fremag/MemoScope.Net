using System.Collections;
using System.Drawing;
using System.IO;
using BrightIdeasSoftware;
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

            if (MemoScopeSettings.Instance != null)
            {
                tbRootDir.Text = MemoScopeSettings.Instance.RootDir;
            }
            dtlvExplorer.CanExpandGetter = model => ((AbstractDumpExplorerData) model).HasChildren;
            dtlvExplorer.ChildrenGetter= model => ((AbstractDumpExplorerData) model).GetChildren;
            RefreshRootDir();
            Generator.GenerateColumns(dtlvExplorer, typeof(AbstractDumpExplorerData), false);
        }

        private void RefreshRootDir()
        {
            Summary = tbRootDir.Text;
            var rootDirOk = Directory.Exists(tbRootDir.Text);
            tbRootDir.BackColor = rootDirOk ? Color.LightGreen : Color.OrangeRed;

            if (rootDirOk)
            {
                dtlvExplorer.Roots= AbstractDumpExplorerData.GetItems(tbRootDir.Text);
            }
        }

        private void tbRootDir_TextChanged(object sender, System.EventArgs e)
        {
            RefreshRootDir();
        }

        private void ExplorerModule_Load(object sender, System.EventArgs e)
        {
            RefreshRootDir();
        }
    }
}
