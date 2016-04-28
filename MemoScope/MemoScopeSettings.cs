using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using WinFwk.UITools.Settings;
using MemoScope.Core.Helpers;
using MemoScope.Tools.CodeTriggers;

namespace MemoScope
{
    public enum DockPanelPosition { Left, Right }
    public class MemoScopeSettings : UISettings
    {
        public new static MemoScopeSettings Instance => UISettings.Instance as MemoScopeSettings;

        [Category("_Main_")]
        public string RootDir { get; set; }

        [Category("Explorer")]
        [DefaultValue(DockPanelPosition.Left)]
        public DockPanelPosition InitialPosition { get; set; }

        [Category("Explorer")]
        [DefaultValue(true)]
        public bool Visible { get; set; }

        [Category("Display")]
        public List<TypeAlias> TypeAliases { get; set; } = new List<TypeAlias>();

        [Category("Process Dump")]
        public string LastProcessName { get; set; }

        [Category("Process Dump")]
        public List<CodeTrigger> ProcessTriggers { get; set; } = new List<CodeTrigger>();

        [Category("Instances")]
        public List<CodeTrigger> InstanceFilters { get; set; } = new List<CodeTrigger>();

        public void Save()
        {
            UISettingsMgr<MemoScopeSettings>.Save(Application.ProductName, this);
        }
    }
}
