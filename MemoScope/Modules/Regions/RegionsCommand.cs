using MemoScope.Core;
using WinFwk.UICommands;
using WinFwk.UIModules;

namespace MemoScope.Modules.Regions
{
    public class RegionsCommand : AbstractDataUICommand<ClrDump>
    {
        public RegionsCommand() : base("Regions", "Display memory regions", "Memory", Properties.Resources.borders_accent)
        {

        }

        protected override void HandleData(ClrDump clrDump)
        {
            UIModuleFactory.CreateModule<RegionsModule>(module => { module.UIModuleParent = selectedModule; module.Setup(clrDump); }, module => DockModule(module));
        }
    }
}
