namespace MemoScope.Modules.Threads
{
    partial class ThreadsModule
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
        private void InitializeComponent()
        {
            this.dlvThreads = new WinFwk.UITools.DefaultListView();
            ((System.ComponentModel.ISupportInitialize)(this.dlvThreads)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultListView1
            // 
            this.dlvThreads.CellEditUseWholeCell = false;
            this.dlvThreads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlvThreads.FullRowSelect = true;
            this.dlvThreads.HideSelection = false;
            this.dlvThreads.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this.dlvThreads.HighlightForegroundColor = System.Drawing.Color.Empty;
            this.dlvThreads.Location = new System.Drawing.Point(0, 0);
            this.dlvThreads.Name = "defaultListView1";
            this.dlvThreads.ShowGroups = false;
            this.dlvThreads.ShowImagesOnSubItems = true;
            this.dlvThreads.Size = new System.Drawing.Size(762, 483);
            this.dlvThreads.TabIndex = 0;
            this.dlvThreads.UseCompatibleStateImageBehavior = false;
            this.dlvThreads.View = System.Windows.Forms.View.Details;
            this.dlvThreads.VirtualMode = true;
            // 
            // ModulesModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dlvThreads);
            this.Name = "ModulesModule";
            this.Size = new System.Drawing.Size(762, 483);
            ((System.ComponentModel.ISupportInitialize)(this.dlvThreads)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private WinFwk.UITools.DefaultListView dlvThreads;
    }
}
