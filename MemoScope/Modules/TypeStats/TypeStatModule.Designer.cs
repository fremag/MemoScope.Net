namespace MemoScope.Modules.TypeStats
{
    partial class TypeStatModule
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
            this.dlvTypeStats = new WinFwk.UITools.DefaultListView();
            ((System.ComponentModel.ISupportInitialize)(this.dlvTypeStats)).BeginInit();
            this.SuspendLayout();
            // 
            // dlvTypeStats
            // 
            this.dlvTypeStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlvTypeStats.FullRowSelect = true;
            this.dlvTypeStats.HideSelection = false;
            this.dlvTypeStats.Location = new System.Drawing.Point(0, 0);
            this.dlvTypeStats.Name = "dlvTypeStats";
            this.dlvTypeStats.OwnerDraw = true;
            this.dlvTypeStats.ShowGroups = false;
            this.dlvTypeStats.ShowImagesOnSubItems = true;
            this.dlvTypeStats.Size = new System.Drawing.Size(426, 405);
            this.dlvTypeStats.TabIndex = 0;
            this.dlvTypeStats.UseCompatibleStateImageBehavior = false;
            this.dlvTypeStats.View = System.Windows.Forms.View.Details;
            this.dlvTypeStats.VirtualMode = true;
            // 
            // TypeStatModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dlvTypeStats);
            this.Name = "TypeStatModule";
            this.Size = new System.Drawing.Size(426, 405);
            ((System.ComponentModel.ISupportInitialize)(this.dlvTypeStats)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private WinFwk.UITools.DefaultListView dlvTypeStats;
    }
}
