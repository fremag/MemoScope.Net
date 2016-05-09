using MemoScope.Core;
using WinFwk.UICommands;
using WinFwk.UIModules;

namespace MemoScope.Modules.ClrRoots
{
    public class ClrRootsCommand : AbstractDataUICommand<ClrDump>
    {
        public ClrRootsCommand() : base("ClrRoots", "Display ClrRoots Queue", "Memory", Properties.Resources.anchor)
        {

        }

        protected override void HandleData(ClrDump clrDump)
        {
            UIModuleFactory.CreateModule<ClrRootsModule>(module => { module.UIModuleParent = selectedModule; module.Setup(clrDump); }, module => DockModule(module));
        }
    }
}
