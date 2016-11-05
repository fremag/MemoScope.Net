namespace MemoScope.Modules.Delegates.Types
{
    partial class DelegateTypesModule
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
            this.dlvDelegateTypes = new WinFwk.UITools.DefaultListView();
            this.regexFilterControl = new MemoScope.Tools.RegexFilter.RegexFilterControl();
            ((System.ComponentModel.ISupportInitialize)(this.dlvDelegateTypes)).BeginInit();
            this.SuspendLayout();
            // 
            // dlvDelegateTypes
            // 
            this.dlvDelegateTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dlvDelegateTypes.CellEditUseWholeCell = false;
            this.dlvDelegateTypes.FullRowSelect = true;
            this.dlvDelegateTypes.HideSelection = false;
            this.dlvDelegateTypes.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this.dlvDelegateTypes.HighlightForegroundColor = System.Drawing.Color.Empty;
            this.dlvDelegateTypes.Location = new System.Drawing.Point(0, 44);
            this.dlvDelegateTypes.Name = "dlvDelegateTypes";
            this.dlvDelegateTypes.ShowGroups = false;
            this.dlvDelegateTypes.ShowImagesOnSubItems = true;
            this.dlvDelegateTypes.Size = new System.Drawing.Size(762, 439);
            this.dlvDelegateTypes.TabIndex = 0;
            this.dlvDelegateTypes.UseCompatibleStateImageBehavior = false;
            this.dlvDelegateTypes.View = System.Windows.Forms.View.Details;
            this.dlvDelegateTypes.VirtualMode = true;
            this.dlvDelegateTypes.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.dlvDelegates_CellClick);
            // 
            // regexFilterControl
            // 
            this.regexFilterControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.regexFilterControl.Location = new System.Drawing.Point(0, 3);
            this.regexFilterControl.Name = "regexFilterControl";
            this.regexFilterControl.Size = new System.Drawing.Size(759, 35);
            this.regexFilterControl.TabIndex = 1;
            // 
            // DelegateTypesModule
            // 
            this.Controls.Add(this.regexFilterControl);
            this.Controls.Add(this.dlvDelegateTypes);
            this.Name = "DelegateTypesModule";
            this.Size = new System.Drawing.Size(762, 483);
            ((System.ComponentModel.ISupportInitialize)(this.dlvDelegateTypes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
#pragma warning restore CS0618 // Le type ou le membre est obsolète

        private WinFwk.UITools.DefaultListView dlvDelegateTypes;
        private Tools.RegexFilter.RegexFilterControl regexFilterControl;
    }
}
