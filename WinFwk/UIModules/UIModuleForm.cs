using BrightIdeasSoftware;
using NLog;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
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
        , IMessageListener<CloseRequest>
        , IUICommandRequestor
    {
        static Logger logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName);
        private readonly Dictionary<DockContent, UIModule> dicoModules = new Dictionary<DockContent, UIModule>();
        protected readonly MessageBus msgBus = new MessageBus();
        private readonly List<UIToolBarSettings> toolbarSettings = new List<UIToolBarSettings>();
        private readonly Dictionary<Keys, AbstractUICommand> dicoKeys = new Dictionary<Keys, AbstractUICommand>();
        private CancellationTokenSource cancellationTokenSource;
        private int nbTasks;
        IEnumerable<AbstractUICommand> commands;
        protected Dictionary<Type, Action<Control, UISettings>> dicoSkinActions = new Dictionary<Type, Action<Control, UISettings>>(); 
        public StatusStrip StatusBar => statusStrip;

        protected UIModuleForm()
        {
            InitializeComponent();
            ApplyColors(mainPanel, UISettings.Instance);

            msgBus.UiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            msgBus.Subscribe(this);
            mainPanel.ContentAdded += OnContentAdded;
            mainPanel.ContentRemoved += OnContentRemoved;

            toolbarSettings.Add(UIToolBarSettings.Main);
            toolbarSettings.Add(UIToolBarSettings.Help);

            RegisterSkinAction(typeof(Chart), ApplyColorsChart);
            RegisterSkinAction(typeof(ObjectListView), ApplyColorsListView);
        }

        [UIScheduler]
        void IMessageListener<DockRequest>.HandleMessage(DockRequest message)
        {
            DockModule(message.UIModule, message.DockState);
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
                        cancellationTokenSource = message.CancellationTokenSource;
                        tssbCancel.Visible = cancellationTokenSource != null;
                        break;
                    case StatusType.EndTask:
                        nbTasks--;
                        if (nbTasks <= 0)
                        {
                            tspbProgressBar.Style = ProgressBarStyle.Continuous;
                            tspbProgressBar.MarqueeAnimationSpeed = 0;
                            tspbProgressBar.Visible = false;
                            tssbCancel.Visible = false;
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

            logger.Debug($"OnContentRemoved: {dockContent.TabText}");
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
            ApplyColors(uiModule, UISettings.Instance);

            var content = BuildContent(uiModule, allowclose);
            content.Show(mainPanel, dockState);
            return content;
        }

        [UIScheduler]
        protected DockContent DockModule(UIModule uiModule, DockContent parentContent, DockAlignment dockAlignment = DockAlignment.Top, bool allowclose = true)
        {
            ApplyColors(uiModule, UISettings.Instance);

            var content = BuildContent(uiModule, allowclose);
            content.Show(parentContent.Pane, DockAlignment.Top, 0.5);
            return content;
        }

        private DockContent BuildContent(UIModule uiModule, bool allowclose)
        {
            uiModule.InitBus(msgBus);
            var content = UIModuleHelper.BuildDockContent(uiModule, allowclose);
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
            return content;
        }

        protected void InitToolBars()
        {
            mainPanel.DockTopPortion = 120;
            this.msgBus.SendMessage(new UICommandRequest(this));
            // Link keyboard shortcuts to commands
            foreach (var command in commands)
            {
                if (command.Shortcut != Keys.None)
                {
                    dicoKeys[command.Shortcut] = command;
                }
            }

            // Group commands by toolbar name
            var dicoCommands = commands.GroupBy(command => command.Group).ToDictionary(commandGroup => commandGroup.Key);

            // Create a default ui settings for toolbar missing some settings
            var dicoSettings = toolbarSettings.ToDictionary(setting => setting.Name);
            foreach (var commandGroup in dicoCommands)
            {
                if (!dicoSettings.ContainsKey(commandGroup.Key))
                {
                    // Create default settings for toolbar
                    dicoSettings.Add(commandGroup.Key, new UIToolBarSettings(commandGroup.Key, 0, null));
                }
            }

            // Order the toolbars by priority 
            DockContent firstToolbar = null;
            foreach (var setting in dicoSettings.Values.OrderBy(setting => setting.Priority))
            {
                IGrouping<string, AbstractUICommand> commandGroup;
                if (dicoCommands.TryGetValue(setting.Name, out commandGroup))
                {
                    var toolbar = new UIToolbar();
                    toolbar.InitBus(msgBus);
                    toolbar.Init(setting.Icon, commandGroup);
                    DockContent content = DockModule(toolbar, setting.DockState, false);
                    if (setting.MainToolbar)
                    {
                        firstToolbar = content;
                    }
                }
            }

            firstToolbar?.DockHandler.Activate();
        }

        public virtual void HandleMessage(UISettingsChangedMessage message)
        {
            ApplyColors(this, message.UiSettings);
            ApplyColors(mainPanel, message.UiSettings);
        }

        private static void ApplyColors(DockPanel dockPanel, UISettings uiSettings)
        {
            var skin = dockPanel.Skin;
            var x = skin.AutoHideStripSkin;

            var dpStrip = skin.DockPaneStripSkin;
            var docGrad = dpStrip.DocumentGradient;
            docGrad.ActiveTabGradient = uiSettings.ActiveTabGradient.TabGradient;
            docGrad.DockStripGradient = uiSettings.DockStripGradient.TabGradient;
            docGrad.InactiveTabGradient = uiSettings.InactiveTabGradient.TabGradient;

            var toolGrad = dpStrip.ToolWindowGradient;
            toolGrad.ActiveTabGradient = uiSettings.ActiveTabGradient.TabGradient;
            toolGrad.DockStripGradient = uiSettings.DockStripGradient.TabGradient;
            toolGrad.InactiveTabGradient = uiSettings.InactiveTabGradient.TabGradient;

            toolGrad.ActiveCaptionGradient = uiSettings.ActiveCaptionGradient.TabGradient;
            toolGrad.InactiveCaptionGradient = uiSettings.InactiveCaptionGradient.TabGradient;

            dockPanel.Refresh();
        }

        public void RegisterSkinAction(Type type, Action<Control, UISettings> action)
        {
            dicoSkinActions[type] = action;
        }

        protected void ApplyColors(Control control, UISettings uiSettings)
        {
            var backgroundColor = uiSettings.BackgroundColor;
            var foregroundColor = uiSettings.ForegroundColor;
            control.BackColor = backgroundColor;
            control.ForeColor = foregroundColor;

            Action<Control, UISettings> skinAction;
            if (dicoSkinActions.TryGetValue(control.GetType(), out skinAction))
            {
                skinAction(control, uiSettings);
            }
            
            foreach (Control child in control.Controls)
            {
                ApplyColors(child, uiSettings);
            }

            control.Refresh();
        }

        private static void ApplyColorsChart(Control control, UISettings uiSettings)
        {
            foreach(var area in ((Chart)control).ChartAreas)
            {
                area.BackColor = uiSettings.BackgroundColor;
            }
        }

        private static void ApplyColorsListView(Control control, UISettings uiSettings)
        {
            ObjectListView objListView = control as ObjectListView;
            if(objListView == null)
            {
                return;
            }
            // Alternate row
            objListView.UseAlternatingBackColors = uiSettings.UseAlternateRowColor;
            objListView.AlternateRowBackColor = uiSettings.AlternateRowColor;

            // Header
            objListView.HeaderFormatStyle = new HeaderFormatStyle();
            objListView.HeaderFormatStyle.SetBackColor(uiSettings.HeaderBackColor);
            objListView.HeaderFormatStyle.SetForeColor(uiSettings.HeaderForeColor);

            // Selected row
            objListView.SelectedBackColor = uiSettings.SelectedRowBackgroundColor;
            objListView.UnfocusedSelectedBackColor = uiSettings.SelectedRowBackgroundColor;
            objListView.SelectedForeColor = uiSettings.SelectedRowForegroundColor;
            objListView.UnfocusedSelectedForeColor = uiSettings.SelectedRowForegroundColor;
            objListView.OwnerDraw = true;
        }

        private void UIModuleForm_Load(object sender, EventArgs e)
        {
            Text = string.Format("{0} {1} ({2})", Application.ProductName, Application.ProductVersion, Environment.Is64BitProcess ? "x64" : "x86");
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

        private void tssbCancel_ButtonClick(object sender, EventArgs e)
        {
            if(cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
            }
        }

        protected void AddToolBar(string name, int priority, Bitmap icon, DockState dockState = DockState.DockTop, bool mainToolbar=false)
        {
            toolbarSettings.Add(new UIToolBarSettings(name, priority, icon, dockState, mainToolbar));
        }

        [UIScheduler]
        void IMessageListener<CloseRequest>.HandleMessage(CloseRequest message)
        {
            logger.Info($"CloseRequest: {message.Module.Name} / {message.Module.Summary}");
            foreach (var kvp in dicoModules)
            {
                UIModule module = kvp.Value;
                if (module == message.Module && module.Closable())
                {
                    logger.Info($"Close: {module.Name} / {module.Summary}");
                    kvp.Key.Close();
                    kvp.Key.DockHandler.Dispose();
                    break;
                }
            }
        }

        public void Accept(IEnumerable<AbstractUICommand> commands)
        {
            this.commands = commands;
        }
    }
}
