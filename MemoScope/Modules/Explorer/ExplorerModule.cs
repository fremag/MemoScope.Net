using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BrightIdeasSoftware;
using WinFwk.UIModules;
using System;
using WinFwk.UIMessages;
using MemoScope.Services;
using MemoScope.Modules.Process;
using WinFwk.UITools.Settings;

namespace MemoScope.Modules.Explorer
{
    public partial class ExplorerModule : UIModule, 
        IMessageListener<ClrDumpLoadedMessage>,
        IMessageListener<ProcessDumpedMessage>
    {
        public ExplorerModule()
        {
            InitializeComponent();

            Icon = Properties.Resources.folders_explorer_small;
            Name = "Explorer";

            dtlvExplorer.InitData<AbstractDumpExplorerData>();
            var col = dtlvExplorer[nameof(AbstractDumpExplorerData.DeleteCache)];
            col.IsButton = true;
            col.ButtonSizing = OLVColumn.ButtonSizingMode.CellBounds;

            dtlvExplorer.ButtonClick += (o, e) =>
            {
                var rowObj = e.Model;
                var data = rowObj as AbstractDumpExplorerData;
                var cachePath = data.GetCachePath();
                if(cachePath != null && File.Exists(cachePath) ) {
                    try {
                        File.Delete(cachePath);
                    }
                    catch (Exception ex)
                    {
                        Log("Can't delete file: " + cachePath, ex);
                    }
                }
                dtlvExplorer.RefreshObject(rowObj);
            };
        }

        private void RefreshRootDir()
        {
            Summary = tbRootDir.Text;
            var rootDirOk = Directory.Exists(tbRootDir.Text);
            tbRootDir.BackColor = rootDirOk ? Color.LightGreen : Color.OrangeRed;

            if (rootDirOk)
            {
                dtlvExplorer.Roots= AbstractDumpExplorerData.GetItems(tbRootDir.Text);
                dtlvExplorer.Refresh();
                MemoScopeSettings.Instance.RootDir = tbRootDir.Text;
                MemoScopeSettings.Instance.Save();
                MessageBus.SendMessage(new UISettingsChangedMessage(UISettings.Instance));
            }
        }

        private void tbRootDir_TextChanged(object sender, System.EventArgs e)
        {
           RefreshRootDir();
        }

        private void ExplorerModule_Load(object sender, System.EventArgs e)
        {
            if (MemoScopeSettings.Instance != null)
            {
                tbRootDir.Text = MemoScopeSettings.Instance.RootDir;
            }

            RefreshRootDir();
        }

        private void dtlvExplorer_CellClick(object sender, CellClickEventArgs e)
        {
            if (e.ClickCount != 2)
            {
                return;
            }
            var data = e.Model as AbstractDumpExplorerData;
            if (data == null)
            {
                return;
            }
            OpenFilesFromData(new[] {data});
        }

        private void OpenFilesFromData(IEnumerable<AbstractDumpExplorerData> datas)
        {
            List<FileInfo> fileInfos = new List<FileInfo>();
            foreach (var data in datas)
            {
                var children = data.Children;
                if (children == null && data.FileInfo != null)
                {
                    fileInfos.Add(data.FileInfo);
                }
                if (children != null)
                {
                    fileInfos.AddRange(children.Where(c => c.FileInfo != null).Select(c => c.FileInfo));
                }
            }
            MessageBus.SendMessage(new OpenDumpRequest(fileInfos));
        }

        internal void SetUp(string directory)
        {
            tbRootDir.Text = directory;
            RefreshRootDir();
        }

        private void btnLoad_Click(object sender, System.EventArgs e)
        {
            var fileInfos = dtlvExplorer.CheckedObjects.OfType<AbstractDumpExplorerData>().Where(data => data.FileInfo != null).Select(data => data.FileInfo).ToList();
            MessageBus.SendMessage(new OpenDumpRequest(fileInfos));
        }

        private void btnRootDir_Click(object sender, System.EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog {ShowNewFolderButton = true, SelectedPath = tbRootDir.Text};

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tbRootDir.Text = dialog.SelectedPath;
            }
        }

        void IMessageListener<ClrDumpLoadedMessage>.HandleMessage(ClrDumpLoadedMessage message)
        {
            var path = message.ClrDump.DumpPath;
            foreach(AbstractDumpExplorerData data in dtlvExplorer.Objects)
            {
                if( data.FileInfo != null && data.FileInfo.FullName == path)
                {
                    dtlvExplorer.RefreshObject(data);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshRootDir();
        }

        public void HandleMessage(ProcessDumpedMessage message)
        {
            RefreshRootDir();
        }
    }
}
