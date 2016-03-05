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

namespace MemoScope.Modules.Explorer
{
    public partial class ExplorerModule : UIModule, IMessageListener<ClrDumpLoadedMessage>
    {
        public ExplorerModule()
        {
            InitializeComponent();

            Icon = Properties.Resources.folders_explorer_small;
            Name = "Explorer";

            if (MemoScopeSettings.Instance != null)
            {
                tbRootDir.Text = MemoScopeSettings.Instance.RootDir;
            }
            dtlvExplorer.InitData<AbstractDumpExplorerData>();
            var col = dtlvExplorer.GetColumn(nameof(AbstractDumpExplorerData.DeleteCache));
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
            RefreshRootDir();
        }

        private void RefreshRootDir()
        {
            Summary = tbRootDir.Text;
            var rootDirOk = Directory.Exists(tbRootDir.Text);
            tbRootDir.BackColor = rootDirOk ? Color.LightGreen : Color.OrangeRed;

            if (rootDirOk)
            {
                dtlvExplorer.Roots= AbstractDumpExplorerData.GetItems(tbRootDir.Text);
            }
        }

        private void tbRootDir_TextChanged(object sender, System.EventArgs e)
        {
            RefreshRootDir();
        }

        private void ExplorerModule_Load(object sender, System.EventArgs e)
        {
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
                    fileInfos.AddRange(children.Select(c => c.FileInfo));
                }
            }
            MessageBus.SendMessage(new OpenDumpRequest(fileInfos));
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
    }
}
