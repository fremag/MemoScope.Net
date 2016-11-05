namespace MemoScope.Modules.Handles
{
    partial class HandlesModule
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
            this.dlvHandles = new WinFwk.UITools.DefaultListView();
            ((System.ComponentModel.ISupportInitialize)(this.dlvHandles)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultListView1
            // 
            this.dlvHandles.CellEditUseWholeCell = false;
            this.dlvHandles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlvHandles.FullRowSelect = true;
            this.dlvHandles.HideSelection = false;
            this.dlvHandles.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this.dlvHandles.HighlightForegroundColor = System.Drawing.Color.Empty;
            this.dlvHandles.Location = new System.Drawing.Point(0, 0);
            this.dlvHandles.Name = "defaultListView1";
            this.dlvHandles.ShowGroups = false;
            this.dlvHandles.ShowImagesOnSubItems = true;
            this.dlvHandles.Size = new System.Drawing.Size(762, 483);
            this.dlvHandles.TabIndex = 0;
            this.dlvHandles.UseCompatibleStateImageBehavior = false;
            this.dlvHandles.View = System.Windows.Forms.View.Details;
            this.dlvHandles.VirtualMode = true;
            // 
            // ModulesModule
            // 
            this.Controls.Add(this.dlvHandles);
            this.Name = "ModulesModule";
            this.Size = new System.Drawing.Size(762, 483);
            ((System.ComponentModel.ISupportInitialize)(this.dlvHandles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
#pragma warning restore CS0618 // Le type ou le membre est obsolète

        private WinFwk.UITools.DefaultListView dlvHandles;
    }
}
