using MemoScope.Core.Data;
using System;
using WinFwk.UICommands;
using WinFwk.UIModules;

namespace MemoScope.Modules.TypeDetails
{
    public class TypeDetailsCommand :  AbstractDataUICommand<ClrDumpType>
    {
        public TypeDetailsCommand() : base("Type", "Display type details", "Dump", Properties.Resources.blueprint_large)
        {

        }

        protected override void HandleData(ClrDumpType data)
        {
            if( data == null)
            {
                throw new InvalidOperationException("No type selected !");
            }

            UIModuleFactory.CreateModule<TypeDetailsModule>(
                mod => { mod.UIModuleParent = selectedModule; mod.Setup(data); },
                mod => DockModule(mod)
                );
        }
    }
}
