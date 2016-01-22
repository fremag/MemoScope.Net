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
            ((System.ComponentModel.ISupportInitialize)(this.dlvDumpDiff)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultListView1
            // 
            this.dlvDumpDiff.CellEditUseWholeCell = false;
            this.dlvDumpDiff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlvDumpDiff.FullRowSelect = true;
            this.dlvDumpDiff.HideSelection = false;
            this.dlvDumpDiff.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this.dlvDumpDiff.HighlightForegroundColor = System.Drawing.Color.Empty;
            this.dlvDumpDiff.Location = new System.Drawing.Point(0, 0);
            this.dlvDumpDiff.Name = "defaultListView1";
            this.dlvDumpDiff.ShowGroups = false;
            this.dlvDumpDiff.ShowImagesOnSubItems = true;
            this.dlvDumpDiff.Size = new System.Drawing.Size(762, 483);
            this.dlvDumpDiff.TabIndex = 0;
            this.dlvDumpDiff.UseCompatibleStateImageBehavior = false;
            this.dlvDumpDiff.View = System.Windows.Forms.View.Details;
            this.dlvDumpDiff.VirtualMode = true;
            // 
            // SegmentsModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dlvDumpDiff);
            this.Name = "SegmentsModule";
            this.Size = new System.Drawing.Size(762, 483);
            ((System.ComponentModel.ISupportInitialize)(this.dlvDumpDiff)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private WinFwk.UITools.DefaultListView dlvDumpDiff;
    }
}
