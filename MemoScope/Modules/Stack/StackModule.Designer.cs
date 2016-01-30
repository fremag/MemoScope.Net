namespace MemoScope.Modules.Stack
{
    partial class StackModule
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
            this.dlvStack = new WinFwk.UITools.DefaultListView();
            ((System.ComponentModel.ISupportInitialize)(this.dlvStack)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultListView1
            // 
            this.dlvStack.CellEditUseWholeCell = false;
            this.dlvStack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlvStack.FullRowSelect = true;
            this.dlvStack.HideSelection = false;
            this.dlvStack.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this.dlvStack.HighlightForegroundColor = System.Drawing.Color.Empty;
            this.dlvStack.Location = new System.Drawing.Point(0, 0);
            this.dlvStack.Name = "defaultListView1";
            this.dlvStack.ShowGroups = false;
            this.dlvStack.ShowImagesOnSubItems = true;
            this.dlvStack.Size = new System.Drawing.Size(762, 483);
            this.dlvStack.TabIndex = 0;
            this.dlvStack.UseCompatibleStateImageBehavior = false;
            this.dlvStack.View = System.Windows.Forms.View.Details;
            this.dlvStack.VirtualMode = true;
            // 
            // ModulesModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dlvStack);
            this.Name = "ModulesModule";
            this.Size = new System.Drawing.Size(762, 483);
            ((System.ComponentModel.ISupportInitialize)(this.dlvStack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private WinFwk.UITools.DefaultListView dlvStack;
    }
}
