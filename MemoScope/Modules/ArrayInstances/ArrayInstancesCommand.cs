using WinFwk.UICommands;
using WinFwk.UIModules;
using MemoScope.Modules.Arrays;
using System;

namespace MemoScope.Modules.ArrayInstances
{
    public class ArrayInstancesCommand : AbstractDataUICommand<ArraysAddressList>
    {
        public ArrayInstancesCommand() : base("Array Instances", "Display Array Instances", "Analysis", Properties.Resources.formatting_equal_to)
        {

        }

        protected override void HandleData(ArraysAddressList arrayAddressList)
        {
            Display(arrayAddressList, selectedModule);
        }

        public static void Display(ArraysAddressList arrayAddressList, UIModule parentModule)
        {
            if (arrayAddressList == null)
            {
                throw new InvalidOperationException("No array selected !");
            }

            UIModuleFactory.CreateModule<ArrayInstancesModule>(module => { module.UIModuleParent = parentModule; module.Setup(arrayAddressList); }, module => parentModule.RequestDockModule(module));
        }
    }
}
