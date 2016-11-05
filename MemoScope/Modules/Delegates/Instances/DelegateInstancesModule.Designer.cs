namespace MemoScope.Modules.Delegates.Instances
{
    partial class DelegateInstancesModule
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
            this.dlvDelegateInstances = new WinFwk.UITools.DefaultListView();
            ((System.ComponentModel.ISupportInitialize)(this.dlvDelegateInstances)).BeginInit();
            this.SuspendLayout();
            // 
            // dlvDelegateInstances
            // 
            this.dlvDelegateInstances.CellEditUseWholeCell = false;
            this.dlvDelegateInstances.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlvDelegateInstances.FullRowSelect = true;
            this.dlvDelegateInstances.HideSelection = false;
            this.dlvDelegateInstances.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this.dlvDelegateInstances.HighlightForegroundColor = System.Drawing.Color.Empty;
            this.dlvDelegateInstances.Location = new System.Drawing.Point(0, 0);
            this.dlvDelegateInstances.Name = "dlvDelegateInstances";
            this.dlvDelegateInstances.ShowGroups = false;
            this.dlvDelegateInstances.ShowImagesOnSubItems = true;
            this.dlvDelegateInstances.Size = new System.Drawing.Size(762, 483);
            this.dlvDelegateInstances.TabIndex = 0;
            this.dlvDelegateInstances.UseCompatibleStateImageBehavior = false;
            this.dlvDelegateInstances.View = System.Windows.Forms.View.Details;
            this.dlvDelegateInstances.VirtualMode = true;
            this.dlvDelegateInstances.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.dlvDelegateInstances_CellClick);
            // 
            // DelegateInstancesModule
            // 
            this.Controls.Add(this.dlvDelegateInstances);
            this.Name = "DelegateInstancesModule";
            this.Size = new System.Drawing.Size(762, 483);
            ((System.ComponentModel.ISupportInitialize)(this.dlvDelegateInstances)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
#pragma warning restore CS0618 // Le type ou le membre est obsolète

        private WinFwk.UITools.DefaultListView dlvDelegateInstances;
    }
}
