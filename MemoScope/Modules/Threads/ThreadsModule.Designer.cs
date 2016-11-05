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
#pragma warning disable CS0618 // Le type ou le membre est obsolète

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
            this.stackModule = new MemoScope.Modules.Stack.StackModule();
            this.gbThreads = new System.Windows.Forms.GroupBox();
            this.gbCallStack = new System.Windows.Forms.GroupBox();
            this.gbStack = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dlvThreads)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.gbThreads.SuspendLayout();
            this.gbCallStack.SuspendLayout();
            this.gbStack.SuspendLayout();
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
            this.dlvThreads.Location = new System.Drawing.Point(3, 18);
            this.dlvThreads.Name = "dlvThreads";
            this.dlvThreads.ShowGroups = false;
            this.dlvThreads.ShowImagesOnSubItems = true;
            this.dlvThreads.Size = new System.Drawing.Size(756, 233);
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
            this.splitContainer1.Panel1.Controls.Add(this.gbThreads);
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
            this.splitContainer2.Panel1.Controls.Add(this.gbCallStack);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gbStack);
            this.splitContainer2.Size = new System.Drawing.Size(762, 225);
            this.splitContainer2.SplitterDistance = 254;
            this.splitContainer2.TabIndex = 0;
            // 
            // stackTraceModule
            // 
            this.stackTraceModule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stackTraceModule.Location = new System.Drawing.Point(3, 18);
            this.stackTraceModule.Name = "stackTraceModule";
            this.stackTraceModule.Size = new System.Drawing.Size(248, 204);
            this.stackTraceModule.TabIndex = 0;
            this.stackTraceModule.UIModuleParent = this.stackTraceModule;
            // 
            // stackModule
            // 
            this.stackModule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stackModule.Location = new System.Drawing.Point(3, 18);
            this.stackModule.Name = "stackModule";
            this.stackModule.Size = new System.Drawing.Size(498, 204);
            this.stackModule.TabIndex = 0;
            this.stackModule.UIModuleParent = this.stackModule;
            // 
            // gbThreads
            // 
            this.gbThreads.Controls.Add(this.dlvThreads);
            this.gbThreads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbThreads.Location = new System.Drawing.Point(0, 0);
            this.gbThreads.Name = "gbThreads";
            this.gbThreads.Size = new System.Drawing.Size(762, 254);
            this.gbThreads.TabIndex = 1;
            this.gbThreads.TabStop = false;
            this.gbThreads.Text = "Threads";
            // 
            // gbCallStack
            // 
            this.gbCallStack.Controls.Add(this.stackTraceModule);
            this.gbCallStack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCallStack.Location = new System.Drawing.Point(0, 0);
            this.gbCallStack.Name = "gbCallStack";
            this.gbCallStack.Size = new System.Drawing.Size(254, 225);
            this.gbCallStack.TabIndex = 2;
            this.gbCallStack.TabStop = false;
            this.gbCallStack.Text = "Call Stack";
            // 
            // gbStack
            // 
            this.gbStack.Controls.Add(this.stackModule);
            this.gbStack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbStack.Location = new System.Drawing.Point(0, 0);
            this.gbStack.Name = "gbStack";
            this.gbStack.Size = new System.Drawing.Size(504, 225);
            this.gbStack.TabIndex = 2;
            this.gbStack.TabStop = false;
            this.gbStack.Text = "Stack";
            // 
            // ThreadsModule
            // 
            this.Controls.Add(this.splitContainer1);
            this.Name = "ThreadsModule";
            this.Size = new System.Drawing.Size(762, 483);
            ((System.ComponentModel.ISupportInitialize)(this.dlvThreads)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.gbThreads.ResumeLayout(false);
            this.gbCallStack.ResumeLayout(false);
            this.gbStack.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
#pragma warning restore CS0618 // Le type ou le membre est obsolète

        private WinFwk.UITools.DefaultListView dlvThreads;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private StackTrace.StackTraceModule stackTraceModule;
        private Stack.StackModule stackModule;
        private System.Windows.Forms.GroupBox gbThreads;
        private System.Windows.Forms.GroupBox gbCallStack;
        private System.Windows.Forms.GroupBox gbStack;
    }
}
