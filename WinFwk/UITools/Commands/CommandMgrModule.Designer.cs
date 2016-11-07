namespace WinFwk.UITools.Commands
{
    partial class CommandMgrModule
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
            this.dlvCommands = new WinFwk.UITools.DefaultListView();
            ((System.ComponentModel.ISupportInitialize)(this.dlvCommands)).BeginInit();
            this.SuspendLayout();
            // 
            // dlvCommands
            // 
            this.dlvCommands.CellEditUseWholeCell = false;
            this.dlvCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlvCommands.FullRowSelect = true;
            this.dlvCommands.HideSelection = false;
            this.dlvCommands.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this.dlvCommands.HighlightForegroundColor = System.Drawing.Color.Empty;
            this.dlvCommands.Location = new System.Drawing.Point(0, 0);
            this.dlvCommands.Name = "dlvCommands";
            this.dlvCommands.ShowGroups = false;
            this.dlvCommands.ShowImagesOnSubItems = true;
            this.dlvCommands.Size = new System.Drawing.Size(568, 394);
            this.dlvCommands.TabIndex = 0;
            this.dlvCommands.UseCompatibleStateImageBehavior = false;
            this.dlvCommands.View = System.Windows.Forms.View.Details;
            this.dlvCommands.VirtualMode = true;
            // 
            // CommandMgr
            // 
            this.Controls.Add(this.dlvCommands);
            this.Name = "CommandMgr";
            this.Size = new System.Drawing.Size(568, 394);
            ((System.ComponentModel.ISupportInitialize)(this.dlvCommands)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
#pragma warning restore CS0618 // Le type ou le membre est obsolète

        private DefaultListView dlvCommands;
    }
}
