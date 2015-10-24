using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using WinFwk.UICommands;
using WinFwk.UIMessages;
using WinFwk.UITools;

namespace WinFwk.UIModules
{
    public partial class UIModuleForm : Form, IMessageListener<DockRequest>
    {
        private readonly Dictionary<DockContent, UIModule> dicoModules = new Dictionary<DockContent, UIModule>();
        private readonly DockPanel mainPanel;
        protected readonly MessageBus msgBus = new MessageBus();

        protected UIModuleForm()
        {
            InitializeComponent();

            IsMdiContainer = true;
            mainPanel = new DockPanel { Dock = DockStyle.Fill };
            Controls.Add(mainPanel);
            msgBus.Subscribe(this);
            mainPanel.ActiveContentChanged += OnActiveContentChanged;
        }

        private void OnActiveContentChanged(object sender, EventArgs e)
        {
            DockContent c = mainPanel.ActiveContent as DockContent;
            if (c == null)
            {
                return;
            }

            UIModule module;
            if (dicoModules.TryGetValue(c, out module))
            {
                msgBus.SendMessage(new ActiveModuleMessage(module));
            }
        }

        protected void DockModule(UIModule uiModule, DockState dockState = DockState.Document, bool allowclose = true)
        {
            uiModule.InitBus(msgBus);
            var content = UIModuleHelper.Dock(this.mainPanel, uiModule, dockState, allowclose);
            content.Disposed += OnContentDisposed;
            dicoModules[content] = uiModule;
        }

        private void OnContentDisposed(object sender, EventArgs e)
        {
            DockContent content = sender as DockContent;
            if (content == null)
            {
                return;
            }
            content.Disposed -= OnContentDisposed;
            dicoModules.Remove(content);
        }

        protected void InitToolbars()
        {
            var types = WinFwkHelper.GetDerivedTypes(typeof(AbstractUICommand<>));
            List<AbstractUICommand> commands = new List<AbstractUICommand>();
            foreach (var type in types)
            {
                var constructor = type.GetConstructor(Type.EmptyTypes);
                var command = constructor?.Invoke(null) as AbstractUICommand;
                if (command != null)
                {
                    command.InitBus(msgBus);
                    commands.Add(command);
                }
            }
            var commandGroups = commands.GroupBy(command => command.Group);
            foreach (var g in commandGroups)
            {
                var toolbar = new UIToolbar();
                toolbar.InitBus(msgBus);
                toolbar.Init(g);
                DockModule(toolbar, DockState.DockTop, false);
            }
        }

        public void HandleMessage(DockRequest message)
        {
            DockModule(message.UIModule);
        }
    }
}