using System.ComponentModel;

namespace WinFwk.UITools.Settings
{
    public class UISettings
    {
        public static UISettings Instance { get; private set; }

        internal static void InitSettings(UISettings uiSettings)
        {
            Instance = uiSettings;
        }
    }
}