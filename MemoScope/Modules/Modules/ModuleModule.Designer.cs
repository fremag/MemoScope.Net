namespace MemoScope.Modules.Modules
{
    partial class ModulesModule
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
            this.dlvModules = new WinFwk.UITools.DefaultListView();
            ((System.ComponentModel.ISupportInitialize)(this.dlvModules)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultListView1
            // 
            this.dlvModules.CellEditUseWholeCell = false;
            this.dlvModules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlvModules.FullRowSelect = true;
            this.dlvModules.HideSelection = false;
            this.dlvModules.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this.dlvModules.HighlightForegroundColor = System.Drawing.Color.Empty;
            this.dlvModules.Location = new System.Drawing.Point(0, 0);
            this.dlvModules.Name = "defaultListView1";
            this.dlvModules.ShowGroups = false;
            this.dlvModules.ShowImagesOnSubItems = true;
            this.dlvModules.Size = new System.Drawing.Size(762, 483);
            this.dlvModules.TabIndex = 0;
            this.dlvModules.UseCompatibleStateImageBehavior = false;
            this.dlvModules.View = System.Windows.Forms.View.Details;
            this.dlvModules.VirtualMode = true;
            // 
            // ModulesModule
            // 
            this.Controls.Add(this.dlvModules);
            this.Name = "ModulesModule";
            this.Size = new System.Drawing.Size(762, 483);
            ((System.ComponentModel.ISupportInitialize)(this.dlvModules)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
#pragma warning restore CS0618 // Le type ou le membre est obsolète

        private WinFwk.UITools.DefaultListView dlvModules;
    }
}
