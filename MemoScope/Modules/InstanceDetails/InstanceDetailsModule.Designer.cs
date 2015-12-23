namespace MemoScope.Modules.InstanceDetails
{
    partial class InstanceDetailsModule
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
            this.lblAddress = new System.Windows.Forms.Label();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.gbInformation = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbFields = new System.Windows.Forms.GroupBox();
            this.gbReferences = new System.Windows.Forms.GroupBox();
            this.gbInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(7, 23);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(68, 17);
            this.lblAddress.TabIndex = 0;
            this.lblAddress.Text = "Address :";
            // 
            // tbAddress
            // 
            this.tbAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAddress.Location = new System.Drawing.Point(100, 21);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.ReadOnly = true;
            this.tbAddress.Size = new System.Drawing.Size(556, 22);
            this.tbAddress.TabIndex = 1;
            // 
            // gbInformation
            // 
            this.gbInformation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbInformation.Controls.Add(this.tbAddress);
            this.gbInformation.Controls.Add(this.lblAddress);
            this.gbInformation.Location = new System.Drawing.Point(3, 3);
            this.gbInformation.Name = "gbInformation";
            this.gbInformation.Size = new System.Drawing.Size(662, 76);
            this.gbInformation.TabIndex = 2;
            this.gbInformation.TabStop = false;
            this.gbInformation.Text = "Information";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(3, 85);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbFields);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gbReferences);
            this.splitContainer1.Size = new System.Drawing.Size(656, 755);
            this.splitContainer1.SplitterDistance = 373;
            this.splitContainer1.TabIndex = 3;
            // 
            // gbFields
            // 
            this.gbFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbFields.Location = new System.Drawing.Point(0, 0);
            this.gbFields.Name = "gbFields";
            this.gbFields.Size = new System.Drawing.Size(656, 373);
            this.gbFields.TabIndex = 0;
            this.gbFields.TabStop = false;
            this.gbFields.Text = "Fields / Properties";
            // 
            // gbReferences
            // 
            this.gbReferences.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbReferences.Location = new System.Drawing.Point(0, 0);
            this.gbReferences.Name = "gbReferences";
            this.gbReferences.Size = new System.Drawing.Size(656, 378);
            this.gbReferences.TabIndex = 0;
            this.gbReferences.TabStop = false;
            this.gbReferences.Text = "References";
            // 
            // InstanceDetailsModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.gbInformation);
            this.Name = "InstanceDetailsModule";
            this.Size = new System.Drawing.Size(668, 843);
            this.gbInformation.ResumeLayout(false);
            this.gbInformation.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.GroupBox gbInformation;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gbFields;
        private System.Windows.Forms.GroupBox gbReferences;
    }
}
