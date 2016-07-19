using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace WinFwk.UITools.Settings.Skins
{
    public class SkinTypeEditor : UITypeEditor
    {
        private IWindowsFormsEditorService editorService;

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

            ListBox listBox = new ListBox();
            listBox.SelectionMode = SelectionMode.One;
            listBox.SelectedValueChanged += OnListBoxSelectedValueChanged;
            listBox.DisplayMember = nameof(AbstractSkin.Name);

            foreach(var skinType in WinFwkHelper.GetDerivedTypes(typeof(AbstractSkin)))
            {
                var skin = Activator.CreateInstance(skinType);
                listBox.Items.Add(skin);
            }
            

            editorService.DropDownControl(listBox);
            if (listBox.SelectedItem == null) // no selection, return the passed-in value as is
                return value;

            return listBox.SelectedItem;
        }

        private void OnListBoxSelectedValueChanged(object sender, EventArgs e)
        {
            editorService.CloseDropDown();
        }
    }
}
