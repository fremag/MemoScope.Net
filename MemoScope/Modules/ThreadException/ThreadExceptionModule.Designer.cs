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
#pragma warning disable CS0618 // Le type ou le membre est obsolète

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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dlvExceptions = new WinFwk.UITools.DefaultListView();
            ((System.ComponentModel.ISupportInitialize)(this.dlvStackTrace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dlvExceptions)).BeginInit();
            this.SuspendLayout();
            // 
            // lblExceptionType
            // 
            this.lblExceptionType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblExceptionType.AutoSize = true;
            this.lblExceptionType.Location = new System.Drawing.Point(3, 210);
            this.lblExceptionType.Name = "lblExceptionType";
            this.lblExceptionType.Size = new System.Drawing.Size(48, 17);
            this.lblExceptionType.TabIndex = 0;
            this.lblExceptionType.Text = "Type :";
            // 
            // tbExceptionType
            // 
            this.tbExceptionType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbExceptionType.Location = new System.Drawing.Point(88, 211);
            this.tbExceptionType.Name = "tbExceptionType";
            this.tbExceptionType.ReadOnly = true;
            this.tbExceptionType.Size = new System.Drawing.Size(551, 22);
            this.tbExceptionType.TabIndex = 1;
            // 
            // tbMessage
            // 
            this.tbMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMessage.Location = new System.Drawing.Point(88, 242);
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.ReadOnly = true;
            this.tbMessage.Size = new System.Drawing.Size(551, 22);
            this.tbMessage.TabIndex = 3;
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(3, 242);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(73, 17);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.Text = "Message :";
            // 
            // dlvStackTrace
            // 
            this.dlvStackTrace.CellEditUseWholeCell = false;
            this.dlvStackTrace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlvStackTrace.FullRowSelect = true;
            this.dlvStackTrace.HideSelection = false;
            this.dlvStackTrace.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this.dlvStackTrace.HighlightForegroundColor = System.Drawing.Color.Empty;
            this.dlvStackTrace.Location = new System.Drawing.Point(0, 0);
            this.dlvStackTrace.Name = "dlvStackTrace";
            this.dlvStackTrace.ShowGroups = false;
            this.dlvStackTrace.ShowImagesOnSubItems = true;
            this.dlvStackTrace.Size = new System.Drawing.Size(651, 263);
            this.dlvStackTrace.TabIndex = 4;
            this.dlvStackTrace.UseCompatibleStateImageBehavior = false;
            this.dlvStackTrace.View = System.Windows.Forms.View.Details;
            this.dlvStackTrace.VirtualMode = true;
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
            this.splitContainer1.Panel1.Controls.Add(this.dlvExceptions);
            this.splitContainer1.Panel1.Controls.Add(this.tbExceptionType);
            this.splitContainer1.Panel1.Controls.Add(this.tbMessage);
            this.splitContainer1.Panel1.Controls.Add(this.lblExceptionType);
            this.splitContainer1.Panel1.Controls.Add(this.lblMessage);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dlvStackTrace);
            this.splitContainer1.Size = new System.Drawing.Size(651, 534);
            this.splitContainer1.SplitterDistance = 267;
            this.splitContainer1.TabIndex = 5;
            // 
            // dlvExceptions
            // 
            this.dlvExceptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dlvExceptions.CellEditUseWholeCell = false;
            this.dlvExceptions.FullRowSelect = true;
            this.dlvExceptions.HideSelection = false;
            this.dlvExceptions.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this.dlvExceptions.HighlightForegroundColor = System.Drawing.Color.Empty;
            this.dlvExceptions.Location = new System.Drawing.Point(6, 3);
            this.dlvExceptions.Name = "dlvExceptions";
            this.dlvExceptions.ShowGroups = false;
            this.dlvExceptions.ShowImagesOnSubItems = true;
            this.dlvExceptions.Size = new System.Drawing.Size(642, 202);
            this.dlvExceptions.TabIndex = 4;
            this.dlvExceptions.UseCompatibleStateImageBehavior = false;
            this.dlvExceptions.View = System.Windows.Forms.View.Details;
            this.dlvExceptions.VirtualMode = true;
            this.dlvExceptions.SelectedIndexChanged += new System.EventHandler(this.dlvExceptions_SelectedIndexChanged);
            // 
            // ThreadExceptionModule
            // 
            this.Controls.Add(this.splitContainer1);
            this.Name = "ThreadExceptionModule";
            this.Size = new System.Drawing.Size(651, 534);
            ((System.ComponentModel.ISupportInitialize)(this.dlvStackTrace)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dlvExceptions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
#pragma warning restore CS0618 // Le type ou le membre est obsolète

        private System.Windows.Forms.Label lblExceptionType;
        private System.Windows.Forms.TextBox tbExceptionType;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.Label lblMessage;
        private WinFwk.UITools.DefaultListView dlvStackTrace;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private WinFwk.UITools.DefaultListView dlvExceptions;
    }
}
