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
            this.colType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.regexFilterControl = new MemoScope.Tools.RegexFilter.RegexFilterControl();
            ((System.ComponentModel.ISupportInitialize)(this.dlvDumpDiff)).BeginInit();
            this.SuspendLayout();
            // 
            // dlvDumpDiff
            // 
            this.dlvDumpDiff.AllColumns.Add(this.colType);
            this.dlvDumpDiff.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dlvDumpDiff.CellEditUseWholeCell = false;
            this.dlvDumpDiff.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colType});
            this.dlvDumpDiff.Cursor = System.Windows.Forms.Cursors.Default;
            this.dlvDumpDiff.FullRowSelect = true;
            this.dlvDumpDiff.HideSelection = false;
            this.dlvDumpDiff.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this.dlvDumpDiff.HighlightForegroundColor = System.Drawing.Color.Empty;
            this.dlvDumpDiff.Location = new System.Drawing.Point(0, 31);
            this.dlvDumpDiff.Name = "dlvDumpDiff";
            this.dlvDumpDiff.ShowGroups = false;
            this.dlvDumpDiff.ShowImagesOnSubItems = true;
            this.dlvDumpDiff.Size = new System.Drawing.Size(859, 553);
            this.dlvDumpDiff.TabIndex = 1;
            this.dlvDumpDiff.UseCompatibleStateImageBehavior = false;
            this.dlvDumpDiff.View = System.Windows.Forms.View.Details;
            this.dlvDumpDiff.VirtualMode = true;
            // 
            // regexFilterControl1
            // 
            this.regexFilterControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.regexFilterControl.Location = new System.Drawing.Point(3, 3);
            this.regexFilterControl.Name = "regexFilterControl1";
            this.regexFilterControl.Size = new System.Drawing.Size(853, 24);
            this.regexFilterControl.TabIndex = 2;
            // 
            // DumpDiffModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.regexFilterControl);
            this.Controls.Add(this.dlvDumpDiff);
            this.Name = "DumpDiffModule";
            this.Size = new System.Drawing.Size(859, 584);
            ((System.ComponentModel.ISupportInitialize)(this.dlvDumpDiff)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private WinFwk.UITools.DefaultListView dlvDumpDiff;
        private BrightIdeasSoftware.OLVColumn colType;
        private Tools.RegexFilter.RegexFilterControl regexFilterControl;
    }
}
