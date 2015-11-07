using System.ComponentModel;
using System.Windows.Forms;
using WinFwk.UITools.Settings;

namespace MemoScope
{
    public class MemoScopeSettings : UISettings
    {
        public new static MemoScopeSettings Instance => UISettings.Instance as MemoScopeSettings;

        public string RootDir { get; set; }

        [Category("Process")]
        public string LastProcessName { get; set; }

        public void Save()
        {
            UISettingsMgr<MemoScopeSettings>.Save(Application.ProductName, this);
        }
    }
}
