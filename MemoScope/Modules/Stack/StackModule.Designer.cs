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
#pragma warning disable CS0618 // Le type ou le membre est obsolète

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.dlvStack = new WinFwk.UITools.DefaultListView();
            this.regexFilterControl = new MemoScope.Tools.RegexFilter.RegexFilterControl();
            ((System.ComponentModel.ISupportInitialize)(this.dlvStack)).BeginInit();
            this.SuspendLayout();
            // 
            // dlvStack
            // 
            this.dlvStack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dlvStack.CellEditUseWholeCell = false;
            this.dlvStack.FullRowSelect = true;
            this.dlvStack.HideSelection = false;
            this.dlvStack.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this.dlvStack.HighlightForegroundColor = System.Drawing.Color.Empty;
            this.dlvStack.Location = new System.Drawing.Point(0, 33);
            this.dlvStack.Name = "dlvStack";
            this.dlvStack.ShowGroups = false;
            this.dlvStack.ShowImagesOnSubItems = true;
            this.dlvStack.Size = new System.Drawing.Size(762, 450);
            this.dlvStack.TabIndex = 0;
            this.dlvStack.UseCompatibleStateImageBehavior = false;
            this.dlvStack.View = System.Windows.Forms.View.Details;
            this.dlvStack.VirtualMode = true;
            // 
            // regexFilterControl
            // 
            this.regexFilterControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.regexFilterControl.Location = new System.Drawing.Point(3, 3);
            this.regexFilterControl.Name = "regexFilterControl";
            this.regexFilterControl.Size = new System.Drawing.Size(756, 24);
            this.regexFilterControl.TabIndex = 1;
            // 
            // StackModule
            // 
            this.Controls.Add(this.regexFilterControl);
            this.Controls.Add(this.dlvStack);
            this.Name = "StackModule";
            this.Size = new System.Drawing.Size(762, 483);
            ((System.ComponentModel.ISupportInitialize)(this.dlvStack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
#pragma warning restore CS0618 // Le type ou le membre est obsolète

        private WinFwk.UITools.DefaultListView dlvStack;
        private Tools.RegexFilter.RegexFilterControl regexFilterControl;
    }
}
