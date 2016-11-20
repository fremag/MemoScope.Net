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
#pragma warning disable CS0618 // Le type ou le membre est obsolète

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblAddress = new System.Windows.Forms.Label();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.gbInformation = new System.Windows.Forms.GroupBox();
            this.tbType = new System.Windows.Forms.TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbFields = new System.Windows.Forms.GroupBox();
            this.dtlvFieldsValues = new WinFwk.UITools.DefaultTreeListView();
            this.gbReferences = new System.Windows.Forms.GroupBox();
            this.dtlvReferences = new WinFwk.UITools.DefaultTreeListView();
            this.tbSimpleValue = new System.Windows.Forms.TextBox();
            this.lblValue = new System.Windows.Forms.Label();
            this.gbInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtlvFieldsValues)).BeginInit();
            this.gbReferences.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtlvReferences)).BeginInit();
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
            this.tbAddress.Location = new System.Drawing.Point(81, 21);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.ReadOnly = true;
            this.tbAddress.Size = new System.Drawing.Size(157, 22);
            this.tbAddress.TabIndex = 1;
            // 
            // gbInformation
            // 
            this.gbInformation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbInformation.Controls.Add(this.tbSimpleValue);
            this.gbInformation.Controls.Add(this.lblValue);
            this.gbInformation.Controls.Add(this.tbType);
            this.gbInformation.Controls.Add(this.lblType);
            this.gbInformation.Controls.Add(this.tbAddress);
            this.gbInformation.Controls.Add(this.lblAddress);
            this.gbInformation.Location = new System.Drawing.Point(3, 3);
            this.gbInformation.Name = "gbInformation";
            this.gbInformation.Size = new System.Drawing.Size(662, 76);
            this.gbInformation.TabIndex = 2;
            this.gbInformation.TabStop = false;
            this.gbInformation.Text = "Information";
            // 
            // tbType
            // 
            this.tbType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbType.Location = new System.Drawing.Point(325, 21);
            this.tbType.Name = "tbType";
            this.tbType.ReadOnly = true;
            this.tbType.Size = new System.Drawing.Size(328, 22);
            this.tbType.TabIndex = 3;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(277, 23);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(48, 17);
            this.lblType.TabIndex = 2;
            this.lblType.Text = "Type :";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.splitContainer1.SplitterDistance = 430;
            this.splitContainer1.TabIndex = 3;
            // 
            // gbFields
            // 
            this.gbFields.Controls.Add(this.dtlvFieldsValues);
            this.gbFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbFields.Location = new System.Drawing.Point(0, 0);
            this.gbFields.Name = "gbFields";
            this.gbFields.Size = new System.Drawing.Size(656, 430);
            this.gbFields.TabIndex = 0;
            this.gbFields.TabStop = false;
            this.gbFields.Text = "Fields / Properties";
            // 
            // dtlvFieldsValues
            // 
            this.dtlvFieldsValues.CellEditUseWholeCell = false;
            this.dtlvFieldsValues.DataSource = null;
            this.dtlvFieldsValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtlvFieldsValues.FullRowSelect = true;
            this.dtlvFieldsValues.HideSelection = false;
            this.dtlvFieldsValues.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this.dtlvFieldsValues.HighlightForegroundColor = System.Drawing.Color.Empty;
            this.dtlvFieldsValues.Location = new System.Drawing.Point(3, 18);
            this.dtlvFieldsValues.Name = "dtlvFieldsValues";
            this.dtlvFieldsValues.RootKeyValueString = "";
            this.dtlvFieldsValues.ShowGroups = false;
            this.dtlvFieldsValues.ShowImagesOnSubItems = true;
            this.dtlvFieldsValues.Size = new System.Drawing.Size(650, 409);
            this.dtlvFieldsValues.TabIndex = 0;
            this.dtlvFieldsValues.UseCompatibleStateImageBehavior = false;
            this.dtlvFieldsValues.View = System.Windows.Forms.View.Details;
            this.dtlvFieldsValues.VirtualMode = true;
            // 
            // gbReferences
            // 
            this.gbReferences.Controls.Add(this.dtlvReferences);
            this.gbReferences.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbReferences.Location = new System.Drawing.Point(0, 0);
            this.gbReferences.Name = "gbReferences";
            this.gbReferences.Size = new System.Drawing.Size(656, 321);
            this.gbReferences.TabIndex = 0;
            this.gbReferences.TabStop = false;
            this.gbReferences.Text = "References";
            // 
            // dtlvReferences
            // 
            this.dtlvReferences.CellEditUseWholeCell = false;
            this.dtlvReferences.DataSource = null;
            this.dtlvReferences.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtlvReferences.FullRowSelect = true;
            this.dtlvReferences.HideSelection = false;
            this.dtlvReferences.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this.dtlvReferences.HighlightForegroundColor = System.Drawing.Color.Empty;
            this.dtlvReferences.Location = new System.Drawing.Point(3, 18);
            this.dtlvReferences.Name = "dtlvReferences";
            this.dtlvReferences.RootKeyValueString = "";
            this.dtlvReferences.ShowGroups = false;
            this.dtlvReferences.ShowImagesOnSubItems = true;
            this.dtlvReferences.Size = new System.Drawing.Size(650, 300);
            this.dtlvReferences.TabIndex = 0;
            this.dtlvReferences.UseCompatibleStateImageBehavior = false;
            this.dtlvReferences.View = System.Windows.Forms.View.Details;
            this.dtlvReferences.VirtualMode = true;
            // 
            // tbValue
            // 
            this.tbSimpleValue.Location = new System.Drawing.Point(81, 46);
            this.tbSimpleValue.Name = "tbValue";
            this.tbSimpleValue.ReadOnly = true;
            this.tbSimpleValue.Size = new System.Drawing.Size(572, 22);
            this.tbSimpleValue.TabIndex = 5;
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(7, 49);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(52, 17);
            this.lblValue.TabIndex = 4;
            this.lblValue.Text = "Value :";
            // 
            // InstanceDetailsModule
            // 
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
            this.gbFields.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtlvFieldsValues)).EndInit();
            this.gbReferences.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtlvReferences)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
#pragma warning restore CS0618 // Le type ou le membre est obsolète

        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.GroupBox gbInformation;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gbFields;
        private System.Windows.Forms.GroupBox gbReferences;
        private WinFwk.UITools.DefaultTreeListView dtlvFieldsValues;
        private WinFwk.UITools.DefaultTreeListView dtlvReferences;
        private System.Windows.Forms.TextBox tbType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.TextBox tbSimpleValue;
        private System.Windows.Forms.Label lblValue;
    }
}
