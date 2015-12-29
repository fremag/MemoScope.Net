using System;
using System.Globalization;
using System.IO;
using System.Linq;
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
        private static void Main(string[] args)
        {
            UISettingsMgr<MemoScopeSettings>.Init(Application.ProductName);
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var memoScopeForm = new MemoScopeForm();
            FileInfo[] fileInfos = args.Select(arg => new FileInfo(arg)).ToArray();
            memoScopeForm.AutoLoadFiles = fileInfos;
            Application.Run(memoScopeForm);
        }
    }
}