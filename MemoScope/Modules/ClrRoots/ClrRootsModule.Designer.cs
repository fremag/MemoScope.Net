namespace MemoScope.Modules.ClrRoots
{
    partial class ClrRootsModule
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
            this.components = new System.ComponentModel.Container();
            this.dlvClrRoots = new WinFwk.UITools.DefaultListView();
            this.rfcName = new MemoScope.Tools.RegexFilter.RegexFilterControl();
            ((System.ComponentModel.ISupportInitialize)(this.dlvClrRoots)).BeginInit();
            this.SuspendLayout();
            // 
            // dlvClrRoots
            // 
            this.dlvClrRoots.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dlvClrRoots.CellEditUseWholeCell = false;
            this.dlvClrRoots.FullRowSelect = true;
            this.dlvClrRoots.HideSelection = false;
            this.dlvClrRoots.Location = new System.Drawing.Point(0, 46);
            this.dlvClrRoots.Name = "dlvClrRoots";
            this.dlvClrRoots.ShowGroups = false;
            this.dlvClrRoots.ShowImagesOnSubItems = true;
            this.dlvClrRoots.Size = new System.Drawing.Size(762, 437);
            this.dlvClrRoots.TabIndex = 0;
            this.dlvClrRoots.UseCompatibleStateImageBehavior = false;
            this.dlvClrRoots.View = System.Windows.Forms.View.Details;
            this.dlvClrRoots.VirtualMode = true;
            // 
            // rfcName
            // 
            this.rfcName.Location = new System.Drawing.Point(3, 8);
            this.rfcName.Name = "rfcName";
            this.rfcName.Size = new System.Drawing.Size(675, 32);
            this.rfcName.TabIndex = 1;
            // 
            // ClrRootsModule
            // 
            this.Controls.Add(this.rfcName);
            this.Controls.Add(this.dlvClrRoots);
            this.Name = "ClrRootsModule";
            this.Size = new System.Drawing.Size(762, 483);
            ((System.ComponentModel.ISupportInitialize)(this.dlvClrRoots)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
#pragma warning restore CS0618 // Le type ou le membre est obsolète

        private WinFwk.UITools.DefaultListView dlvClrRoots;
        private Tools.RegexFilter.RegexFilterControl rfcName;
    }
}
