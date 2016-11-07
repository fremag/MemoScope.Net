using BrightIdeasSoftware;

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
#pragma warning disable CS0618 // Le type ou le membre est obsolète

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.dlvDumpDiff = new BrightIdeasSoftware.ObjectListView();
            this.colType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.lblSortMode = new System.Windows.Forms.Label();
            this.cbSortMode = new System.Windows.Forms.ComboBox();
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
            this.dlvDumpDiff.Location = new System.Drawing.Point(0, 43);
            this.dlvDumpDiff.Name = "dlvDumpDiff";
            this.dlvDumpDiff.ShowGroups = false;
            this.dlvDumpDiff.ShowImagesOnSubItems = true;
            this.dlvDumpDiff.Size = new System.Drawing.Size(798, 575);
            this.dlvDumpDiff.TabIndex = 1;
            this.dlvDumpDiff.UseCompatibleStateImageBehavior = false;
            this.dlvDumpDiff.View = System.Windows.Forms.View.Details;
            // 
            // lblSortMode
            // 
            this.lblSortMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSortMode.AutoSize = true;
            this.lblSortMode.Location = new System.Drawing.Point(617, 12);
            this.lblSortMode.Name = "lblSortMode";
            this.lblSortMode.Size = new System.Drawing.Size(81, 17);
            this.lblSortMode.TabIndex = 3;
            this.lblSortMode.Text = "Sort Mode :";
            // 
            // cbSortMode
            // 
            this.cbSortMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSortMode.FormattingEnabled = true;
            this.cbSortMode.Location = new System.Drawing.Point(704, 8);
            this.cbSortMode.Name = "cbSortMode";
            this.cbSortMode.Size = new System.Drawing.Size(86, 24);
            this.cbSortMode.TabIndex = 4;
            this.cbSortMode.SelectedIndexChanged += new System.EventHandler(this.cbSortMode_SelectedIndexChanged);
            // 
            // regexFilterControl
            // 
            this.regexFilterControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.regexFilterControl.Location = new System.Drawing.Point(3, 3);
            this.regexFilterControl.Name = "regexFilterControl";
            this.regexFilterControl.Size = new System.Drawing.Size(604, 34);
            this.regexFilterControl.TabIndex = 2;
            // 
            // DumpDiffModule
            // 
            this.Controls.Add(this.cbSortMode);
            this.Controls.Add(this.lblSortMode);
            this.Controls.Add(this.regexFilterControl);
            this.Controls.Add(this.dlvDumpDiff);
            this.Name = "DumpDiffModule";
            this.Size = new System.Drawing.Size(798, 618);
            ((System.ComponentModel.ISupportInitialize)(this.dlvDumpDiff)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
#pragma warning restore CS0618 // Le type ou le membre est obsolète

        private ObjectListView dlvDumpDiff;
        private BrightIdeasSoftware.OLVColumn colType;
        private Tools.RegexFilter.RegexFilterControl regexFilterControl;
        private System.Windows.Forms.Label lblSortMode;
        private System.Windows.Forms.ComboBox cbSortMode;
    }
}
