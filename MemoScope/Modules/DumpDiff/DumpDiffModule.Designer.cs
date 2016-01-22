namespace MemoScope.Modules.DumpDiff
{
    partial class DumpDiffModule
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
            this.dlvDumpDiff = new WinFwk.UITools.DefaultListView();
            this.dlvTypes = new WinFwk.UITools.DefaultListView();
            this.colType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.dlvDumpDiff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dlvTypes)).BeginInit();
            this.SuspendLayout();
            // 
            // dlvDumpDiff
            // 
            this.dlvDumpDiff.CellEditUseWholeCell = false;
            this.dlvDumpDiff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlvDumpDiff.FullRowSelect = true;
            this.dlvDumpDiff.HideSelection = false;
            this.dlvDumpDiff.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this.dlvDumpDiff.HighlightForegroundColor = System.Drawing.Color.Empty;
            this.dlvDumpDiff.Location = new System.Drawing.Point(0, 0);
            this.dlvDumpDiff.Name = "dlvDumpDiff";
            this.dlvDumpDiff.ShowGroups = false;
            this.dlvDumpDiff.ShowImagesOnSubItems = true;
            this.dlvDumpDiff.Size = new System.Drawing.Size(762, 483);
            this.dlvDumpDiff.TabIndex = 0;
            this.dlvDumpDiff.UseCompatibleStateImageBehavior = false;
            this.dlvDumpDiff.View = System.Windows.Forms.View.Details;
            this.dlvDumpDiff.VirtualMode = true;
            // 
            // defaultListView1
            // 
            this.dlvTypes.AllColumns.Add(this.colType);
            this.dlvTypes.CellEditUseWholeCell = false;
            this.dlvTypes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colType});
            this.dlvTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlvTypes.FullRowSelect = true;
            this.dlvTypes.HideSelection = false;
            this.dlvTypes.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this.dlvTypes.HighlightForegroundColor = System.Drawing.Color.Empty;
            this.dlvTypes.Location = new System.Drawing.Point(0, 0);
            this.dlvTypes.Name = "defaultListView1";
            this.dlvTypes.ShowGroups = false;
            this.dlvTypes.ShowImagesOnSubItems = true;
            this.dlvTypes.Size = new System.Drawing.Size(762, 483);
            this.dlvTypes.TabIndex = 1;
            this.dlvTypes.UseCompatibleStateImageBehavior = false;
            this.dlvTypes.View = System.Windows.Forms.View.Details;
            this.dlvTypes.VirtualMode = true;
            // 
            // DumpDiffModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dlvTypes);
            this.Controls.Add(this.dlvDumpDiff);
            this.Name = "DumpDiffModule";
            this.Size = new System.Drawing.Size(762, 483);
            ((System.ComponentModel.ISupportInitialize)(this.dlvDumpDiff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dlvTypes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private WinFwk.UITools.DefaultListView dlvDumpDiff;
        private WinFwk.UITools.DefaultListView dlvTypes;
        private BrightIdeasSoftware.OLVColumn colType;
    }
}
