namespace WinFwk.UITools.Log
{
    partial class LogMessageViewerModule
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
            this.lblTimeStamp = new System.Windows.Forms.Label();
            this.tbTimeStamp = new System.Windows.Forms.TextBox();
            this.tbText = new System.Windows.Forms.TextBox();
            this.lblText = new System.Windows.Forms.Label();
            this.tbLevel = new System.Windows.Forms.TextBox();
            this.lblLevel = new System.Windows.Forms.Label();
            this.tbStackTrace = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbType = new System.Windows.Forms.TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.gbLogMessage = new System.Windows.Forms.GroupBox();
            this.gbException = new System.Windows.Forms.GroupBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbLogMessage.SuspendLayout();
            this.gbException.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTimeStamp
            // 
            this.lblTimeStamp.AutoSize = true;
            this.lblTimeStamp.Location = new System.Drawing.Point(19, 25);
            this.lblTimeStamp.Name = "lblTimeStamp";
            this.lblTimeStamp.Size = new System.Drawing.Size(91, 17);
            this.lblTimeStamp.TabIndex = 0;
            this.lblTimeStamp.Text = "Time Stamp :";
            // 
            // tbTimeStamp
            // 
            this.tbTimeStamp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTimeStamp.Location = new System.Drawing.Point(116, 22);
            this.tbTimeStamp.Name = "tbTimeStamp";
            this.tbTimeStamp.Size = new System.Drawing.Size(594, 22);
            this.tbTimeStamp.TabIndex = 1;
            // 
            // tbText
            // 
            this.tbText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbText.Location = new System.Drawing.Point(116, 78);
            this.tbText.Multiline = true;
            this.tbText.Name = "tbText";
            this.tbText.Size = new System.Drawing.Size(594, 244);
            this.tbText.TabIndex = 3;
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(19, 81);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(43, 17);
            this.lblText.TabIndex = 2;
            this.lblText.Text = "Text :";
            // 
            // tbLevel
            // 
            this.tbLevel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLevel.Location = new System.Drawing.Point(116, 50);
            this.tbLevel.Name = "tbLevel";
            this.tbLevel.Size = new System.Drawing.Size(594, 22);
            this.tbLevel.TabIndex = 5;
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(19, 53);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(50, 17);
            this.lblLevel.TabIndex = 4;
            this.lblLevel.Text = "Level :";
            // 
            // tbStackTrace
            // 
            this.tbStackTrace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbStackTrace.Location = new System.Drawing.Point(116, 86);
            this.tbStackTrace.Multiline = true;
            this.tbStackTrace.Name = "tbStackTrace";
            this.tbStackTrace.Size = new System.Drawing.Size(594, 291);
            this.tbStackTrace.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Stack Trace :";
            // 
            // tbType
            // 
            this.tbType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbType.Location = new System.Drawing.Point(116, 30);
            this.tbType.Name = "tbType";
            this.tbType.Size = new System.Drawing.Size(594, 22);
            this.tbType.TabIndex = 9;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(19, 33);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(48, 17);
            this.lblType.TabIndex = 8;
            this.lblType.Text = "Type :";
            // 
            // gbLogMessage
            // 
            this.gbLogMessage.Controls.Add(this.tbText);
            this.gbLogMessage.Controls.Add(this.lblTimeStamp);
            this.gbLogMessage.Controls.Add(this.tbTimeStamp);
            this.gbLogMessage.Controls.Add(this.lblText);
            this.gbLogMessage.Controls.Add(this.lblLevel);
            this.gbLogMessage.Controls.Add(this.tbLevel);
            this.gbLogMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbLogMessage.Location = new System.Drawing.Point(0, 0);
            this.gbLogMessage.Name = "gbLogMessage";
            this.gbLogMessage.Size = new System.Drawing.Size(716, 328);
            this.gbLogMessage.TabIndex = 10;
            this.gbLogMessage.TabStop = false;
            this.gbLogMessage.Text = "Log Message";
            // 
            // gbException
            // 
            this.gbException.Controls.Add(this.lblMessage);
            this.gbException.Controls.Add(this.tbMessage);
            this.gbException.Controls.Add(this.lblType);
            this.gbException.Controls.Add(this.tbType);
            this.gbException.Controls.Add(this.label4);
            this.gbException.Controls.Add(this.tbStackTrace);
            this.gbException.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbException.Location = new System.Drawing.Point(0, 0);
            this.gbException.Name = "gbException";
            this.gbException.Size = new System.Drawing.Size(716, 383);
            this.gbException.TabIndex = 11;
            this.gbException.TabStop = false;
            this.gbException.Text = "Exception";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(19, 61);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(73, 17);
            this.lblMessage.TabIndex = 10;
            this.lblMessage.Text = "Message :";
            // 
            // tbMessage
            // 
            this.tbMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMessage.Location = new System.Drawing.Point(116, 58);
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(594, 22);
            this.tbMessage.TabIndex = 11;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbLogMessage);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gbException);
            this.splitContainer1.Size = new System.Drawing.Size(716, 715);
            this.splitContainer1.SplitterDistance = 328;
            this.splitContainer1.TabIndex = 12;
            // 
            // LogMessageViewerModule
            // 
            this.Controls.Add(this.splitContainer1);
            this.Name = "LogMessageViewerModule";
            this.Size = new System.Drawing.Size(716, 715);
            this.gbLogMessage.ResumeLayout(false);
            this.gbLogMessage.PerformLayout();
            this.gbException.ResumeLayout(false);
            this.gbException.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTimeStamp;
        private System.Windows.Forms.TextBox tbTimeStamp;
        private System.Windows.Forms.TextBox tbText;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.TextBox tbLevel;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.TextBox tbStackTrace;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.GroupBox gbLogMessage;
        private System.Windows.Forms.GroupBox gbException;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox tbMessage;
    }
}
