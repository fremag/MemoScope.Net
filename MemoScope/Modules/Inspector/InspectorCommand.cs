using MemoScope.Core;
using System;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using WinFwk.UICommands;
using WinFwk.UIModules;

namespace MemoScope.Modules.Inspector
{
    public class InspectorCommand :  AbstractDataUICommand<ClrDump>
    {
        public InspectorCommand() : base("Inspector", "Display Inspector module", "Dump", Properties.Resources.microscope, Keys.Control|Keys.Shift|Keys.I)
        {

        }

        protected override void HandleData(ClrDump data)
        {
            if( data == null)
            {
                throw new InvalidOperationException("Can't show inspector module, no dump selected !");
            }

            UIModuleFactory.CreateModule<InspectorModule>(
                mod => { mod.UIModuleParent = selectedModule; mod.Setup(data); },
                mod => DockModule(mod, DockState.DockRight)
             );
        }
    }
}
