namespace MemoScope.Modules.BlockingObjects
{
    partial class BlockingObjectsModule
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
            this.dlvBlockingObjects = new WinFwk.UITools.DefaultListView();
            ((System.ComponentModel.ISupportInitialize)(this.dlvBlockingObjects)).BeginInit();
            this.SuspendLayout();
            // 
            // dlvBlockingObjects
            // 
            this.dlvBlockingObjects.CellEditUseWholeCell = false;
            this.dlvBlockingObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlvBlockingObjects.FullRowSelect = true;
            this.dlvBlockingObjects.HideSelection = false;
            this.dlvBlockingObjects.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this.dlvBlockingObjects.HighlightForegroundColor = System.Drawing.Color.Empty;
            this.dlvBlockingObjects.Location = new System.Drawing.Point(0, 0);
            this.dlvBlockingObjects.Name = "dlvBlockingObjects";
            this.dlvBlockingObjects.ShowGroups = false;
            this.dlvBlockingObjects.ShowImagesOnSubItems = true;
            this.dlvBlockingObjects.Size = new System.Drawing.Size(762, 483);
            this.dlvBlockingObjects.TabIndex = 0;
            this.dlvBlockingObjects.UseCompatibleStateImageBehavior = false;
            this.dlvBlockingObjects.View = System.Windows.Forms.View.Details;
            this.dlvBlockingObjects.VirtualMode = true;
            // 
            // BlockingObjectsModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dlvBlockingObjects);
            this.Name = "BlockingObjectsModule";
            this.Size = new System.Drawing.Size(762, 483);
            ((System.ComponentModel.ISupportInitialize)(this.dlvBlockingObjects)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
#pragma warning restore CS0618 // Le type ou le membre est obsolète

        private WinFwk.UITools.DefaultListView dlvBlockingObjects;
    }
}
