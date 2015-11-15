using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using MemoScope.Modules.Process;
using WinFwk.UITools.Settings;

namespace MemoScope
{
    public class MemoScopeSettings : UISettings
    {
        public new static MemoScopeSettings Instance => UISettings.Instance as MemoScopeSettings;

        public string RootDir { get; set; }

        [Category("Process")]
        public string LastProcessName { get; set; }

        [Category("Process Dump")]
        public List<DumpTrigger> Triggers { get; set; } = new List<DumpTrigger>();

        public void Save()
        {
            UISettingsMgr<MemoScopeSettings>.Save(Application.ProductName, this);
        }
    }
}
