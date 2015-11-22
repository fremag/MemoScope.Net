using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using WinFwk.UICommands;
using WinFwk.UIMessages;
using WinFwk.UITools.Settings;
using WinFwk.UITools.ToolBar;

namespace WinFwk.UIModules
{
    public partial class UIModuleForm : Form
        , IMessageListener<DockRequest>
        , IMessageListener<StatusMessage>
        , IMessageListener<ActivationRequest>
        , IMessageListener<UISettingsChangedMessage>
    {
        private readonly Dictionary<DockContent, UIModule> dicoModules = new Dictionary<DockContent, UIModule>();
        protected readonly MessageBus msgBus = new MessageBus();
        protected readonly List<UIToolBarSettings> toolbarSettings = new List<UIToolBarSettings>();
        private readonly Dictionary<Keys, AbstractUICommand> dicoKeys = new Dictionary<Keys, AbstractUICommand>();

        private int nbTasks;

        public StatusStrip StatusBar => statusStrip;

        protected UIModuleForm()
        {
            InitializeComponent();

            msgBus.UiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            msgBus.Subscribe(this);
            mainPanel.ContentAdded += OnContentAdded;
            mainPanel.ContentRemoved += OnContentRemoved;

            toolbarSettings.Add(UIToolBarSettings.File);
            toolbarSettings.Add(UIToolBarSettings.Help);
        }

        [UIScheduler]
        void IMessageListener<DockRequest>.HandleMessage(DockRequest message)
        {
            DockModule(message.UIModule);
        }

        [UIScheduler]
        void IMessageListener<StatusMessage>.HandleMessage(StatusMessage message)
        {
            lock (this)
            {
                tsslStatusMessage.Text = message.Text;
                switch (message.Status)
                {
                    case StatusType.BeginTask:
                        nbTasks++;
                        tspbProgressBar.Style = ProgressBarStyle.Marquee;
                        tspbProgressBar.MarqueeAnimationSpeed = 30;
                        tspbProgressBar.Visible = true;
                        break;
                    case StatusType.EndTask:
                        nbTasks--;
                        if (nbTasks <= 0)
                        {
                            tspbProgressBar.Style = ProgressBarStyle.Continuous;
                            tspbProgressBar.MarqueeAnimationSpeed = 0;
                            tspbProgressBar.Visible = false;
                        }
                        break;
                }
            }
        }

        private void SendModuleEventMessage(DockContent content, ModuleEventType moduleEvent)
        {
            UIModule module;
            if (dicoModules.TryGetValue(content, out module))
            {
                msgBus.SendMessage(new ModuleEventMessage(module, moduleEvent));
            }
        }

        private void OnActiveContentChanged(object sender, EventArgs e)
        {
            DockContent dockContent = mainPanel.ActiveContent as DockContent;
            if (dockContent == null)
            {
                return;
            }

            SendModuleEventMessage(dockContent, ModuleEventType.Activated);
        }

        private void OnContentRemoved(object sender, DockContentEventArgs e)
        {
            DockContent dockContent = e.Content as DockContent;
            if (dockContent == null)
            {
                return;
            }

            SendModuleEventMessage(dockContent, ModuleEventType.Removed);
            dicoModules.Remove(dockContent);

        }

        private void OnContentAdded(object sender, DockContentEventArgs e)
        {
            DockContent dockContent = e.Content as DockContent;
            if (dockContent == null)
            {
                return;
            }

            SendModuleEventMessage(dockContent, ModuleEventType.Added);
        }

        [UIScheduler]
        public void HandleMessage(ActivationRequest message)
        {
            foreach (var kvp in dicoModules)
            {
                if (kvp.Value == message.Module)
                {
                    kvp.Key.DockHandler.Activate();
                }
            }
        }
        [UIScheduler]
        protected DockContent DockModule(UIModule uiModule, DockState dockState = DockState.Document, bool allowclose = true)
        {
            uiModule.InitBus(msgBus);
            DockContent content = UIModuleHelper.BuildDockContent(uiModule, allowclose);
            if (uiModule.Icon != null)
            {
                content.Icon = System.Drawing.Icon.FromHandle(uiModule.Icon.GetHicon());
            }
            else
            {
                content.Icon = null;
                content.ShowIcon = false;
            }
            dicoModules[content] = uiModule;
            content.Show(mainPanel, dockState);
            return content;
        }

        protected void InitToolBars()
        {
            mainPanel.DockTopPortion = 120;

            // Get all the commands and instanciate them
            List<AbstractUICommand> commands = new List<AbstractUICommand>();
            var types = WinFwkHelper.GetDerivedTypes(typeof(AbstractUICommand));
            foreach (var type in types)
            {
                var constructor = type.GetConstructor(Type.EmptyTypes);
                var command = constructor?.Invoke(null) as AbstractUICommand;
                if (command != null)
                {
                    command.InitBus(msgBus);
                    if (command.Shortcut != Keys.None)
                    {
                        dicoKeys[command.Shortcut] = command;
                    }
                    commands.Add(command);
                }
            }

            // Group commands by toolbar name
            var dicoCommands = commands.GroupBy(command => command.Group).ToDictionary(commandGroup => commandGroup.Key);

            // Create a default ui settings for toolbar missing some settings
            var dicoSettings = toolbarSettings.ToDictionary(setting => setting.Name);
            foreach(var commandGroup in dicoCommands)
            {
                if (! dicoSettings.ContainsKey(commandGroup.Key))
                {
                    // Create default settings for toolbar
                    dicoSettings.Add(commandGroup.Key, new UIToolBarSettings(commandGroup.Key, 0, null));
                }
            }

            // Order the toolbars by priority 
            DockContent firstToolbar = null;
            foreach (var setting in dicoSettings.Values.OrderByDescending(setting => setting.Priority))
            {
                IGrouping<string, AbstractUICommand> commandGroup;
                if( dicoCommands.TryGetValue(setting.Name, out commandGroup))
                {
                    var toolbar = new UIToolbar();
                    toolbar.InitBus(msgBus);
                    toolbar.Init(setting.Icon, commandGroup);
                    DockContent content = DockModule(toolbar, DockState.DockTop, false);
                    if (firstToolbar == null)
                    {
                        firstToolbar = content;
                    }
                }
            }

            firstToolbar?.DockHandler.Activate();
        }

        public virtual void HandleMessage(UISettingsChangedMessage message)
        {
            // TODO: apply user colors to controls, skin etc
        }

        private void UIModuleForm_Load(object sender, EventArgs e)
        {
            Text = string.Format("{0} {1}", Application.ProductName, Application.ProductVersion);
        }

        protected override bool ProcessCmdKey(ref Message message, Keys keys)
        {
            AbstractUICommand command;
            if(dicoKeys.TryGetValue(keys, out command))
            {
                command.Run();
            }

            return false;
        }

        public void InitModuleFactory()
        {
            UIModuleFactory.Init(this.msgBus, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}