namespace WinFwk.UITools
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
            this.fdlvLogMessages = new BrightIdeasSoftware.FastObjectListView();
            this.colTimeStamp = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colLogLevel = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colText = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colException = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.fdlvLogMessages)).BeginInit();
            this.SuspendLayout();
            // 
            // fdlvLogMessages
            // 
            this.fdlvLogMessages.AllColumns.Add(this.colTimeStamp);
            this.fdlvLogMessages.AllColumns.Add(this.colLogLevel);
            this.fdlvLogMessages.AllColumns.Add(this.colText);
            this.fdlvLogMessages.AllColumns.Add(this.colException);
            this.fdlvLogMessages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTimeStamp,
            this.colLogLevel,
            this.colText,
            this.colException});
            this.fdlvLogMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fdlvLogMessages.FullRowSelect = true;
            this.fdlvLogMessages.HideSelection = false;
            this.fdlvLogMessages.Location = new System.Drawing.Point(0, 0);
            this.fdlvLogMessages.Name = "fdlvLogMessages";
            this.fdlvLogMessages.ShowGroups = false;
            this.fdlvLogMessages.Size = new System.Drawing.Size(861, 357);
            this.fdlvLogMessages.TabIndex = 0;
            this.fdlvLogMessages.UseCellFormatEvents = true;
            this.fdlvLogMessages.UseCompatibleStateImageBehavior = false;
            this.fdlvLogMessages.View = System.Windows.Forms.View.Details;
            this.fdlvLogMessages.VirtualMode = true;
            this.fdlvLogMessages.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.fdlvLogMessages_FormatCell);
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
            // LogModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fdlvLogMessages);
            this.Name = "LogModule";
            this.Size = new System.Drawing.Size(861, 357);
            ((System.ComponentModel.ISupportInitialize)(this.fdlvLogMessages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.FastObjectListView fdlvLogMessages;
        private BrightIdeasSoftware.OLVColumn colTimeStamp;
        private BrightIdeasSoftware.OLVColumn colLogLevel;
        private BrightIdeasSoftware.OLVColumn colText;
        private BrightIdeasSoftware.OLVColumn colException;
    }
}
