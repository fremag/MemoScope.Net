using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WinFwk.UICommands;
using WinFwk.UIMessages;
using WinFwk.UIModules;

namespace WinFwk.UITools
{
    public partial class UIToolbar : UIModule, IMessageListener<ActiveModuleMessage>
    {
        public UIToolbar()
        {
            InitializeComponent();
        }
        private readonly Dictionary<AbstractUICommand, Button> dicoCommands = new Dictionary<AbstractUICommand, Button>();
        public void Init(IGrouping<string, AbstractUICommand> commands)
        {
            Name = commands.Key;
            Text = commands.Key;

            foreach (var command in commands)
            {
                var cmd = command;
                Button button = new Button { Text = command.Name, FlatStyle = FlatStyle.Popup };
                toolTip1.SetToolTip(button, command.ToolTip);
                panel.Controls.Add(button);
                var type = command.GetType();
                var meth = type.GetMethod("Run");
                button.Click += (sender, args) =>
                {
                    meth.Invoke(cmd, null);
                };
                dicoCommands[command] = button;
            }
        }

        public void HandleMessage(ActiveModuleMessage message)
        {
            var providedDataTypes = WinFwkHelper.GetGenericInterfaceArguments(message.Module, typeof(UIDataProvider<>));
            if (providedDataTypes.Count == 0)
            {
                return;
            }
            foreach (var kvp in dicoCommands)
            {
                kvp.Key.SetSelectedModule(message.Module);
                kvp.Value.Enabled = kvp.Key.Enabled;
            }
        }
    }
}
