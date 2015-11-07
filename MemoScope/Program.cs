using System;
using System.Globalization;
using System.Windows.Forms;
using WinFwk.UITools.Settings;

namespace MemoScope
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            UISettingsMgr<MemoScopeSettings>.Init(Application.ProductName);
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MemoScope());
        }
    }
}