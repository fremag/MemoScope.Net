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
#pragma warning disable CS0618 // Le type ou le membre est obsolète

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dlvStackFrames = new WinFwk.UITools.DefaultListView();
            this.regexFilterControl1 = new MemoScope.Tools.RegexFilter.RegexFilterControl();
            ((System.ComponentModel.ISupportInitialize)(this.dlvStackFrames)).BeginInit();
            this.SuspendLayout();
            // 
            // dlvStackFrames
            // 
            this.dlvStackFrames.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dlvStackFrames.CellEditUseWholeCell = false;
            this.dlvStackFrames.FullRowSelect = true;
            this.dlvStackFrames.HideSelection = false;
            this.dlvStackFrames.Location = new System.Drawing.Point(0, 34);
            this.dlvStackFrames.Name = "dlvStackFrames";
            this.dlvStackFrames.ShowGroups = false;
            this.dlvStackFrames.ShowImagesOnSubItems = true;
            this.dlvStackFrames.Size = new System.Drawing.Size(943, 153);
            this.dlvStackFrames.TabIndex = 0;
            this.dlvStackFrames.UseCompatibleStateImageBehavior = false;
            this.dlvStackFrames.View = System.Windows.Forms.View.Details;
            this.dlvStackFrames.VirtualMode = true;
            // 
            // regexFilterControl1
            // 
            this.regexFilterControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.regexFilterControl1.Location = new System.Drawing.Point(3, 0);
            this.regexFilterControl1.Name = "regexFilterControl1";
            this.regexFilterControl1.Size = new System.Drawing.Size(937, 32);
            this.regexFilterControl1.TabIndex = 1;
            // 
            // StackTraceModule
            // 
            this.Controls.Add(this.regexFilterControl1);
            this.Controls.Add(this.dlvStackFrames);
            this.Name = "StackTraceModule";
            this.Size = new System.Drawing.Size(943, 187);
            ((System.ComponentModel.ISupportInitialize)(this.dlvStackFrames)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
#pragma warning restore CS0618 // Le type ou le membre est obsolète

        private WinFwk.UITools.DefaultListView dlvStackFrames;
        private Tools.RegexFilter.RegexFilterControl regexFilterControl1;
    }
}
