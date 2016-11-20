namespace MemoScope.Modules.InstancesMixed
{
    partial class InstancesMixedModule
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
            this.dlvInstances = new WinFwk.UITools.DefaultListView();
            this.regexFilterControl = new MemoScope.Tools.RegexFilter.RegexFilterControl();
            ((System.ComponentModel.ISupportInitialize)(this.dlvInstances)).BeginInit();
            this.SuspendLayout();
            // 
            // dlvStack
            // 
            this.dlvInstances.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dlvInstances.CellEditUseWholeCell = false;
            this.dlvInstances.FullRowSelect = true;
            this.dlvInstances.HideSelection = false;
            this.dlvInstances.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this.dlvInstances.HighlightForegroundColor = System.Drawing.Color.Empty;
            this.dlvInstances.Location = new System.Drawing.Point(0, 33);
            this.dlvInstances.Name = "dlvStack";
            this.dlvInstances.ShowGroups = false;
            this.dlvInstances.ShowImagesOnSubItems = true;
            this.dlvInstances.Size = new System.Drawing.Size(762, 450);
            this.dlvInstances.TabIndex = 0;
            this.dlvInstances.UseCompatibleStateImageBehavior = false;
            this.dlvInstances.View = System.Windows.Forms.View.Details;
            this.dlvInstances.VirtualMode = true;
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
            this.Controls.Add(this.dlvInstances);
            this.Name = "StackModule";
            this.Size = new System.Drawing.Size(762, 483);
            ((System.ComponentModel.ISupportInitialize)(this.dlvInstances)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
#pragma warning restore CS0618 // Le type ou le membre est obsolète

        private WinFwk.UITools.DefaultListView dlvInstances;
        private Tools.RegexFilter.RegexFilterControl regexFilterControl;
    }
}
