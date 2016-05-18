using System.Collections.Generic;
using WinFwk.UIModules;
using WinFwk.UICommands;
using BrightIdeasSoftware;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace WinFwk.UITools.Commands
{
    public partial class CommandMgrModule : UIModule,
        IUICommandRequestor
    {
        private IEnumerable<CommandInfo> commandInfos;

        public CommandMgrModule()
        {
            InitializeComponent();
            dlvCommands.InitColumns<CommandInfo>();
            dlvCommands[nameof(CommandInfo.Name)].ImageAspectName= nameof(CommandInfo.Icon);
            dlvCommands.RowHeight = 32;

        }

        public override void Init()
        {
            MessageBus.SendMessage(new UICommandRequest(this));
            this.Name = "Commands";
            this.Icon = Properties.Resources.update_contact_info_small;
        }
        
        public void Accept(IEnumerable<AbstractUICommand> commands)
        {
            this.commandInfos = commands.Select(c => new CommandInfo(c));
        }

        public override void PostInit()
        {
            base.PostInit();
            dlvCommands.Objects = commandInfos;
            dlvCommands.ShowGroups = true;
            dlvCommands.BuildGroups(nameof(CommandInfo.Group), SortOrder.Descending);
            Summary = $"{commandInfos.Count():###,###,##0} commands in {commandInfos.Select(c => c.Group).Distinct().Count():###,###,##0} groups";
        }
    }

    public class CommandInfo
    {
        AbstractUICommand Command { get; }

        public CommandInfo(AbstractUICommand command)
        {
            Command = command;
        }

        public Image Icon => Command.Icon;

        [OLVColumn(Width = 250)]
        public string Name => Command.Name;
        [OLVColumn]
        public string Group => Command.Group;
        [OLVColumn]
        public Keys ShortCut => Command.Shortcut;
        [OLVColumn(Width =500)]
        public string ToolTip=> Command.ToolTip;
    }
}
