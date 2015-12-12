using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MemoScope.Tools.RegexFilter
{
    public partial class RegexFilterControl : UserControl
    {
        Regex regex;
        public event Action<Regex> RegexApplied;
        public event Action RegexCancelled;

        public RegexFilterControl()
        {
            InitializeComponent();
        }

        private void tbRegex_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    Apply();
                    break;
                case Keys.Escape:
                    Cancel();
                    break;
            }
        }

        private void Cancel()
        {
            if( RegexCancelled != null)
            {
                RegexCancelled();
            }
            tbRegex.BackColor = Color.LightGray;
        }

        private void Apply()
        {
            try
            {
                if (cbIgnoreCase.Checked)
                {
                    regex = new Regex(tbRegex.Text);
                }
                else
                {
                    regex = new Regex(tbRegex.Text, RegexOptions.IgnoreCase);
                }

                if ( RegexApplied != null)
                {
                    RegexApplied(regex);
                }
                tbRegex.BackColor = Color.LightGreen;
            }
            catch (ArgumentException)
            {
                Cancel();
                tbRegex.BackColor = Color.Orange;
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            Apply();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void cbIgnoreCase_CheckedChanged(object sender, EventArgs e)
        {
            Apply();
        }
    }
}
