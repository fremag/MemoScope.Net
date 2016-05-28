namespace MemoScope.Modules.ClrRoots
{
    partial class ClrRootsModule
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
            this.dlvClrRoots = new WinFwk.UITools.DefaultListView();
            ((System.ComponentModel.ISupportInitialize)(this.dlvClrRoots)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultListView1
            // 
            this.dlvClrRoots.CellEditUseWholeCell = false;
            this.dlvClrRoots.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlvClrRoots.FullRowSelect = true;
            this.dlvClrRoots.HideSelection = false;
            this.dlvClrRoots.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this.dlvClrRoots.HighlightForegroundColor = System.Drawing.Color.Empty;
            this.dlvClrRoots.Location = new System.Drawing.Point(0, 0);
            this.dlvClrRoots.Name = "defaultListView1";
            this.dlvClrRoots.ShowGroups = false;
            this.dlvClrRoots.ShowImagesOnSubItems = true;
            this.dlvClrRoots.Size = new System.Drawing.Size(762, 483);
            this.dlvClrRoots.TabIndex = 0;
            this.dlvClrRoots.UseCompatibleStateImageBehavior = false;
            this.dlvClrRoots.View = System.Windows.Forms.View.Details;
            this.dlvClrRoots.VirtualMode = true;
            // 
            // ModulesModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dlvClrRoots);
            this.Name = "ModulesModule";
            this.Size = new System.Drawing.Size(762, 483);
            ((System.ComponentModel.ISupportInitialize)(this.dlvClrRoots)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
#pragma warning restore CS0618 // Le type ou le membre est obsolète

        private WinFwk.UITools.DefaultListView dlvClrRoots;
    }
}
