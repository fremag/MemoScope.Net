using MemoScope.Core;
using System.Windows.Forms;
using WinFwk.UICommands;
using WinFwk.UIModules;

namespace MemoScope.Modules.BlockingObjects
{
    public class BlockingObjectsCommand : AbstractDataUICommand<ClrDump>
    {
        public BlockingObjectsCommand() : base("Blocking Objects", "Display BlockingObjects", "Threads", Properties.Resources._lock, Keys.Control|Keys.B)
        {

        }

        protected override void HandleData(ClrDump clrDump)
        {
            UIModuleFactory.CreateModule<BlockingObjectsModule>(module => { module.UIModuleParent = selectedModule; module.Setup(clrDump); }, module => DockModule(module));
        }
    }
}
