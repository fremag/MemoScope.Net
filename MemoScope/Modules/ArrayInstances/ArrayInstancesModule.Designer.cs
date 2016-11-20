namespace MemoScope.Modules.ArrayInstances
{
    partial class ArrayInstancesModule
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
#pragma warning disable CS0618 // Le type ou le membre est obsolète
        private void InitializeComponent()
        {
            this.dlvArrays = new WinFwk.UITools.DefaultListView();
            ((System.ComponentModel.ISupportInitialize)(this.dlvArrays)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultListView1
            // 
            this.dlvArrays.CellEditUseWholeCell = false;
            this.dlvArrays.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlvArrays.FullRowSelect = true;
            this.dlvArrays.HideSelection = false;
            this.dlvArrays.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this.dlvArrays.HighlightForegroundColor = System.Drawing.Color.Empty;
            this.dlvArrays.Location = new System.Drawing.Point(0, 0);
            this.dlvArrays.Name = "defaultListView1";
            this.dlvArrays.ShowGroups = false;
            this.dlvArrays.ShowImagesOnSubItems = true;
            this.dlvArrays.Size = new System.Drawing.Size(762, 483);
            this.dlvArrays.TabIndex = 0;
            this.dlvArrays.UseCompatibleStateImageBehavior = false;
            this.dlvArrays.View = System.Windows.Forms.View.Details;
            this.dlvArrays.VirtualMode = true;
            // 
            // ModulesModule
            // 
            this.Controls.Add(this.dlvArrays);
            this.Name = "ModulesModule";
            this.Size = new System.Drawing.Size(762, 483);
            ((System.ComponentModel.ISupportInitialize)(this.dlvArrays)).EndInit();
            this.ResumeLayout(false);

        }
#pragma warning restore CS0618 // Le type ou le membre est obsolète

        #endregion

        private WinFwk.UITools.DefaultListView dlvArrays;
    }
}
