using System.Collections.Generic;
using WinFwk.UIModules;

namespace WinFwk.UITools.Workplace
{
    public class WorkplaceModel
    {
        internal Dictionary<UIModule, List<UIModule>> childModules = new Dictionary<UIModule, List<UIModule>>();
        internal List<UIModule> rootModules = new List<UIModule>();

        public void Add(UIModule uiModule)
        {
            if (uiModule.Parent == null)
            {
                return;
            }
            if (uiModule.UIModuleParent == uiModule)
            {
                rootModules.Add(uiModule);
            }
            else
            {
                List<UIModule> children;
                if (!childModules.TryGetValue(uiModule.UIModuleParent, out children))
                {
                    children = new List<UIModule>();
                    childModules[uiModule.UIModuleParent] = children;
                }
                children.Add(uiModule);
            }
        }

        public string GetName(object rowObject)
        {
            return ((UIModule) rowObject).Name;
        }

        public string GetSummary(object rowObject)
        {
            return ((UIModule) rowObject).Summary;
        }

        public bool HasChild(object o)
        {
            return childModules.ContainsKey((UIModule) o);
        }

        public List<UIModule> GetChildren(object o)
        {
            var uiModule = o as UIModule;
            if (uiModule == null)
            {
                return null;
            }
            List<UIModule> children;
            childModules.TryGetValue(uiModule, out children);
            return children;
        }
    }
}