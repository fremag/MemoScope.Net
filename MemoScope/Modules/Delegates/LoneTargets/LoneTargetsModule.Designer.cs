namespace MemoScope.Modules.Delegates.LoneHandlers
{
    partial class LoneTargetsModule
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
            this.dlvLoneHandlers = new WinFwk.UITools.DefaultListView();
            ((System.ComponentModel.ISupportInitialize)(this.dlvLoneHandlers)).BeginInit();
            this.SuspendLayout();
            // 
            // dlvDelegateInstances
            // 
            this.dlvLoneHandlers.CellEditUseWholeCell = false;
            this.dlvLoneHandlers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlvLoneHandlers.FullRowSelect = true;
            this.dlvLoneHandlers.HideSelection = false;
            this.dlvLoneHandlers.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this.dlvLoneHandlers.HighlightForegroundColor = System.Drawing.Color.Empty;
            this.dlvLoneHandlers.Location = new System.Drawing.Point(0, 0);
            this.dlvLoneHandlers.Name = "dlvDelegateInstances";
            this.dlvLoneHandlers.ShowGroups = false;
            this.dlvLoneHandlers.ShowImagesOnSubItems = true;
            this.dlvLoneHandlers.Size = new System.Drawing.Size(762, 483);
            this.dlvLoneHandlers.TabIndex = 0;
            this.dlvLoneHandlers.UseCompatibleStateImageBehavior = false;
            this.dlvLoneHandlers.View = System.Windows.Forms.View.Details;
            this.dlvLoneHandlers.VirtualMode = true;
            // 
            // DelegateInstancesModule
            // 
            this.Controls.Add(this.dlvLoneHandlers);
            this.Name = "DelegateInstancesModule";
            this.Size = new System.Drawing.Size(762, 483);
            ((System.ComponentModel.ISupportInitialize)(this.dlvLoneHandlers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
#pragma warning restore CS0618 // Le type ou le membre est obsolète

        private WinFwk.UITools.DefaultListView dlvLoneHandlers;
    }
}
