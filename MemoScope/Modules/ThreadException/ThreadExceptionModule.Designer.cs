namespace MemoScope.Modules.ThreadException
{
    partial class ThreadExceptionModule
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
            this.lblExceptionType = new System.Windows.Forms.Label();
            this.tbExceptionType = new System.Windows.Forms.TextBox();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.dlvStackTrace = new WinFwk.UITools.DefaultListView();
            ((System.ComponentModel.ISupportInitialize)(this.dlvStackTrace)).BeginInit();
            this.SuspendLayout();
            // 
            // lblExceptionType
            // 
            this.lblExceptionType.AutoSize = true;
            this.lblExceptionType.Location = new System.Drawing.Point(8, 11);
            this.lblExceptionType.Name = "lblExceptionType";
            this.lblExceptionType.Size = new System.Drawing.Size(48, 17);
            this.lblExceptionType.TabIndex = 0;
            this.lblExceptionType.Text = "Type :";
            // 
            // tbExceptionType
            // 
            this.tbExceptionType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbExceptionType.Location = new System.Drawing.Point(93, 12);
            this.tbExceptionType.Name = "tbExceptionType";
            this.tbExceptionType.ReadOnly = true;
            this.tbExceptionType.Size = new System.Drawing.Size(666, 22);
            this.tbExceptionType.TabIndex = 1;
            // 
            // tbMessage
            // 
            this.tbMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMessage.Location = new System.Drawing.Point(93, 43);
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.ReadOnly = true;
            this.tbMessage.Size = new System.Drawing.Size(666, 22);
            this.tbMessage.TabIndex = 3;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(8, 43);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(73, 17);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.Text = "Message :";
            // 
            // dlvStackTrace
            // 
            this.dlvStackTrace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dlvStackTrace.CellEditUseWholeCell = false;
            this.dlvStackTrace.FullRowSelect = true;
            this.dlvStackTrace.HideSelection = false;
            this.dlvStackTrace.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this.dlvStackTrace.HighlightForegroundColor = System.Drawing.Color.Empty;
            this.dlvStackTrace.Location = new System.Drawing.Point(3, 71);
            this.dlvStackTrace.Name = "dlvStackTrace";
            this.dlvStackTrace.ShowGroups = false;
            this.dlvStackTrace.ShowImagesOnSubItems = true;
            this.dlvStackTrace.Size = new System.Drawing.Size(756, 409);
            this.dlvStackTrace.TabIndex = 4;
            this.dlvStackTrace.UseCompatibleStateImageBehavior = false;
            this.dlvStackTrace.View = System.Windows.Forms.View.Details;
            this.dlvStackTrace.VirtualMode = true;
            // 
            // ThreadExceptionModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dlvStackTrace);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.tbExceptionType);
            this.Controls.Add(this.lblExceptionType);
            this.Name = "ThreadExceptionModule";
            this.Size = new System.Drawing.Size(762, 483);
            ((System.ComponentModel.ISupportInitialize)(this.dlvStackTrace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblExceptionType;
        private System.Windows.Forms.TextBox tbExceptionType;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.Label lblMessage;
        private WinFwk.UITools.DefaultListView dlvStackTrace;
    }
}
