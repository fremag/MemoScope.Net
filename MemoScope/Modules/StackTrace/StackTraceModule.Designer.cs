namespace MemoScope.Modules.StackTrace
{
    partial class StackTraceModule
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
            this.dlvStackFrames = new WinFwk.UITools.DefaultListView();
            ((System.ComponentModel.ISupportInitialize)(this.dlvStackFrames)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultListView1
            // 
            this.dlvStackFrames.CellEditUseWholeCell = false;
            this.dlvStackFrames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlvStackFrames.FullRowSelect = true;
            this.dlvStackFrames.HideSelection = false;
            this.dlvStackFrames.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this.dlvStackFrames.HighlightForegroundColor = System.Drawing.Color.Empty;
            this.dlvStackFrames.Location = new System.Drawing.Point(0, 0);
            this.dlvStackFrames.Name = "defaultListView1";
            this.dlvStackFrames.ShowGroups = false;
            this.dlvStackFrames.ShowImagesOnSubItems = true;
            this.dlvStackFrames.Size = new System.Drawing.Size(762, 483);
            this.dlvStackFrames.TabIndex = 0;
            this.dlvStackFrames.UseCompatibleStateImageBehavior = false;
            this.dlvStackFrames.View = System.Windows.Forms.View.Details;
            this.dlvStackFrames.VirtualMode = true;
            // 
            // ModulesModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dlvStackFrames);
            this.Name = "ModulesModule";
            this.Size = new System.Drawing.Size(762, 483);
            ((System.ComponentModel.ISupportInitialize)(this.dlvStackFrames)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private WinFwk.UITools.DefaultListView dlvStackFrames;
    }
}
