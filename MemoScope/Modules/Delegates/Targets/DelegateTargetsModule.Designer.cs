namespace MemoScope.Modules.Delegates.Targets
{
    partial class DelegateTargetsModule
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
            this.dlvDelegateTargets = new WinFwk.UITools.DefaultListView();
            ((System.ComponentModel.ISupportInitialize)(this.dlvDelegateTargets)).BeginInit();
            this.SuspendLayout();
            // 
            // dlvDelegateInstances
            // 
            this.dlvDelegateTargets.CellEditUseWholeCell = false;
            this.dlvDelegateTargets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlvDelegateTargets.FullRowSelect = true;
            this.dlvDelegateTargets.HideSelection = false;
            this.dlvDelegateTargets.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this.dlvDelegateTargets.HighlightForegroundColor = System.Drawing.Color.Empty;
            this.dlvDelegateTargets.Location = new System.Drawing.Point(0, 0);
            this.dlvDelegateTargets.Name = "dlvDelegateInstances";
            this.dlvDelegateTargets.ShowGroups = false;
            this.dlvDelegateTargets.ShowImagesOnSubItems = true;
            this.dlvDelegateTargets.Size = new System.Drawing.Size(762, 483);
            this.dlvDelegateTargets.TabIndex = 0;
            this.dlvDelegateTargets.UseCompatibleStateImageBehavior = false;
            this.dlvDelegateTargets.View = System.Windows.Forms.View.Details;
            this.dlvDelegateTargets.VirtualMode = true;
            // 
            // DelegateInstancesModule
            // 
            this.Controls.Add(this.dlvDelegateTargets);
            this.Name = "DelegateInstancesModule";
            this.Size = new System.Drawing.Size(762, 483);
            ((System.ComponentModel.ISupportInitialize)(this.dlvDelegateTargets)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
#pragma warning restore CS0618 // Le type ou le membre est obsolète

        private WinFwk.UITools.DefaultListView dlvDelegateTargets;
    }
}
