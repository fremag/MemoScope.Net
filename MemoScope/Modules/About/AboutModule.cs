using System.Windows.Forms;
using WinFwk.UIModules;

namespace MemoScope.Modules.About
{
    public partial class AboutModule : UIModule
    {
        public AboutModule()
        {
            InitializeComponent();
            Icon = Properties.Resources.help_small;

            Summary = "About the application";
            tbVersion.Text = string.Format("v {0}", Application.ProductVersion);
        }

        private void linkGitHub_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/fremag/MemoScope.Net");
        }

        private void linkWiki_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/fremag/MemoScope.Net/wiki");
        }
    }
}