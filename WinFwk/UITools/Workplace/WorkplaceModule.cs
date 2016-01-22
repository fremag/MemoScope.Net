using System;
using System.Collections.Generic;
using System.Linq;
using WinFwk.UIMessages;
using WinFwk.UIModules;

namespace WinFwk.UITools.Workplace
{
    public partial class WorkplaceModule : UIModule,
        IMessageListener<SummaryChangedMessage>,
        IMessageListener<ModuleEventMessage>
    {
        private readonly WorkplaceModel model = new WorkplaceModel();

        protected List<object> SelectedModules => tlvModules.CheckedObjects.OfType<object>().ToList();

        public WorkplaceModule()
        {
            UIModuleParent = null;
            InitializeComponent();
            Name = "Workplace";
            Icon = Properties.Resources.globe_place;

            colName.AspectGetter = model.GetName;
            colName.ImageGetter = model.GetIcon;
            colSummary.AspectGetter = model.GetSummary;

            tlvModules.CanExpandGetter = model.HasChild;
            tlvModules.ChildrenGetter = model.GetChildren;
        }

        public void HandleMessage(ModuleEventMessage message)
        {
            switch (message.ModuleEvent)
            {
                case ModuleEventType.Added:
                    model.Add(message.Module);
                    break;
                case ModuleEventType.Removed:
                    model.Remove(message.Module);
                    break;
                case ModuleEventType.Activated:
                    tlvModules.SelectedObject = message.Module;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
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
    }
}