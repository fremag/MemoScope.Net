namespace MemoScope.Modules.Process
{
    partial class ProcessModule
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
            this.components = new System.ComponentModel.Container();
            this.lblProcess = new System.Windows.Forms.Label();
            this.cbProcess = new System.Windows.Forms.ComboBox();
            this.lblRootDir = new System.Windows.Forms.Label();
            this.tbRootDir = new System.Windows.Forms.TextBox();
            this.btnDump = new System.Windows.Forms.Button();
            this.btnFindProcess = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.gbProcess = new System.Windows.Forms.GroupBox();
            this.processInfoViewer = new ProcessInfoViewer();
            this.gbTriggers = new System.Windows.Forms.GroupBox();
            this._processTriggersControl = new ProcessTriggersControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.gbProcess.SuspendLayout();
            this.gbTriggers.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblProcess
            // 
            this.lblProcess.AutoSize = true;
            this.lblProcess.Location = new System.Drawing.Point(74, 15);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(67, 17);
            this.lblProcess.TabIndex = 0;
            this.lblProcess.Text = "Process :";
            // 
            // cbProcess
            // 
            this.cbProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbProcess.FormattingEnabled = true;
            this.cbProcess.Location = new System.Drawing.Point(147, 12);
            this.cbProcess.Name = "cbProcess";
            this.cbProcess.Size = new System.Drawing.Size(733, 24);
            this.cbProcess.TabIndex = 1;
            this.cbProcess.DropDown += new System.EventHandler(this.cbProcess_DropDown);
            this.cbProcess.SelectedValueChanged += new System.EventHandler(this.cbProcess_SelectedValueChanged);
            // 
            // lblRootDir
            // 
            this.lblRootDir.AutoSize = true;
            this.lblRootDir.Location = new System.Drawing.Point(74, 44);
            this.lblRootDir.Name = "lblRootDir";
            this.lblRootDir.Size = new System.Drawing.Size(68, 17);
            this.lblRootDir.TabIndex = 4;
            this.lblRootDir.Text = "Root Dir :";
            // 
            // tbRootDir
            // 
            this.tbRootDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRootDir.Location = new System.Drawing.Point(147, 39);
            this.tbRootDir.Name = "tbRootDir";
            this.tbRootDir.ReadOnly = true;
            this.tbRootDir.Size = new System.Drawing.Size(733, 22);
            this.tbRootDir.TabIndex = 6;
            // 
            // btnDump
            // 
            this.btnDump.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDump.Location = new System.Drawing.Point(901, 13);
            this.btnDump.Name = "btnDump";
            this.btnDump.Size = new System.Drawing.Size(75, 23);
            this.btnDump.TabIndex = 7;
            this.btnDump.Text = "Dump !";
            this.toolTip1.SetToolTip(this.btnDump, "Dump Process Now !");
            this.btnDump.UseVisualStyleBackColor = true;
            this.btnDump.Click += new System.EventHandler(this.btnDump_Click);
            // 
            // btnFindProcess
            // 
            this.btnFindProcess.Image = global::MemoScope.Properties.Resources.bow;
            this.btnFindProcess.Location = new System.Drawing.Point(19, 12);
            this.btnFindProcess.Name = "btnFindProcess";
            this.btnFindProcess.Size = new System.Drawing.Size(49, 49);
            this.btnFindProcess.TabIndex = 8;
            this.toolTip1.SetToolTip(this.btnFindProcess, "Drag button and drop it on process window...");
            this.btnFindProcess.UseVisualStyleBackColor = true;
            this.btnFindProcess.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnFindProcess_MouseDown);
            this.btnFindProcess.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnFindProcess_MouseUp);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(3, 67);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.gbProcess);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gbTriggers);
            this.splitContainer2.Size = new System.Drawing.Size(973, 604);
            this.splitContainer2.SplitterDistance = 302;
            this.splitContainer2.TabIndex = 9;
            // 
            // gbProcess
            // 
            this.gbProcess.Controls.Add(this.processInfoViewer);
            this.gbProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbProcess.Location = new System.Drawing.Point(0, 0);
            this.gbProcess.Name = "gbProcess";
            this.gbProcess.Size = new System.Drawing.Size(973, 302);
            this.gbProcess.TabIndex = 1;
            this.gbProcess.TabStop = false;
            this.gbProcess.Text = "Process";
            // 
            // processInfoViewer
            // 
            this.processInfoViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processInfoViewer.Location = new System.Drawing.Point(3, 18);
            this.processInfoViewer.Name = "processInfoViewer";
            this.processInfoViewer.Size = new System.Drawing.Size(967, 281);
            this.processInfoViewer.TabIndex = 0;
            // 
            // gbTriggers
            // 
            this.gbTriggers.Controls.Add(this._processTriggersControl);
            this.gbTriggers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTriggers.Location = new System.Drawing.Point(0, 0);
            this.gbTriggers.Name = "gbTriggers";
            this.gbTriggers.Size = new System.Drawing.Size(973, 298);
            this.gbTriggers.TabIndex = 0;
            this.gbTriggers.TabStop = false;
            this.gbTriggers.Text = "Triggers";
            // 
            // ProcessTriggersControl
            // 
            this._processTriggersControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._processTriggersControl.Location = new System.Drawing.Point(3, 18);
            this._processTriggersControl.Name = "_processTriggersControl";
            this._processTriggersControl.Size = new System.Drawing.Size(967, 277);
            this._processTriggersControl.TabIndex = 0;
            // 
            // ProcessModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.btnFindProcess);
            this.Controls.Add(this.btnDump);
            this.Controls.Add(this.tbRootDir);
            this.Controls.Add(this.lblRootDir);
            this.Controls.Add(this.cbProcess);
            this.Controls.Add(this.lblProcess);
            this.Name = "ProcessModule";
            this.Size = new System.Drawing.Size(980, 674);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.gbProcess.ResumeLayout(false);
            this.gbTriggers.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProcess;
        private System.Windows.Forms.ComboBox cbProcess;
        private System.Windows.Forms.Label lblRootDir;
        private System.Windows.Forms.TextBox tbRootDir;
        private System.Windows.Forms.Button btnDump;
        private System.Windows.Forms.Button btnFindProcess;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox gbTriggers;
        private System.Windows.Forms.GroupBox gbProcess;
        private ProcessInfoViewer processInfoViewer;
        private ProcessTriggersControl _processTriggersControl;
    }
}
