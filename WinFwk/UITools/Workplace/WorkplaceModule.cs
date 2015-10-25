using WinFwk.UIMessages;
using WinFwk.UIModules;

namespace WinFwk.UITools.Workplace
{
    public partial class WorkplaceModule : UIModule, IMessageListener<ModuleDocked>
    {
        private readonly WorkplaceModel model = new WorkplaceModel();

        public WorkplaceModule()
        {
            InitializeComponent();
            Name = "Workplace";

            colName.AspectGetter = rowObject => model.GetName(rowObject);
            colSummary.AspectGetter = rowObject => model.GetSummary(rowObject);
            tlvModules.CanExpandGetter = o => model.HasChild(o);
            tlvModules.ChildrenGetter = o => model.GetChildren(o);
        }

        public void HandleMessage(ModuleDocked message)
        {
            model.Add(message.UiModule);
            tlvModules.Roots = model.rootModules;
        }
    }
}