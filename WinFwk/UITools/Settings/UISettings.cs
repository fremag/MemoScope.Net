using System.ComponentModel;

namespace WinFwk.UITools.Settings
{
    public class UISettings
    {

        [Editor(typeof (System.Windows.Forms.Design.FolderNameEditor), typeof (System.Drawing.Design.UITypeEditor))]
        public string RootDir { get; set; }

        public static UISettings Instance { get; private set; }

        internal static void InitSettings(UISettings uiSettings)
        {
            Instance = uiSettings;
        }
    }
}