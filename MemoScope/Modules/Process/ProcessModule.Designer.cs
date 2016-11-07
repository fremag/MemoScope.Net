using MemoScope.Tools.CodeTriggers;

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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cbClock = new System.Windows.Forms.CheckBox();
            this.btnFindProcess = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.gbProcess = new System.Windows.Forms.GroupBox();
            this.gbTriggers = new System.Windows.Forms.GroupBox();
            this.gbDumpCommands = new System.Windows.Forms.GroupBox();
            this.lblNextTick = new System.Windows.Forms.Label();
            this.cbPeriod = new System.Windows.Forms.ComboBox();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cbLoadAfterDump = new System.Windows.Forms.CheckBox();
            this.processInfoViewer = new MemoScope.Modules.Process.ProcessInfoViewer();
            this.processTriggersControl = new MemoScope.Tools.CodeTriggers.CodeTriggersControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.gbProcess.SuspendLayout();
            this.gbTriggers.SuspendLayout();
            this.gbDumpCommands.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblProcess
            // 
            this.lblProcess.AutoSize = true;
            this.lblProcess.Location = new System.Drawing.Point(58, 6);
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
            this.cbProcess.Location = new System.Drawing.Point(131, 3);
            this.cbProcess.Name = "cbProcess";
            this.cbProcess.Size = new System.Drawing.Size(493, 24);
            this.cbProcess.TabIndex = 1;
            this.cbProcess.DropDown += new System.EventHandler(this.cbProcess_DropDown);
            this.cbProcess.SelectedValueChanged += new System.EventHandler(this.cbProcess_SelectedValueChanged);
            // 
            // lblRootDir
            // 
            this.lblRootDir.AutoSize = true;
            this.lblRootDir.Location = new System.Drawing.Point(58, 33);
            this.lblRootDir.Name = "lblRootDir";
            this.lblRootDir.Size = new System.Drawing.Size(68, 17);
            this.lblRootDir.TabIndex = 4;
            this.lblRootDir.Text = "Root Dir :";
            // 
            // tbRootDir
            // 
            this.tbRootDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRootDir.Location = new System.Drawing.Point(131, 30);
            this.tbRootDir.Name = "tbRootDir";
            this.tbRootDir.ReadOnly = true;
            this.tbRootDir.Size = new System.Drawing.Size(494, 22);
            this.tbRootDir.TabIndex = 6;
            // 
            // btnDump
            // 
            this.btnDump.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDump.AutoSize = true;
            this.btnDump.Image = global::MemoScope.Properties.Resources.compile;
            this.btnDump.Location = new System.Drawing.Point(316, 10);
            this.btnDump.Name = "btnDump";
            this.btnDump.Size = new System.Drawing.Size(38, 38);
            this.btnDump.TabIndex = 7;
            this.toolTip1.SetToolTip(this.btnDump, "Dump Process Now !");
            this.btnDump.UseVisualStyleBackColor = true;
            this.btnDump.Click += new System.EventHandler(this.btnDump_Click);
            // 
            // cbClock
            // 
            this.cbClock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbClock.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbClock.AutoSize = true;
            this.cbClock.Image = global::MemoScope.Properties.Resources.clock_go;
            this.cbClock.Location = new System.Drawing.Point(272, 10);
            this.cbClock.Name = "cbClock";
            this.cbClock.Size = new System.Drawing.Size(38, 38);
            this.cbClock.TabIndex = 10;
            this.toolTip1.SetToolTip(this.cbClock, "Start timer");
            this.cbClock.UseVisualStyleBackColor = true;
            this.cbClock.CheckedChanged += new System.EventHandler(this.cbClock_CheckedChanged);
            // 
            // btnFindProcess
            // 
            this.btnFindProcess.Image = global::MemoScope.Properties.Resources.bow;
            this.btnFindProcess.Location = new System.Drawing.Point(3, 3);
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
            this.splitContainer2.Location = new System.Drawing.Point(3, 85);
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
            this.splitContainer2.Size = new System.Drawing.Size(997, 663);
            this.splitContainer2.SplitterDistance = 330;
            this.splitContainer2.TabIndex = 9;
            // 
            // gbProcess
            // 
            this.gbProcess.Controls.Add(this.processInfoViewer);
            this.gbProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbProcess.Location = new System.Drawing.Point(0, 0);
            this.gbProcess.Name = "gbProcess";
            this.gbProcess.Size = new System.Drawing.Size(997, 330);
            this.gbProcess.TabIndex = 1;
            this.gbProcess.TabStop = false;
            this.gbProcess.Text = "Process";
            // 
            // gbTriggers
            // 
            this.gbTriggers.Controls.Add(this.processTriggersControl);
            this.gbTriggers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTriggers.Location = new System.Drawing.Point(0, 0);
            this.gbTriggers.Name = "gbTriggers";
            this.gbTriggers.Size = new System.Drawing.Size(997, 329);
            this.gbTriggers.TabIndex = 0;
            this.gbTriggers.TabStop = false;
            this.gbTriggers.Text = "Triggers";
            // 
            // gbDumpCommands
            // 
            this.gbDumpCommands.Controls.Add(this.cbLoadAfterDump);
            this.gbDumpCommands.Controls.Add(this.lblNextTick);
            this.gbDumpCommands.Controls.Add(this.cbClock);
            this.gbDumpCommands.Controls.Add(this.cbPeriod);
            this.gbDumpCommands.Controls.Add(this.lblPeriod);
            this.gbDumpCommands.Controls.Add(this.btnDump);
            this.gbDumpCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDumpCommands.Location = new System.Drawing.Point(0, 0);
            this.gbDumpCommands.Name = "gbDumpCommands";
            this.gbDumpCommands.Size = new System.Drawing.Size(360, 76);
            this.gbDumpCommands.TabIndex = 10;
            this.gbDumpCommands.TabStop = false;
            this.gbDumpCommands.Text = "Dump";
            // 
            // lblNextTick
            // 
            this.lblNextTick.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNextTick.Location = new System.Drawing.Point(6, 54);
            this.lblNextTick.Name = "lblNextTick";
            this.lblNextTick.Size = new System.Drawing.Size(123, 15);
            this.lblNextTick.TabIndex = 11;
            this.lblNextTick.Visible = false;
            // 
            // cbPeriod
            // 
            this.cbPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPeriod.FormattingEnabled = true;
            this.cbPeriod.Items.AddRange(new object[] {
            "00:00:01",
            "00:00:05",
            "00:00:15",
            "00:00:30",
            "00:01:00",
            "00:05:00",
            "00:15:00",
            "00:30:00",
            "01:00:00"});
            this.cbPeriod.Location = new System.Drawing.Point(69, 17);
            this.cbPeriod.Name = "cbPeriod";
            this.cbPeriod.Size = new System.Drawing.Size(188, 24);
            this.cbPeriod.TabIndex = 9;
            this.cbPeriod.Text = "00:00:01";
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.Location = new System.Drawing.Point(6, 20);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(57, 17);
            this.lblPeriod.TabIndex = 8;
            this.lblPeriod.Text = "Period :";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(6, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnFindProcess);
            this.splitContainer1.Panel1.Controls.Add(this.lblProcess);
            this.splitContainer1.Panel1.Controls.Add(this.cbProcess);
            this.splitContainer1.Panel1.Controls.Add(this.tbRootDir);
            this.splitContainer1.Panel1.Controls.Add(this.lblRootDir);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gbDumpCommands);
            this.splitContainer1.Size = new System.Drawing.Size(991, 76);
            this.splitContainer1.SplitterDistance = 627;
            this.splitContainer1.TabIndex = 11;
            // 
            // cbLoadAfterDump
            // 
            this.cbLoadAfterDump.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbLoadAfterDump.AutoSize = true;
            this.cbLoadAfterDump.Location = new System.Drawing.Point(223, 53);
            this.cbLoadAfterDump.Name = "cbLoadAfterDump";
            this.cbLoadAfterDump.Size = new System.Drawing.Size(134, 21);
            this.cbLoadAfterDump.TabIndex = 12;
            this.cbLoadAfterDump.Text = "Load after dump";
            this.cbLoadAfterDump.UseVisualStyleBackColor = true;
            // 
            // processInfoViewer
            // 
            this.processInfoViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processInfoViewer.Location = new System.Drawing.Point(3, 18);
            this.processInfoViewer.Name = "processInfoViewer";
            this.processInfoViewer.Size = new System.Drawing.Size(991, 309);
            this.processInfoViewer.TabIndex = 0;
            // 
            // processTriggersControl
            // 
            this.processTriggersControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processTriggersControl.Location = new System.Drawing.Point(3, 18);
            this.processTriggersControl.MessageBus = null;
            this.processTriggersControl.Name = "processTriggersControl";
            this.processTriggersControl.Size = new System.Drawing.Size(991, 308);
            this.processTriggersControl.TabIndex = 0;
            // 
            // ProcessModule
            // 
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.splitContainer2);
            this.Name = "ProcessModule";
            this.Size = new System.Drawing.Size(1004, 751);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.gbProcess.ResumeLayout(false);
            this.gbTriggers.ResumeLayout(false);
            this.gbDumpCommands.ResumeLayout(false);
            this.gbDumpCommands.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private CodeTriggersControl processTriggersControl;
        private System.Windows.Forms.GroupBox gbDumpCommands;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.ComboBox cbPeriod;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.CheckBox cbClock;
        private System.Windows.Forms.Label lblNextTick;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox cbLoadAfterDump;
    }
}
