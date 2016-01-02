using System.Windows.Forms;
using BrightIdeasSoftware;
using System.Diagnostics;

namespace MemoScope.Modules.Instances
{
    public partial class InstanceFilter : UserControl
    {
        public InstanceFilter()
        {
            InitializeComponent();
        }

        private void tbFilterCode_DragDrop(object sender, DragEventArgs e)
        {
            var data = e.Data as OLVDataObject;
            if (data == null)
            {
                return;
            }
            foreach (FieldNode fieldNode in data.ModelObjects)
            {
                tbFilterCode.Text = fieldNode.FullName;
            }
        }

        private void tbFilterCode_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
    }
}
