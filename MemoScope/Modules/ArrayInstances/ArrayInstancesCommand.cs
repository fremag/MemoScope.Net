using WinFwk.UICommands;
using WinFwk.UIModules;
using MemoScope.Modules.Arrays;
using System.Windows.Forms;

namespace MemoScope.Modules.ArrayInstances
{
    public class ArrayInstancesCommand : AbstractTypedUICommand<ArraysAddressList>
    {
        public ArrayInstancesCommand() : base("Array Instances", "Display Array Instances", "Analysis", Properties.Resources.formatting_equal_to)
        {

        }

        protected override void HandleData(ArraysAddressList arrayAddressList)
        {
            if(arrayAddressList == null)
            {
                MessageBox.Show("Please, select an array type !");
                return;
            }
            UIModuleFactory.CreateModule<ArrayInstancesModule>(module => { module.UIModuleParent = selectedModule; module.Setup(arrayAddressList); }, module => DockModule(module));
        }
    }
}
