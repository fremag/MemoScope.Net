using System.IO;
using System.Windows.Forms;
using MemoScope.Modules.Explorer;
using MemoScope.Modules.TypeStats;
using MemoScope.Services;
using WeifenLuo.WinFormsUI.Docking;
using WinFwk.UIMessages;
using WinFwk.UIModules;
using WinFwk.UIServices;
using MemoScope.Modules.Workplace;
using System.Linq;
using WinFwk.UITools.Settings;
using ScintillaNET;
using MemoScope.Core.Helpers;

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
            UIServiceHelper.InitServices(msgBus);
            AddToolBar("Dump", 1, Properties.Resources.database_green);
            AddToolBar("Memory", 2, Properties.Resources.ddr_memory_small);
            AddToolBar("Bookmarks",3, Properties.Resources.award_star_gold_blue);
            AddToolBar("Threads", 4, Properties.Resources.processor_small);
            AddToolBar("Analysis", 5, Properties.Resources.perfomance_analysis);
            InitToolBars();

            var workContent = InitWorkplace(new MemoScopeWorkplace(), DockState.DockLeft );
            InitLog();
            RegisterSkinAction(typeof(Scintilla), ApplyColorsScintilla);
            var mod = DockModule(new ExplorerModule(), workContent, DockAlignment.Bottom);
            DockState dockState;
            if( MemoScopeSettings.Instance.InitialPosition == DockPanelPosition.Left)
            {
                dockState = MemoScopeSettings.Instance.Visible ? DockState.DockLeft: DockState.DockLeftAutoHide;
            }
            else
            {
                dockState = MemoScopeSettings.Instance.Visible ? DockState.DockRight:DockState.DockRightAutoHide;
            }
            workContent.DockState = mod.DockState = dockState;

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

        private void MemoScopeForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void MemoScopeForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            var fileInfos = files.Select(f => new FileInfo(f));
            var filteredFileInfos = fileInfos.Where( 
                fi => fi.Extension.Equals(".dmp", System.StringComparison.InvariantCultureIgnoreCase)
            );
            if (filteredFileInfos.Any())
            {
                msgBus.SendMessage(new OpenDumpRequest(filteredFileInfos));
                var directory = filteredFileInfos.First().DirectoryName;
                UIModuleFactory.CreateModule<ExplorerModule>(module => { module.SetUp(directory); }, module => DockModule(module, DockState.DockLeft));
            }
            else
            {
                MessageBox.Show("Dropped files must have a .dmp extension !");
            }
        }

        private void ApplyColorsScintilla(Control control, UISettings uiSettings)
        {
            Scintilla codeEditor = control as Scintilla;
            if (codeEditor == null)
            {
                return;
            }

            codeEditor.SetWhitespaceBackColor(true, uiSettings.BackgroundColor);
            foreach (var style in codeEditor.Styles)
            {
                style.BackColor = uiSettings.BackgroundColor;
            }
        }

        public override void HandleMessage(UISettingsChangedMessage message)
        {
            base.HandleMessage(message);
            TypeHelpers.ResetCaches();
        }

    }
}