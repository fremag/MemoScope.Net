using System;
using WinFwk.UIMessages;
using WinFwk.UIModules;

namespace WinFwk.UITools.Workplace
{
    public partial class WorkplaceModule : UIModule, IMessageListener<ModuleEventMessage>
    {
        private readonly WorkplaceModel model = new WorkplaceModel();

        public WorkplaceModule()
        {
            UIModuleParent = null;
            InitializeComponent();
            Name = "Workplace";

            colName.AspectGetter = rowObject => model.GetName(rowObject);
            colSummary.AspectGetter = rowObject => model.GetSummary(rowObject);
            tlvModules.CanExpandGetter = o => model.HasChild(o);
            tlvModules.ChildrenGetter = o => model.GetChildren(o);
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
                    // todo: select the corresponding module in the workplace
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            tlvModules.Roots = model.rootModules;
            tlvModules.ExpandAll();
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