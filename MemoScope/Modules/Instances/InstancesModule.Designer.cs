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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.instanceFilter1 = new MemoScope.Modules.Instances.InstanceFilter();
            ((System.ComponentModel.ISupportInitialize)(this.dlvAdresses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtlvFields)).BeginInit();
            this.gbInstances.SuspendLayout();
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
            this.dlvAdresses.Location = new System.Drawing.Point(3, 18);
            this.dlvAdresses.Name = "dlvAdresses";
            this.dlvAdresses.ShowGroups = false;
            this.dlvAdresses.ShowImagesOnSubItems = true;
            this.dlvAdresses.Size = new System.Drawing.Size(370, 251);
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
            this.splitContainer1.Size = new System.Drawing.Size(570, 272);
            this.splitContainer1.SplitterDistance = 190;
            this.splitContainer1.TabIndex = 1;
            // 
            // gbFields
            // 
            this.gbFields.Controls.Add(this.dtlvFields);
            this.gbFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbFields.Location = new System.Drawing.Point(0, 0);
            this.gbFields.Name = "gbFields";
            this.gbFields.Size = new System.Drawing.Size(190, 272);
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
            this.dtlvFields.Size = new System.Drawing.Size(184, 251);
            this.dtlvFields.TabIndex = 0;
            this.dtlvFields.UseCompatibleStateImageBehavior = false;
            this.dtlvFields.View = System.Windows.Forms.View.Details;
            this.dtlvFields.VirtualMode = true;
            // 
            // gbInstances
            // 
            this.gbInstances.Controls.Add(this.dlvAdresses);
            this.gbInstances.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbInstances.Location = new System.Drawing.Point(0, 0);
            this.gbInstances.Name = "gbInstances";
            this.gbInstances.Size = new System.Drawing.Size(376, 272);
            this.gbInstances.TabIndex = 1;
            this.gbInstances.TabStop = false;
            this.gbInstances.Text = "Instances";
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
            this.splitContainer2.Panel2.Controls.Add(this.instanceFilter1);
            this.splitContainer2.Size = new System.Drawing.Size(570, 544);
            this.splitContainer2.SplitterDistance = 272;
            this.splitContainer2.TabIndex = 2;
            // 
            // instanceFilter1
            // 
            this.instanceFilter1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.instanceFilter1.Location = new System.Drawing.Point(0, 0);
            this.instanceFilter1.Name = "instanceFilter1";
            this.instanceFilter1.Size = new System.Drawing.Size(570, 268);
            this.instanceFilter1.TabIndex = 0;
            // 
            // InstancesModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer2);
            this.Name = "InstancesModule";
            this.Size = new System.Drawing.Size(570, 544);
            ((System.ComponentModel.ISupportInitialize)(this.dlvAdresses)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbFields.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtlvFields)).EndInit();
            this.gbInstances.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private WinFwk.UITools.DefaultListView dlvAdresses;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gbFields;
        private WinFwk.UITools.DefaultTreeListView dtlvFields;
        private System.Windows.Forms.GroupBox gbInstances;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private InstanceFilter instanceFilter1;
    }
}
