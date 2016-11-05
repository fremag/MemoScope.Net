namespace MemoScope.Modules.RootPath
{
    partial class RootPathModule
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
            this.dlvRootPath = new WinFwk.UITools.DefaultListView();
            ((System.ComponentModel.ISupportInitialize)(this.dlvRootPath)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultListView1
            // 
            this.dlvRootPath.CellEditUseWholeCell = false;
            this.dlvRootPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlvRootPath.FullRowSelect = true;
            this.dlvRootPath.HideSelection = false;
            this.dlvRootPath.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this.dlvRootPath.HighlightForegroundColor = System.Drawing.Color.Empty;
            this.dlvRootPath.Location = new System.Drawing.Point(0, 0);
            this.dlvRootPath.Name = "defaultListView1";
            this.dlvRootPath.ShowGroups = false;
            this.dlvRootPath.ShowImagesOnSubItems = true;
            this.dlvRootPath.Size = new System.Drawing.Size(762, 483);
            this.dlvRootPath.TabIndex = 0;
            this.dlvRootPath.UseCompatibleStateImageBehavior = false;
            this.dlvRootPath.View = System.Windows.Forms.View.Details;
            this.dlvRootPath.VirtualMode = true;
            // 
            // ModulesModule
            // 
            this.Controls.Add(this.dlvRootPath);
            this.Name = "ModulesModule";
            this.Size = new System.Drawing.Size(762, 483);
            ((System.ComponentModel.ISupportInitialize)(this.dlvRootPath)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
#pragma warning restore CS0618 // Le type ou le membre est obsolète

        private WinFwk.UITools.DefaultListView dlvRootPath;
    }
}
