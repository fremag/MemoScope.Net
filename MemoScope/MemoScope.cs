using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using MemoScope.Core;
using MemoScope.Modules.Explorer;
using MemoScope.Modules.TypeStats;
using MemoScope.Services;
using WeifenLuo.WinFormsUI.Docking;
using WinFwk.UIMessages;
using WinFwk.UIModules;
using WinFwk.UIServices;

namespace MemoScope
{
    public partial class MemoScope : UIModuleForm, IMessageListener<ClrDumpLoadedMessage>
    {
        public MemoScope()
        {
            InitializeComponent();
        }

        private void MemoScope_Load(object sender, System.EventArgs e)
        {
            InitToolBars();
            InitWorkplace(DockState.DockLeftAutoHide);
            InitLog();
            UIServiceHelper.InitServices(msgBus);
            DockModule(new ExplorerModule(), DockState.DockLeft, false);
            WindowState = FormWindowState.Maximized;
        }

        [UIScheduler]
        public void HandleMessage(ClrDumpLoadedMessage message)
        {
            var dump = message.ClrDump;
            var module = new TypeStatModule();
            module.Init(dump);
            DockModule(module);
        }
    }
}