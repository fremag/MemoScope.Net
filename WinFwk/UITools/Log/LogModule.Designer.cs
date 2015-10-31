namespace WinFwk.UITools.Log
{
    partial class LogModule
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
            this.components = new System.ComponentModel.Container();
            this.dlvLogMessages = new WinFwk.UITools.DefaultListView();
            this.colTimeStamp = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colLogLevel = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colText = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colException = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnOpenLogFile = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dlvLogMessages)).BeginInit();
            this.SuspendLayout();
            // 
            // dlvLogMessages
            // 
            this.dlvLogMessages.AllColumns.Add(this.colTimeStamp);
            this.dlvLogMessages.AllColumns.Add(this.colLogLevel);
            this.dlvLogMessages.AllColumns.Add(this.colText);
            this.dlvLogMessages.AllColumns.Add(this.colException);
            this.dlvLogMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dlvLogMessages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTimeStamp,
            this.colLogLevel,
            this.colText,
            this.colException});
            this.dlvLogMessages.FullRowSelect = true;
            this.dlvLogMessages.HideSelection = false;
            this.dlvLogMessages.Location = new System.Drawing.Point(0, 50);
            this.dlvLogMessages.Name = "dlvLogMessages";
            this.dlvLogMessages.OwnerDraw = true;
            this.dlvLogMessages.ShowGroups = false;
            this.dlvLogMessages.ShowImagesOnSubItems = true;
            this.dlvLogMessages.Size = new System.Drawing.Size(861, 307);
            this.dlvLogMessages.TabIndex = 0;
            this.dlvLogMessages.UseCellFormatEvents = true;
            this.dlvLogMessages.UseCompatibleStateImageBehavior = false;
            this.dlvLogMessages.View = System.Windows.Forms.View.Details;
            this.dlvLogMessages.VirtualMode = true;
            this.dlvLogMessages.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.fdlvLogMessages_FormatCell);
            // 
            // colTimeStamp
            // 
            this.colTimeStamp.AspectToStringFormat = "{0:HH:mm:ss}";
            this.colTimeStamp.Text = "Time";
            this.colTimeStamp.Width = 150;
            // 
            // colLogLevel
            // 
            this.colLogLevel.AspectToStringFormat = "{0}";
            this.colLogLevel.Text = "Level";
            // 
            // colText
            // 
            this.colText.Text = "Text";
            this.colText.Width = 500;
            // 
            // colException
            // 
            this.colException.Text = "Exception";
            this.colException.Width = 127;
            // 
            // notifyIcon
            // 
            this.notifyIcon.Text = "notifyIcon";
            this.notifyIcon.Visible = true;
            // 
            // btnOpenLogFile
            // 
            this.btnOpenLogFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenLogFile.Image = global::WinFwk.Properties.Resources.open_folder;
            this.btnOpenLogFile.Location = new System.Drawing.Point(818, 4);
            this.btnOpenLogFile.Name = "btnOpenLogFile";
            this.btnOpenLogFile.Size = new System.Drawing.Size(40, 40);
            this.btnOpenLogFile.TabIndex = 1;
            this.toolTip.SetToolTip(this.btnOpenLogFile, "Open log file...");
            this.btnOpenLogFile.UseVisualStyleBackColor = true;
            this.btnOpenLogFile.Click += new System.EventHandler(this.btnOpenLogFile_Click);
            // 
            // LogModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnOpenLogFile);
            this.Controls.Add(this.dlvLogMessages);
            this.Name = "LogModule";
            this.Size = new System.Drawing.Size(861, 357);
            this.Load += new System.EventHandler(this.LogModule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dlvLogMessages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DefaultListView dlvLogMessages;
        private BrightIdeasSoftware.OLVColumn colTimeStamp;
        private BrightIdeasSoftware.OLVColumn colLogLevel;
        private BrightIdeasSoftware.OLVColumn colText;
        private BrightIdeasSoftware.OLVColumn colException;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Button btnOpenLogFile;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
