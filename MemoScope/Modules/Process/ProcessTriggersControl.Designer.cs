namespace MemoScope.Modules.Process
{
    partial class ProcessTriggersControl
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dlvTriggers = new WinFwk.UITools.DefaultListView();
            this.lblCode = new System.Windows.Forms.Label();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.tbGroup = new System.Windows.Forms.TextBox();
            this.lblGroup = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.cbActive = new System.Windows.Forms.CheckBox();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsbNetTrigger = new System.Windows.Forms.ToolStripButton();
            this.tsbSaveAllTriggers = new System.Windows.Forms.ToolStripButton();
            this.tsbCloneTrigger = new System.Windows.Forms.ToolStripButton();
            this.tsbDeleteTrigger = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tslPeriod = new System.Windows.Forms.ToolStripLabel();
            this.tscbPeriod = new System.Windows.Forms.ToolStripComboBox();
            this.tsbClock = new System.Windows.Forms.ToolStripButton();
            this.tslNextTick = new System.Windows.Forms.ToolStripLabel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dlvTriggers)).BeginInit();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dlvTriggers);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lblCode);
            this.splitContainer1.Panel2.Controls.Add(this.tbCode);
            this.splitContainer1.Panel2.Controls.Add(this.tbGroup);
            this.splitContainer1.Panel2.Controls.Add(this.lblGroup);
            this.splitContainer1.Panel2.Controls.Add(this.tbName);
            this.splitContainer1.Panel2.Controls.Add(this.lblName);
            this.splitContainer1.Panel2.Controls.Add(this.cbActive);
            this.splitContainer1.Size = new System.Drawing.Size(843, 411);
            this.splitContainer1.SplitterDistance = 432;
            this.splitContainer1.TabIndex = 0;
            // 
            // dlvTriggers
            // 
            this.dlvTriggers.CellEditUseWholeCell = false;
            this.dlvTriggers.CheckBoxes = true;
            this.dlvTriggers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlvTriggers.FullRowSelect = true;
            this.dlvTriggers.HideSelection = false;
            this.dlvTriggers.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this.dlvTriggers.HighlightForegroundColor = System.Drawing.Color.Empty;
            this.dlvTriggers.Location = new System.Drawing.Point(0, 0);
            this.dlvTriggers.Name = "dlvTriggers";
            this.dlvTriggers.ShowGroups = false;
            this.dlvTriggers.ShowImagesOnSubItems = true;
            this.dlvTriggers.Size = new System.Drawing.Size(432, 411);
            this.dlvTriggers.TabIndex = 0;
            this.dlvTriggers.UseCompatibleStateImageBehavior = false;
            this.dlvTriggers.View = System.Windows.Forms.View.Details;
            this.dlvTriggers.VirtualMode = true;
            this.dlvTriggers.SelectedIndexChanged += new System.EventHandler(this.defaultListView1_SelectedIndexChanged);
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(19, 93);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(49, 17);
            this.lblCode.TabIndex = 6;
            this.lblCode.Text = "Code :";
            // 
            // tbCode
            // 
            this.tbCode.AllowDrop = true;
            this.tbCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCode.Location = new System.Drawing.Point(12, 113);
            this.tbCode.Multiline = true;
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(383, 281);
            this.tbCode.TabIndex = 5;
            this.tbCode.TextChanged += new System.EventHandler(this.tbCode_TextChanged);
            this.tbCode.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbCode_DragDrop);
            this.tbCode.DragEnter += new System.Windows.Forms.DragEventHandler(this.tbCode_DragEnter);
            // 
            // tbGroup
            // 
            this.tbGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGroup.Location = new System.Drawing.Point(176, 16);
            this.tbGroup.Name = "tbGroup";
            this.tbGroup.Size = new System.Drawing.Size(219, 22);
            this.tbGroup.TabIndex = 4;
            this.tbGroup.TextChanged += new System.EventHandler(this.tbGroup_TextChanged);
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Location = new System.Drawing.Point(111, 18);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(56, 17);
            this.lblGroup.TabIndex = 3;
            this.lblGroup.Text = "Group :";
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbName.Location = new System.Drawing.Point(84, 56);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(311, 22);
            this.tbName.TabIndex = 2;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(19, 58);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(53, 17);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name :";
            // 
            // cbActive
            // 
            this.cbActive.AutoSize = true;
            this.cbActive.Location = new System.Drawing.Point(12, 17);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(80, 21);
            this.cbActive.TabIndex = 0;
            this.cbActive.Text = "Active ?";
            this.cbActive.UseVisualStyleBackColor = true;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(846, 414);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(846, 442);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip);
            // 
            // toolStrip
            // 
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNetTrigger,
            this.tsbSaveAllTriggers,
            this.tsbCloneTrigger,
            this.tsbDeleteTrigger,
            this.toolStripSeparator1,
            this.tslPeriod,
            this.tscbPeriod,
            this.tsbClock,
            this.tslNextTick});
            this.toolStrip.Location = new System.Drawing.Point(3, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(320, 28);
            this.toolStrip.TabIndex = 0;
            // 
            // tsbNetTrigger
            // 
            this.tsbNetTrigger.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNetTrigger.Image = global::MemoScope.Properties.Resources.new_data;
            this.tsbNetTrigger.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNetTrigger.Name = "tsbNetTrigger";
            this.tsbNetTrigger.Size = new System.Drawing.Size(24, 25);
            this.tsbNetTrigger.Text = "tsbNewTrigger";
            this.tsbNetTrigger.ToolTipText = "New Trigger";
            this.tsbNetTrigger.Click += new System.EventHandler(this.tsbNetTrigger_Click);
            // 
            // tsbSaveAllTriggers
            // 
            this.tsbSaveAllTriggers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSaveAllTriggers.Image = global::MemoScope.Properties.Resources.save_data;
            this.tsbSaveAllTriggers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveAllTriggers.Name = "tsbSaveAllTriggers";
            this.tsbSaveAllTriggers.Size = new System.Drawing.Size(24, 25);
            this.tsbSaveAllTriggers.ToolTipText = "Save All Triggers";
            this.tsbSaveAllTriggers.Click += new System.EventHandler(this.tsbSaveAllTriggers_Click);
            // 
            // tsbCloneTrigger
            // 
            this.tsbCloneTrigger.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCloneTrigger.Image = global::MemoScope.Properties.Resources.application_double;
            this.tsbCloneTrigger.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCloneTrigger.Name = "tsbCloneTrigger";
            this.tsbCloneTrigger.Size = new System.Drawing.Size(24, 25);
            this.tsbCloneTrigger.ToolTipText = "Clone Trigger";
            this.tsbCloneTrigger.Click += new System.EventHandler(this.tsbCloneTrigger_Click);
            // 
            // tsbDeleteTrigger
            // 
            this.tsbDeleteTrigger.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDeleteTrigger.Image = global::MemoScope.Properties.Resources.page_delete;
            this.tsbDeleteTrigger.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteTrigger.Name = "tsbDeleteTrigger";
            this.tsbDeleteTrigger.Size = new System.Drawing.Size(24, 25);
            this.tsbDeleteTrigger.ToolTipText = "Delete Trigger";
            this.tsbDeleteTrigger.Click += new System.EventHandler(this.tsbDeleteTrigger_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // tslPeriod
            // 
            this.tslPeriod.Name = "tslPeriod";
            this.tslPeriod.Size = new System.Drawing.Size(59, 25);
            this.tslPeriod.Text = "Period :";
            // 
            // tscbPeriod
            // 
            this.tscbPeriod.AutoToolTip = true;
            this.tscbPeriod.Items.AddRange(new object[] {
            "00:00:01",
            "00:00:05",
            "00:00:10",
            "00:00:30",
            "00:01:00",
            "00:05:00",
            "00:15:00",
            "00:30:00",
            "01:00:00",
            "",
            "",
            "",
            "",
            "",
            "",
            ""});
            this.tscbPeriod.Name = "tscbPeriod";
            this.tscbPeriod.Size = new System.Drawing.Size(121, 28);
            this.tscbPeriod.Text = "00:00:01";
            // 
            // tsbClock
            // 
            this.tsbClock.CheckOnClick = true;
            this.tsbClock.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbClock.Image = global::MemoScope.Properties.Resources.clock_go;
            this.tsbClock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClock.Name = "tsbClock";
            this.tsbClock.Size = new System.Drawing.Size(24, 25);
            this.tsbClock.Text = "Start/Stop timer";
            this.tsbClock.ToolTipText = "Start";
            this.tsbClock.CheckStateChanged += new System.EventHandler(this.tsbClock_CheckStateChanged);
            this.tsbClock.Click += new System.EventHandler(this.tsbClock_Click);
            // 
            // tslNextTick
            // 
            this.tslNextTick.Name = "tslNextTick";
            this.tslNextTick.Size = new System.Drawing.Size(0, 25);
            this.tslNextTick.Visible = false;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // ProcessTriggersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "ProcessTriggersControl";
            this.Size = new System.Drawing.Size(846, 442);
            this.Load += new System.EventHandler(this.ProcessTriggers_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dlvTriggers)).EndInit();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private WinFwk.UITools.DefaultListView dlvTriggers;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tsbNetTrigger;
        private System.Windows.Forms.ToolStripButton tsbSaveAllTriggers;
        private System.Windows.Forms.ToolStripButton tsbCloneTrigger;
        private System.Windows.Forms.ToolStripButton tsbDeleteTrigger;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox tbCode;
        private System.Windows.Forms.TextBox tbGroup;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.CheckBox cbActive;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel tslPeriod;
        private System.Windows.Forms.ToolStripComboBox tscbPeriod;
        private System.Windows.Forms.ToolStripButton tsbClock;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripLabel tslNextTick;
    }
}
