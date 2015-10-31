using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WinFwk.UICommands;
using WinFwk.UIMessages;
using WinFwk.UIModules;

namespace WinFwk.UITools.ToolBar
{
    public partial class UIToolbar : UIModule, IMessageListener<ModuleEventMessage>
    {
        private readonly Dictionary<AbstractUICommand, Button> dicoCommands = new Dictionary<AbstractUICommand, Button>();

        public UIToolbar()
        {
            InitializeComponent();
        }

        public void HandleMessage(ModuleEventMessage eventMessage)
        {
            foreach (var kvp in dicoCommands)
            {
                kvp.Key.SetSelectedModule(eventMessage.Module);
                kvp.Value.Enabled = kvp.Key.Enabled;
            }
        }

        public void Init(IGrouping<string, AbstractUICommand> commands)
        {
            Name = commands.Key;
            Text = commands.Key;

            foreach (var command in commands)
            {
                var cmd = command;
                Button button = new Button {Text = command.Name, FlatStyle = FlatStyle.Popup};
                toolTip1.SetToolTip(button, command.ToolTip);
                panel.Controls.Add(button);
                var type = command.GetType();
                var meth = type.GetMethod("Run");
                button.Click += (sender, args) => { meth.Invoke(cmd, null); };
                button.Enabled = command.Enabled;
                if (command.Icon != null)
                {
                    button.Image = command.Icon;
                    button.TextAlign = ContentAlignment.BottomCenter;
                    button.TextImageRelation = TextImageRelation.ImageAboveText;
                    button.AutoSize = true;
                }
                
                dicoCommands[command] = button;
            }
        }
    }
}