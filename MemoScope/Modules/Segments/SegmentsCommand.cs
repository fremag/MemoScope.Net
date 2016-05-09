using MemoScope.Core;
using WinFwk.UICommands;
using WinFwk.UIModules;

namespace MemoScope.Modules.Segments
{
    public class SegmentsCommand : AbstractDataUICommand<ClrDump>
    {
        public SegmentsCommand() : base("Segments", "Display memory segments", "Memory", Properties.Resources.outline_wight_gallery)
        {

        }

        protected override void HandleData(ClrDump clrDump)
        {
            UIModuleFactory.CreateModule<SegmentsModule>(module => { module.UIModuleParent = selectedModule; module.Setup(clrDump); }, module => DockModule(module));
        }
    }
}
