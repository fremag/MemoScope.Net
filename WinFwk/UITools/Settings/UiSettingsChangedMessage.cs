using WinFwk.UIMessages;

namespace WinFwk.UITools.Settings
{
    public class UISettingsChangedMessage : AbstractUIMessage
    {
        public UISettings UiSettings { get; set; }

        public UISettingsChangedMessage(UISettings uiSettings)
        {
            UiSettings = uiSettings;
        }
    }
}