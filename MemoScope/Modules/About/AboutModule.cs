using System.Windows.Forms;
using WinFwk.UIModules;
using WinFwk.UITools.ToolBar;

namespace MemoScope.Modules.About
{
    public partial class AboutModule : UIModule
    {
        public AboutModule()
        {
            InitializeComponent();
            Icon = UIToolBarSettings.Help.Icon;
            Summary = "About the application";
            tbVersion.Text = string.Format("v {0}", Application.ProductVersion);
        }

        private void linkGitHub_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/fremag/MemoScope.Net");
        }
    }
}