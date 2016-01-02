namespace MemoScope.Modules.Instances
{
    partial class InstanceFilter
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
            this.tbFilterCode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbFilterCode
            // 
            this.tbFilterCode.AllowDrop = true;
            this.tbFilterCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFilterCode.Location = new System.Drawing.Point(248, 115);
            this.tbFilterCode.Multiline = true;
            this.tbFilterCode.Name = "tbFilterCode";
            this.tbFilterCode.Size = new System.Drawing.Size(411, 168);
            this.tbFilterCode.TabIndex = 0;
            this.tbFilterCode.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbFilterCode_DragDrop);
            this.tbFilterCode.DragEnter += new System.Windows.Forms.DragEventHandler(this.tbFilterCode_DragEnter);
            // 
            // InstanceFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbFilterCode);
            this.Name = "InstanceFilter";
            this.Size = new System.Drawing.Size(706, 351);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbFilterCode;
    }
}
