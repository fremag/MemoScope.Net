using System.IO;
using System.Windows.Forms;
using MemoScope.Modules.Explorer;
using MemoScope.Modules.TypeStats;
using MemoScope.Services;
using WeifenLuo.WinFormsUI.Docking;
using WinFwk.UIMessages;
using WinFwk.UIModules;
using WinFwk.UIServices;
using WinFwk.UITools.ToolBar;
using MemoScope.Modules.Workplace;
using System;
using System.Drawing;

namespace MemoScope
{
    public partial class MemoScopeForm : UIModuleForm, IMessageListener<ClrDumpLoadedMessage>
    {
        public FileInfo[] AutoLoadFiles { get; internal set; }

        public MemoScopeForm()
        {
            InitializeComponent();
        }

        private void MemoScope_Load(object sender, System.EventArgs e)
        {
            InitModuleFactory();
            AddToolBar("Dump", 1, Properties.Resources.database_green);
            AddToolBar("Memory", 2, Properties.Resources.ddr_memory_small);
            AddToolBar("Bookmarks", 3, Properties.Resources.award_star_gold_blue);
            InitToolBars();
            var workContent = InitWorkplace(new MemoScopeWorkplace(), DockState.DockLeft);
            InitLog();
            UIServiceHelper.InitServices(msgBus);
            InitModuleFactory();
            DockModule(new ExplorerModule(), workContent, DockAlignment.Bottom);
            WindowState = FormWindowState.Maximized;

            if( AutoLoadFiles != null)
            {
                msgBus.SendMessage(new OpenDumpRequest(AutoLoadFiles));
            }
        }

        public void HandleMessage(ClrDumpLoadedMessage message)
        {
            var dump = message.ClrDump;
            UIModuleFactory.CreateModule<TypeStatModule>( tsm => tsm.Setup(dump), tsm => DockModule(tsm));
        }
    }
}