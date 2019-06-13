namespace MemoScope.Modules.Regions
{
    partial class RegionsModule
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
            this.dlvRegions = new WinFwk.UITools.DefaultListView();
            ((System.ComponentModel.ISupportInitialize)(this.dlvRegions)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultListView1
            // 
            this.dlvRegions.CellEditUseWholeCell = false;
            this.dlvRegions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlvRegions.FullRowSelect = true;
            this.dlvRegions.HideSelection = false;
            this.dlvRegions.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this.dlvRegions.HighlightForegroundColor = System.Drawing.Color.Empty;
            this.dlvRegions.Location = new System.Drawing.Point(0, 0);
            this.dlvRegions.Name = "defaultListView1";
            this.dlvRegions.ShowGroups = false;
            this.dlvRegions.ShowImagesOnSubItems = true;
            this.dlvRegions.Size = new System.Drawing.Size(762, 483);
            this.dlvRegions.TabIndex = 0;
            this.dlvRegions.UseCompatibleStateImageBehavior = false;
            this.dlvRegions.View = System.Windows.Forms.View.Details;
            this.dlvRegions.VirtualMode = true;
            // 
            // RegionsModule
            // 
            this.Controls.Add(this.dlvRegions);
            this.Name = "RegionsModule";
            this.Size = new System.Drawing.Size(762, 483);
            ((System.ComponentModel.ISupportInitialize)(this.dlvRegions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
#pragma warning restore CS0618 // Le type ou le membre est obsolète

        private WinFwk.UITools.DefaultListView dlvRegions;
    }
}
