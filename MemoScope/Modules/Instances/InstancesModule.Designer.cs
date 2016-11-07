namespace MemoScope.Modules.Instances
{
    partial class InstancesModule
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
            this.dlvAdresses = new WinFwk.UITools.DefaultListView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbFields = new System.Windows.Forms.GroupBox();
            this.dtlvFields = new WinFwk.UITools.DefaultTreeListView();
            this.gbInstances = new System.Windows.Forms.GroupBox();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tspApplyfilter = new System.Windows.Forms.ToolStripButton();
            this.tsbClearFilter = new System.Windows.Forms.ToolStripButton();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.codeTriggersControl = new MemoScope.Tools.CodeTriggers.CodeTriggersControl();
            this.tsbInstancesCount = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dlvAdresses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtlvFields)).BeginInit();
            this.gbInstances.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dlvAdresses
            // 
            this.dlvAdresses.CellEditUseWholeCell = false;
            this.dlvAdresses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlvAdresses.FullRowSelect = true;
            this.dlvAdresses.HideSelection = false;
            this.dlvAdresses.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this.dlvAdresses.HighlightForegroundColor = System.Drawing.Color.Empty;
            this.dlvAdresses.Location = new System.Drawing.Point(0, 0);
            this.dlvAdresses.Name = "dlvAdresses";
            this.dlvAdresses.ShowGroups = false;
            this.dlvAdresses.ShowImagesOnSubItems = true;
            this.dlvAdresses.Size = new System.Drawing.Size(450, 266);
            this.dlvAdresses.TabIndex = 0;
            this.dlvAdresses.UseCompatibleStateImageBehavior = false;
            this.dlvAdresses.View = System.Windows.Forms.View.Details;
            this.dlvAdresses.VirtualMode = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbFields);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gbInstances);
            this.splitContainer1.Size = new System.Drawing.Size(698, 322);
            this.splitContainer1.SplitterDistance = 232;
            this.splitContainer1.TabIndex = 1;
            // 
            // gbFields
            // 
            this.gbFields.Controls.Add(this.dtlvFields);
            this.gbFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbFields.Location = new System.Drawing.Point(0, 0);
            this.gbFields.Name = "gbFields";
            this.gbFields.Size = new System.Drawing.Size(232, 322);
            this.gbFields.TabIndex = 0;
            this.gbFields.TabStop = false;
            this.gbFields.Text = "Fields";
            // 
            // dtlvFields
            // 
            this.dtlvFields.CellEditUseWholeCell = false;
            this.dtlvFields.DataSource = null;
            this.dtlvFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtlvFields.FullRowSelect = true;
            this.dtlvFields.HideSelection = false;
            this.dtlvFields.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this.dtlvFields.HighlightForegroundColor = System.Drawing.Color.Empty;
            this.dtlvFields.Location = new System.Drawing.Point(3, 18);
            this.dtlvFields.Name = "dtlvFields";
            this.dtlvFields.RootKeyValueString = "";
            this.dtlvFields.ShowGroups = false;
            this.dtlvFields.ShowImagesOnSubItems = true;
            this.dtlvFields.Size = new System.Drawing.Size(226, 301);
            this.dtlvFields.TabIndex = 0;
            this.dtlvFields.UseCompatibleStateImageBehavior = false;
            this.dtlvFields.View = System.Windows.Forms.View.Details;
            this.dtlvFields.VirtualMode = true;
            // 
            // gbInstances
            // 
            this.gbInstances.Controls.Add(this.toolStripContainer1);
            this.gbInstances.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbInstances.Location = new System.Drawing.Point(0, 0);
            this.gbInstances.Name = "gbInstances";
            this.gbInstances.Size = new System.Drawing.Size(462, 322);
            this.gbInstances.TabIndex = 1;
            this.gbInstances.TabStop = false;
            this.gbInstances.Text = "Instances";
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dlvAdresses);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(450, 266);
            this.toolStripContainer1.Location = new System.Drawing.Point(6, 23);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(450, 293);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspApplyfilter,
            this.tsbClearFilter,
            this.tsbInstancesCount});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(99, 27);
            this.toolStrip1.TabIndex = 0;
            // 
            // tspApplyfilter
            // 
            this.tspApplyfilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tspApplyfilter.Image = global::MemoScope.Properties.Resources.filter_reapply;
            this.tspApplyfilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspApplyfilter.Name = "tspApplyfilter";
            this.tspApplyfilter.Size = new System.Drawing.Size(24, 24);
            this.tspApplyfilter.Text = "Apply Filter";
            this.tspApplyfilter.Click += new System.EventHandler(this.tspApplyfilter_Click);
            // 
            // tsbClearFilter
            // 
            this.tsbClearFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbClearFilter.Image = global::MemoScope.Properties.Resources.filter_clear;
            this.tsbClearFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClearFilter.Name = "tsbClearFilter";
            this.tsbClearFilter.Size = new System.Drawing.Size(24, 24);
            this.tsbClearFilter.Text = "Clear Filter";
            this.tsbClearFilter.Click += new System.EventHandler(this.tsbClearFilter_Click);
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
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.codeTriggersControl);
            this.splitContainer2.Size = new System.Drawing.Size(698, 677);
            this.splitContainer2.SplitterDistance = 322;
            this.splitContainer2.TabIndex = 2;
            // 
            // codeTriggersControl
            // 
            this.codeTriggersControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeTriggersControl.Location = new System.Drawing.Point(0, 0);
            this.codeTriggersControl.MessageBus = null;
            this.codeTriggersControl.Name = "codeTriggersControl";
            this.codeTriggersControl.Size = new System.Drawing.Size(698, 351);
            this.codeTriggersControl.TabIndex = 0;
            // 
            // tsbInstancesCount
            // 
            this.tsbInstancesCount.Name = "tsbInstancesCount";
            this.tsbInstancesCount.Size = new System.Drawing.Size(0, 24);
            // 
            // InstancesModule
            // 
            this.Controls.Add(this.splitContainer2);
            this.Name = "InstancesModule";
            this.Size = new System.Drawing.Size(698, 677);
            ((System.ComponentModel.ISupportInitialize)(this.dlvAdresses)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbFields.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtlvFields)).EndInit();
            this.gbInstances.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
#pragma warning restore CS0618 // Le type ou le membre est obsolète

        private WinFwk.UITools.DefaultListView dlvAdresses;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gbFields;
        private WinFwk.UITools.DefaultTreeListView dtlvFields;
        private System.Windows.Forms.GroupBox gbInstances;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Tools.CodeTriggers.CodeTriggersControl codeTriggersControl;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStripButton tsbClearFilter;
        private System.Windows.Forms.ToolStripButton tspApplyfilter;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel tsbInstancesCount;
    }
}
