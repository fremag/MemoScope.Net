using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using MemoScope.Modules.Process;
using WinFwk.UITools.Settings;
using MemoScope.Core.Helpers;
using MemoScope.Core.Data;

namespace MemoScope
{
    public class MemoScopeSettings : UISettings
    {
        public new static MemoScopeSettings Instance => UISettings.Instance as MemoScopeSettings;

        [Category("_Main_")]
        public string RootDir { get; set; }
        [Category("Display")]
        public List<TypeAlias> TypeAliases { get; set; } = new List<TypeAlias>();

        [Category("Process Dump")]
        public string LastProcessName { get; set; }

        [Category("Process Dump")]
        public List<CodeTrigger> Triggers { get; set; } = new List<CodeTrigger>();

        public void Save()
        {
            UISettingsMgr<MemoScopeSettings>.Save(Application.ProductName, this);
        }
    }
}
