using System.Windows.Forms;
using BrightIdeasSoftware;

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
                string prefix = fieldNode.ClrType.ElementType.ToString();
                string code = $" x._{prefix}({fieldNode.FullName}) ";
                tbFilterCode.Text = tbFilterCode.Text.Insert(tbFilterCode.SelectionStart, code);
            }
        }

        private void tbFilterCode_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
    }
}
