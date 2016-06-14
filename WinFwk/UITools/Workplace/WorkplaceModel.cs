using NLog;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WinFwk.UIModules;
using WinFwk.UIMessages;

namespace WinFwk.UITools.Workplace
{
    public class WorkplaceModel
    {
        static Logger logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.FullName);
        internal Dictionary<UIModule, List<UIModule>> modules = new Dictionary<UIModule, List<UIModule>>();
        public List<UIModule> rootModules { get; } = new List<UIModule>();
        private MessageBus MessageBus { get; set; }

        public void Init(MessageBus messageBus)
        {
            MessageBus = messageBus;
        }

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
                if (!modules.TryGetValue(uiModule.UIModuleParent, out children))
                {
                    children = new List<UIModule>();
                    modules[uiModule.UIModuleParent] = children;
                }
                children.Add(uiModule);

                modules[uiModule] = new List<UIModule>();
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
            return modules.ContainsKey((UIModule) o);
        }

        public List<UIModule> GetChildren(object o)
        {
            var uiModule = o as UIModule;
            if (uiModule == null)
            {
                return null;
            }
            List<UIModule> children;
            modules.TryGetValue(uiModule, out children);
            var count = children == null ? 0 : children.Count;
            logger.Debug($"{nameof(GetChildren)}: parent: {uiModule.Name}, children: {count}");
            return children;
        }

        public void Remove(UIModule module)
        {
            logger.Debug($"{nameof(Remove)}: {module.Name}");
            if( rootModules.Remove(module) )
            {
                logger.Debug($"{nameof(Remove)}: removed root module {module.Name}");
            }

            if(modules.ContainsKey(module) )
            {
                var b  = modules.Remove(module);
                logger.Debug($"{nameof(Remove)}: removed module {module.Name}: {b}");
            }


            var parentChildren = GetChildren(module.UIModuleParent);
            if( parentChildren != null && parentChildren.Any())
            {
                parentChildren.Remove(module);
            }
        }

        public void CloseModule(UIModule module)
        {
            var children = GetChildren(module);
            var count = children == null ? 0 : children.Count;
            logger.Debug($"{nameof(CloseModule)}: {module.Name}, children: {count}");
            if (children != null && children.Any())
            {
                foreach (var child in children)
                {
                    logger.Debug($"RequestCloseModule: Child={child.Name}");
                    MessageBus.SendMessage(new CloseRequest(child));
                }
            }

            logger.Debug($"{nameof(CloseModule)}: Remove/Close {module.Name}");
            Remove(module);
            module.Close();
            MessageBus.SendMessage(new CloseRequest(module));
        }
    }
}