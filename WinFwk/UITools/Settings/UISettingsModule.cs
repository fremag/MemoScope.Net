using System;
using System.Reflection;
using System.Windows.Forms;
using WinFwk.UIModules;

namespace WinFwk.UITools.Settings
{
    public partial class UISettingsModule : UIModule
    {
        public UISettingsModule()
        {
            InitializeComponent();
            Name = "Settings";
            Icon = Properties.Resources.small_gear_in;
            Summary = "Application settings";
        }

        private void UIConfigModule_Load(object sender, EventArgs e)
        {
            pgUiSettings.SelectedObject = UISettings.Instance;
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            Type type = UISettings.Instance.GetType();
            Type mgrType = typeof (UISettingsMgr<>).MakeGenericType(type);
            var meth = mgrType.GetMethod(nameof(UISettingsMgr<UISettings>.Save), BindingFlags.Public | BindingFlags.Static);
            meth.Invoke(null, new object[] {Application.ProductName, UISettings.Instance});
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Type type = UISettings.Instance.GetType();
            Type mgrType = typeof(UISettingsMgr<>).MakeGenericType(type);
            var meth = mgrType.GetMethod(nameof(UISettingsMgr<UISettings>.Load), BindingFlags.Public | BindingFlags.Static);
            var res = meth.Invoke(null, new object[] { Application.ProductName});
            UISettings.InitSettings((UISettings)res);
            pgUiSettings.SelectedObject = UISettings.Instance;
        }

        private void pgUiSettings_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            SendUISettingsChangedMessage();
        }

        public void SendUISettingsChangedMessage()
        {
            MessageBus.SendMessage(new UISettingsChangedMessage(UISettings.Instance));
        }
    }
}