using System;
using System.Windows.Forms;
using WinFwk.UITools.Settings;

namespace DemoWinFwk
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            UISettingsMgr<MySettings>.Init(Application.ProductName);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}