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

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            tlvModules.Roots = model.rootModules;
            tlvModules.ExpandAll();
        }
    }
}