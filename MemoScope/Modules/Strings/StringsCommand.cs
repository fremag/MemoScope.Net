using MemoScope.Core;
using WinFwk.UICommands;
using WinFwk.UIModules;

namespace MemoScope.Modules.Strings
{
    public class StringsCommand : AbstractDataUICommand<ClrDump>
    {
        public StringsCommand() : base("Strings", "Display Strings", "Analysis", Properties.Resources.text_rotate)
        {

        }

        protected override void HandleData(ClrDump clrDump)
        {
            UIModuleFactory.CreateModule<StringsModule>(module => { module.UIModuleParent = selectedModule; module.Setup(clrDump); }, module => DockModule(module));
        }
    }
}
