using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using WinFwk.UICommands;
using WinFwk.UIMessages;
using WinFwk.UITools;
using WinFwk.UITools.Settings;

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

        private int nbTasks;

        public StatusStrip StatusBar => statusStrip;

        protected UIModuleForm()
        {
            InitializeComponent();

            msgBus.UiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            msgBus.Subscribe(this);
            mainPanel.ContentAdded += OnContentAdded;
            mainPanel.ContentRemoved += OnContentRemoved;
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
        protected void DockModule(UIModule uiModule, DockState dockState = DockState.Document, bool allowclose = true)
        {
            uiModule.InitBus(msgBus);
            DockContent content = UIModuleHelper.BuildDockContent(uiModule, allowclose);
            if (uiModule.Icon != null)
            {
                content.Icon = System.Drawing.Icon.FromHandle(uiModule.Icon.GetHicon());
            }
            dicoModules[content] = uiModule;
            content.Show(mainPanel, dockState);
        }

        protected void InitToolBars()
        {
            mainPanel.DockTopPortion = 120;
            var types = WinFwkHelper.GetDerivedTypes(typeof (AbstractUICommand));
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

        public virtual void HandleMessage(UISettingsChangedMessage message)
        {
            // Later: apply user colors to controls, skin etc
        }
    }
}