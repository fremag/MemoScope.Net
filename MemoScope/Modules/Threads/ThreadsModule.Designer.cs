namespace MemoScope.Modules.Threads
{
    partial class ThreadsModule
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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.dlvThreads = new WinFwk.UITools.DefaultListView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.stackTraceModule = new MemoScope.Modules.StackTrace.StackTraceModule();
            ((System.ComponentModel.ISupportInitialize)(this.dlvThreads)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dlvThreads
            // 
            this.dlvThreads.CellEditUseWholeCell = false;
            this.dlvThreads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlvThreads.FullRowSelect = true;
            this.dlvThreads.HideSelection = false;
            this.dlvThreads.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this.dlvThreads.HighlightForegroundColor = System.Drawing.Color.Empty;
            this.dlvThreads.Location = new System.Drawing.Point(0, 0);
            this.dlvThreads.Name = "dlvThreads";
            this.dlvThreads.ShowGroups = false;
            this.dlvThreads.ShowImagesOnSubItems = true;
            this.dlvThreads.Size = new System.Drawing.Size(762, 254);
            this.dlvThreads.TabIndex = 0;
            this.dlvThreads.UseCompatibleStateImageBehavior = false;
            this.dlvThreads.View = System.Windows.Forms.View.Details;
            this.dlvThreads.VirtualMode = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dlvThreads);
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
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.stackTraceModule);
            this.splitContainer2.Size = new System.Drawing.Size(762, 225);
            this.splitContainer2.SplitterDistance = 254;
            this.splitContainer2.TabIndex = 0;
            // 
            // stacksModule1
            // 
            this.stackTraceModule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stackTraceModule.Location = new System.Drawing.Point(0, 0);
            this.stackTraceModule.Name = "stacksModule1";
            this.stackTraceModule.Size = new System.Drawing.Size(254, 225);
            this.stackTraceModule.TabIndex = 0;
            this.stackTraceModule.UIModuleParent = this.stackTraceModule;
            // 
            // ThreadsModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ThreadsModule";
            this.Size = new System.Drawing.Size(762, 483);
            ((System.ComponentModel.ISupportInitialize)(this.dlvThreads)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private WinFwk.UITools.DefaultListView dlvThreads;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private StackTrace.StackTraceModule stackTraceModule;
    }
}
