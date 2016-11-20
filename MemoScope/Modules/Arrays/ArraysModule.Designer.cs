namespace MemoScope.Modules.Arrays
{
    partial class ArraysModule
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
            this.dlvArrays = new WinFwk.UITools.DefaultListView();
            this.regexFilterControl = new MemoScope.Tools.RegexFilter.RegexFilterControl();
            ((System.ComponentModel.ISupportInitialize)(this.dlvArrays)).BeginInit();
            this.SuspendLayout();
            // 
            // dlvArrays
            // 
            this.dlvArrays.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dlvArrays.CellEditUseWholeCell = false;
            this.dlvArrays.FullRowSelect = true;
            this.dlvArrays.HideSelection = false;
            this.dlvArrays.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this.dlvArrays.HighlightForegroundColor = System.Drawing.Color.Empty;
            this.dlvArrays.Location = new System.Drawing.Point(0, 45);
            this.dlvArrays.Name = "dlvArrays";
            this.dlvArrays.ShowGroups = false;
            this.dlvArrays.ShowImagesOnSubItems = true;
            this.dlvArrays.Size = new System.Drawing.Size(762, 438);
            this.dlvArrays.TabIndex = 0;
            this.dlvArrays.UseCompatibleStateImageBehavior = false;
            this.dlvArrays.View = System.Windows.Forms.View.Details;
            this.dlvArrays.VirtualMode = true;
            // 
            // regexFilterControl
            // 
            this.regexFilterControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.regexFilterControl.Location = new System.Drawing.Point(3, 3);
            this.regexFilterControl.Name = "regexFilterControl";
            this.regexFilterControl.Size = new System.Drawing.Size(756, 28);
            this.regexFilterControl.TabIndex = 1;
            // 
            // ArraysModule
            // 
            this.Controls.Add(this.regexFilterControl);
            this.Controls.Add(this.dlvArrays);
            this.Name = "ArraysModule";
            this.Size = new System.Drawing.Size(762, 483);
            ((System.ComponentModel.ISupportInitialize)(this.dlvArrays)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
#pragma warning restore CS0618 // Le type ou le membre est obsolète

        private WinFwk.UITools.DefaultListView dlvArrays;
        private Tools.RegexFilter.RegexFilterControl regexFilterControl;
    }
}
