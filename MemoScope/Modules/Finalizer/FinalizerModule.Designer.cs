namespace MemoScope.Modules.Finalizer
{
    partial class FinalizerModule
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
            this.dlvFinalizer = new WinFwk.UITools.DefaultListView();
            ((System.ComponentModel.ISupportInitialize)(this.dlvFinalizer)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultListView1
            // 
            this.dlvFinalizer.CellEditUseWholeCell = false;
            this.dlvFinalizer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlvFinalizer.FullRowSelect = true;
            this.dlvFinalizer.HideSelection = false;
            this.dlvFinalizer.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this.dlvFinalizer.HighlightForegroundColor = System.Drawing.Color.Empty;
            this.dlvFinalizer.Location = new System.Drawing.Point(0, 0);
            this.dlvFinalizer.Name = "defaultListView1";
            this.dlvFinalizer.ShowGroups = false;
            this.dlvFinalizer.ShowImagesOnSubItems = true;
            this.dlvFinalizer.Size = new System.Drawing.Size(762, 483);
            this.dlvFinalizer.TabIndex = 0;
            this.dlvFinalizer.UseCompatibleStateImageBehavior = false;
            this.dlvFinalizer.View = System.Windows.Forms.View.Details;
            this.dlvFinalizer.VirtualMode = true;
            // 
            // ModulesModule
            // 
            this.Controls.Add(this.dlvFinalizer);
            this.Name = "ModulesModule";
            this.Size = new System.Drawing.Size(762, 483);
            ((System.ComponentModel.ISupportInitialize)(this.dlvFinalizer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
#pragma warning restore CS0618 // Le type ou le membre est obsolète

        private WinFwk.UITools.DefaultListView dlvFinalizer;
    }
}
