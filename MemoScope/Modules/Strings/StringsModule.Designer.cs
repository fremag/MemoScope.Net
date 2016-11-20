namespace MemoScope.Modules.Strings
{
    partial class StringsModule
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
            this.dlvStrings = new WinFwk.UITools.DefaultListView();
            ((System.ComponentModel.ISupportInitialize)(this.dlvStrings)).BeginInit();
            this.SuspendLayout();
            // 
            // dlvStrings
            // 
            this.dlvStrings.CellEditUseWholeCell = false;
            this.dlvStrings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlvStrings.FullRowSelect = true;
            this.dlvStrings.HideSelection = false;
            this.dlvStrings.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this.dlvStrings.HighlightForegroundColor = System.Drawing.Color.Empty;
            this.dlvStrings.Location = new System.Drawing.Point(0, 0);
            this.dlvStrings.Name = "dlvStrings";
            this.dlvStrings.ShowGroups = false;
            this.dlvStrings.ShowImagesOnSubItems = true;
            this.dlvStrings.Size = new System.Drawing.Size(762, 483);
            this.dlvStrings.TabIndex = 0;
            this.dlvStrings.UseCompatibleStateImageBehavior = false;
            this.dlvStrings.View = System.Windows.Forms.View.Details;
            this.dlvStrings.VirtualMode = true;
            this.dlvStrings.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.OnCellClick);
            // 
            // StringsModule
            // 
            this.Controls.Add(this.dlvStrings);
            this.Name = "StringsModule";
            this.Size = new System.Drawing.Size(762, 483);
            ((System.ComponentModel.ISupportInitialize)(this.dlvStrings)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
#pragma warning restore CS0618 // Le type ou le membre est obsolète

        private WinFwk.UITools.DefaultListView dlvStrings;
    }
}
