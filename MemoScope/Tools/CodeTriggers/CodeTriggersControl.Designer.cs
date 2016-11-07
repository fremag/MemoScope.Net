namespace MemoScope.Tools.CodeTriggers
{
    partial class CodeTriggersControl
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dlvTriggers = new WinFwk.UITools.DefaultListView();
            this.tbCode = new ScintillaNET.Scintilla();
            this.lblCode = new System.Windows.Forms.Label();
            this.tbGroup = new System.Windows.Forms.TextBox();
            this.lblGroup = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.cbActive = new System.Windows.Forms.CheckBox();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsbNewTrigger = new System.Windows.Forms.ToolStripButton();
            this.tsbSaveAllTriggers = new System.Windows.Forms.ToolStripButton();
            this.tsbCloneTrigger = new System.Windows.Forms.ToolStripButton();
            this.tsbDeleteTrigger = new System.Windows.Forms.ToolStripButton();
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
            this.splitContainer1.Panel2.Controls.Add(this.tbCode);
            this.splitContainer1.Panel2.Controls.Add(this.lblCode);
            this.splitContainer1.Panel2.Controls.Add(this.tbGroup);
            this.splitContainer1.Panel2.Controls.Add(this.lblGroup);
            this.splitContainer1.Panel2.Controls.Add(this.tbName);
            this.splitContainer1.Panel2.Controls.Add(this.lblName);
            this.splitContainer1.Panel2.Controls.Add(this.cbActive);
            this.splitContainer1.Size = new System.Drawing.Size(843, 412);
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
            this.dlvTriggers.Location = new System.Drawing.Point(0, 0);
            this.dlvTriggers.Name = "dlvTriggers";
            this.dlvTriggers.ShowGroups = false;
            this.dlvTriggers.ShowImagesOnSubItems = true;
            this.dlvTriggers.Size = new System.Drawing.Size(432, 412);
            this.dlvTriggers.TabIndex = 0;
            this.dlvTriggers.UseCompatibleStateImageBehavior = false;
            this.dlvTriggers.View = System.Windows.Forms.View.Details;
            this.dlvTriggers.VirtualMode = true;
            this.dlvTriggers.SelectedIndexChanged += new System.EventHandler(this.dlvTriggers_SelectedIndexChanged);
            // 
            // tbCode
            // 
            this.tbCode.AllowDrop = true;
            this.tbCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCode.Location = new System.Drawing.Point(12, 125);
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(383, 284);
            this.tbCode.TabIndex = 7;
            this.tbCode.UseTabs = false;
            this.tbCode.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbCode_DragDrop);
            this.tbCode.DragEnter += new System.Windows.Forms.DragEventHandler(this.tbCode_DragEnter);
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
            // tbGroup
            // 
            this.tbGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGroup.Location = new System.Drawing.Point(176, 16);
            this.tbGroup.Name = "tbGroup";
            this.tbGroup.Size = new System.Drawing.Size(219, 22);
            this.tbGroup.TabIndex = 4;
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
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(846, 415);
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
            this.tsbNewTrigger,
            this.tsbSaveAllTriggers,
            this.tsbCloneTrigger,
            this.tsbDeleteTrigger});
            this.toolStrip.Location = new System.Drawing.Point(3, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(108, 27);
            this.toolStrip.TabIndex = 0;
            // 
            // tsbNetTrigger
            // 
            this.tsbNewTrigger.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNewTrigger.Image = global::MemoScope.Properties.Resources.new_data;
            this.tsbNewTrigger.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNewTrigger.Name = "tsbNetTrigger";
            this.tsbNewTrigger.Size = new System.Drawing.Size(24, 24);
            this.tsbNewTrigger.Text = "tsbNewTrigger";
            this.tsbNewTrigger.ToolTipText = "New Trigger";
            this.tsbNewTrigger.Click += new System.EventHandler(this.tsbNewTrigger_Click);
            // 
            // tsbSaveAllTriggers
            // 
            this.tsbSaveAllTriggers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSaveAllTriggers.Image = global::MemoScope.Properties.Resources.save_data;
            this.tsbSaveAllTriggers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveAllTriggers.Name = "tsbSaveAllTriggers";
            this.tsbSaveAllTriggers.Size = new System.Drawing.Size(24, 24);
            this.tsbSaveAllTriggers.ToolTipText = "Save All Triggers";
            this.tsbSaveAllTriggers.Click += new System.EventHandler(this.tsbSaveAllTriggers_Click);
            // 
            // tsbCloneTrigger
            // 
            this.tsbCloneTrigger.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCloneTrigger.Image = global::MemoScope.Properties.Resources.application_double;
            this.tsbCloneTrigger.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCloneTrigger.Name = "tsbCloneTrigger";
            this.tsbCloneTrigger.Size = new System.Drawing.Size(24, 24);
            this.tsbCloneTrigger.ToolTipText = "Clone Trigger";
            this.tsbCloneTrigger.Click += new System.EventHandler(this.tsbCloneTrigger_Click);
            // 
            // tsbDeleteTrigger
            // 
            this.tsbDeleteTrigger.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDeleteTrigger.Image = global::MemoScope.Properties.Resources.page_delete;
            this.tsbDeleteTrigger.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteTrigger.Name = "tsbDeleteTrigger";
            this.tsbDeleteTrigger.Size = new System.Drawing.Size(24, 24);
            this.tsbDeleteTrigger.ToolTipText = "Delete Trigger";
            this.tsbDeleteTrigger.Click += new System.EventHandler(this.tsbDeleteTrigger_Click);
            // 
            // CodeTriggersControl
            // 
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "CodeTriggersControl";
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
#pragma warning restore CS0618 // Le type ou le membre est obsolète

        private System.Windows.Forms.SplitContainer splitContainer1;
        private WinFwk.UITools.DefaultListView dlvTriggers;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tsbNewTrigger;
        private System.Windows.Forms.ToolStripButton tsbSaveAllTriggers;
        private System.Windows.Forms.ToolStripButton tsbCloneTrigger;
        private System.Windows.Forms.ToolStripButton tsbDeleteTrigger;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox tbGroup;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.CheckBox cbActive;
        private System.Windows.Forms.Timer timer;
        private ScintillaNET.Scintilla tbCode;
    }
}
