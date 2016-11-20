namespace MemoScope.Modules.Bookmarks
{
    partial class BookmarkModule
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
            this.dlvBookmarks = new WinFwk.UITools.DefaultListView();
            ((System.ComponentModel.ISupportInitialize)(this.dlvBookmarks)).BeginInit();
            this.SuspendLayout();
            // 
            // dlvBookmarks
            // 
            this.dlvBookmarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlvBookmarks.FullRowSelect = true;
            this.dlvBookmarks.HideSelection = false;
            this.dlvBookmarks.Location = new System.Drawing.Point(0, 0);
            this.dlvBookmarks.Name = "dlvBookmarks";
            this.dlvBookmarks.OwnerDraw = true;
            this.dlvBookmarks.ShowGroups = false;
            this.dlvBookmarks.ShowImagesOnSubItems = true;
            this.dlvBookmarks.Size = new System.Drawing.Size(568, 548);
            this.dlvBookmarks.TabIndex = 0;
            this.dlvBookmarks.UseCompatibleStateImageBehavior = false;
            this.dlvBookmarks.View = System.Windows.Forms.View.Details;
            this.dlvBookmarks.VirtualMode = true;
            // 
            // BookmarkModule
            // 
            this.Controls.Add(this.dlvBookmarks);
            this.Name = "BookmarkModule";
            this.Size = new System.Drawing.Size(568, 548);
            ((System.ComponentModel.ISupportInitialize)(this.dlvBookmarks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private WinFwk.UITools.DefaultListView dlvBookmarks;
    }
}
