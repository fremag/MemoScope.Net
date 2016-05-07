using NLog;
using System.Collections.Generic;
using System.Reflection;
using WinFwk.UIModules;

namespace WinFwk.UITools.Workplace
{
    public class WorkplaceModel
    {
        static Logger logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName);
        internal Dictionary<UIModule, List<UIModule>> childModules = new Dictionary<UIModule, List<UIModule>>();
        internal List<UIModule> rootModules = new List<UIModule>();

        public void Add(UIModule uiModule)
        {
            if (uiModule.UIModuleParent == null)
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

        public object GetIcon(object rowObject)
        {
            return ((UIModule)rowObject).Icon;
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
            logger.Debug($"{nameof(GetChildren)}: parent: {uiModule.Name}, children: {children?.Count}");
            return children;
        }

        public void Remove(UIModule module)
        {
            logger.Debug($"{nameof(Remove)}: {module.Name}");
            rootModules.Remove(module);
            var children = GetChildren(module.UIModuleParent);
            children?.Remove(module);
        }

        private void RemoveModuleChildren(UIModule module)
        {
            var children = GetChildren(module);
            logger.Debug($"{nameof(RemoveModuleChildren)}: parent: {module.Name}, children: {children?.Count}");
            if (children == null)
            {
                return;
            }
            for (int i = children.Count -1; i >= 0; i--)
            {
                var child = children[i];
                children.RemoveAt(i);
                RemoveModuleChildren(child);
            }
        }
    }
}