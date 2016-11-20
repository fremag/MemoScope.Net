namespace MemoScope.Modules.ThreadPool
{
    partial class ThreadPoolModule
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
#pragma warning disable CS0618 // Le type ou le membre est obsolète

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.pgThreadPool = new System.Windows.Forms.PropertyGrid();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dlvNativeWorkItem = new WinFwk.UITools.DefaultListView();
            this.dlvManagedWorkItem = new WinFwk.UITools.DefaultListView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dlvNativeWorkItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dlvManagedWorkItem)).BeginInit();
            this.SuspendLayout();
            // 
            // pgThreadPool
            // 
            this.pgThreadPool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgThreadPool.Location = new System.Drawing.Point(0, 0);
            this.pgThreadPool.Name = "pgThreadPool";
            this.pgThreadPool.Size = new System.Drawing.Size(254, 483);
            this.pgThreadPool.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pgThreadPool);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(762, 483);
            this.splitContainer1.SplitterDistance = 254;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dlvNativeWorkItem);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dlvManagedWorkItem);
            this.splitContainer2.Size = new System.Drawing.Size(504, 483);
            this.splitContainer2.SplitterDistance = 154;
            this.splitContainer2.TabIndex = 0;
            // 
            // defaultListView1
            // 
            this.dlvNativeWorkItem.CellEditUseWholeCell = false;
            this.dlvNativeWorkItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlvNativeWorkItem.FullRowSelect = true;
            this.dlvNativeWorkItem.HideSelection = false;
            this.dlvNativeWorkItem.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this.dlvNativeWorkItem.HighlightForegroundColor = System.Drawing.Color.Empty;
            this.dlvNativeWorkItem.Location = new System.Drawing.Point(0, 0);
            this.dlvNativeWorkItem.Name = "defaultListView1";
            this.dlvNativeWorkItem.ShowGroups = false;
            this.dlvNativeWorkItem.ShowImagesOnSubItems = true;
            this.dlvNativeWorkItem.Size = new System.Drawing.Size(504, 154);
            this.dlvNativeWorkItem.TabIndex = 0;
            this.dlvNativeWorkItem.UseCompatibleStateImageBehavior = false;
            this.dlvNativeWorkItem.View = System.Windows.Forms.View.Details;
            this.dlvNativeWorkItem.VirtualMode = true;
            // 
            // defaultListView2
            // 
            this.dlvManagedWorkItem.CellEditUseWholeCell = false;
            this.dlvManagedWorkItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlvManagedWorkItem.FullRowSelect = true;
            this.dlvManagedWorkItem.HideSelection = false;
            this.dlvManagedWorkItem.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this.dlvManagedWorkItem.HighlightForegroundColor = System.Drawing.Color.Empty;
            this.dlvManagedWorkItem.Location = new System.Drawing.Point(0, 0);
            this.dlvManagedWorkItem.Name = "defaultListView2";
            this.dlvManagedWorkItem.ShowGroups = false;
            this.dlvManagedWorkItem.ShowImagesOnSubItems = true;
            this.dlvManagedWorkItem.Size = new System.Drawing.Size(504, 325);
            this.dlvManagedWorkItem.TabIndex = 1;
            this.dlvManagedWorkItem.UseCompatibleStateImageBehavior = false;
            this.dlvManagedWorkItem.View = System.Windows.Forms.View.Details;
            this.dlvManagedWorkItem.VirtualMode = true;
            // 
            // ThreadPoolModule
            // 
            this.Controls.Add(this.splitContainer1);
            this.Name = "ThreadPoolModule";
            this.Size = new System.Drawing.Size(762, 483);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dlvNativeWorkItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dlvManagedWorkItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
#pragma warning restore CS0618 // Le type ou le membre est obsolète

        private System.Windows.Forms.PropertyGrid pgThreadPool;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private WinFwk.UITools.DefaultListView dlvNativeWorkItem;
        private WinFwk.UITools.DefaultListView dlvManagedWorkItem;
    }
}
