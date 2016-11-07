namespace MemoScope.Modules.Segments
{
    partial class SegmentsModule
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
            this.dlvSegments = new WinFwk.UITools.DefaultListView();
            ((System.ComponentModel.ISupportInitialize)(this.dlvSegments)).BeginInit();
            this.SuspendLayout();
            // 
            // dlvSegments
            // 
            this.dlvSegments.CellEditUseWholeCell = false;
            this.dlvSegments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlvSegments.FullRowSelect = true;
            this.dlvSegments.HideSelection = false;
            this.dlvSegments.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this.dlvSegments.HighlightForegroundColor = System.Drawing.Color.Empty;
            this.dlvSegments.Location = new System.Drawing.Point(0, 0);
            this.dlvSegments.Name = "dlvSegments";
            this.dlvSegments.ShowGroups = false;
            this.dlvSegments.ShowImagesOnSubItems = true;
            this.dlvSegments.Size = new System.Drawing.Size(762, 483);
            this.dlvSegments.TabIndex = 0;
            this.dlvSegments.UseCompatibleStateImageBehavior = false;
            this.dlvSegments.View = System.Windows.Forms.View.Details;
            this.dlvSegments.VirtualMode = true;
            this.dlvSegments.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.dlvSegments_CellClick);
            // 
            // SegmentsModule
            // 
            this.Controls.Add(this.dlvSegments);
            this.Name = "SegmentsModule";
            this.Size = new System.Drawing.Size(762, 483);
            ((System.ComponentModel.ISupportInitialize)(this.dlvSegments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
#pragma warning restore CS0618 // Le type ou le membre est obsolète

        private WinFwk.UITools.DefaultListView dlvSegments;
    }
}
