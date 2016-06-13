using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WinFwk.UIMessages;
using WinFwk.UIModules;

namespace WinFwk.UITools.Workplace
{
    public partial class WorkplaceModule : UIModule,
        IMessageListener<SummaryChangedMessage>,
        IMessageListener<ModuleEventMessage>
    {
        private static Logger logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName);
        private WorkplaceModel model;
        protected List<object> SelectedModules => tlvModules.CheckedObjects.OfType<object>().ToList();

        public WorkplaceModule()
        {
            UIModuleParent = null;
            InitializeComponent();
            Name = "Workplace";
            Icon = Properties.Resources.globe_place;
            model = new WorkplaceModel();
            colName.AspectGetter = model.GetName;
            colName.ImageGetter = model.GetIcon;
            colSummary.AspectGetter = model.GetSummary;

            tlvModules.CanExpandGetter = model.HasChild;
            tlvModules.ChildrenGetter = model.GetChildren;
        }

        public void Init(MessageBus messageBus)
        {
            model.Init(messageBus);
        }

        public void HandleMessage(ModuleEventMessage message)
        {
            logger.Debug($"ModuleEventMessage: {message.ModuleEvent}, {message.Module.Name} / {message.Module.Summary}");
            switch (message.ModuleEvent)
            {
                case ModuleEventType.Added:
                    model.Add(message.Module);
                    break;
                case ModuleEventType.Removed:
                    tlvModules.UncheckObject(message.Module);
                    model.CloseModule(message.Module);
                    var parent= message.Module.UIModuleParent;
                    if( parent!= null) {
                        tlvModules.RefreshObject(parent);
                    }
                    
                    if ( message.Module.UIModuleParent != null)
                    {
                        MessageBus.SendMessage(new ActivationRequest(message.Module.UIModuleParent));
                    }
                    break;
                case ModuleEventType.Activated:
                    tlvModules.SelectedObject = message.Module;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            tlvModules.ClearObjects();
            tlvModules.Roots = model.rootModules;
            tlvModules.ExpandAll();
        }

        public void HandleMessage(SummaryChangedMessage message)
        {
            tlvModules.RefreshObject(message.Module);
        }

        private void tlvModules_SelectionChanged(object sender, EventArgs e)
        {
            var module = tlvModules.SelectedObject as UIModule;
            if (module != null)
            {
                MessageBus.SendMessage(new ActivationRequest(module));
            }
        }

        public override bool Closable()
        {
            return false;
        }
    }
}
