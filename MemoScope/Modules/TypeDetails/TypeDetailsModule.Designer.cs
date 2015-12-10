namespace MemoScope.Modules.TypeDetails
{
    partial class TypeDetailsModule
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbTypeInformation = new System.Windows.Forms.GroupBox();
            this.pgTypeInfo = new System.Windows.Forms.PropertyGrid();
            this.gbFiledProperties = new System.Windows.Forms.GroupBox();
            this.dlvFields = new WinFwk.UITools.DefaultListView();
            this.gbMethods = new System.Windows.Forms.GroupBox();
            this.dlvMethods = new WinFwk.UITools.DefaultListView();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbTypeInformation.SuspendLayout();
            this.gbFiledProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dlvFields)).BeginInit();
            this.gbMethods.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dlvMethods)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gbMethods);
            this.splitContainer1.Size = new System.Drawing.Size(460, 531);
            this.splitContainer1.SplitterDistance = 350;
            this.splitContainer1.TabIndex = 0;
            // 
            // gbTypeInformation
            // 
            this.gbTypeInformation.Controls.Add(this.pgTypeInfo);
            this.gbTypeInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTypeInformation.Location = new System.Drawing.Point(0, 0);
            this.gbTypeInformation.Name = "gbTypeInformation";
            this.gbTypeInformation.Size = new System.Drawing.Size(224, 350);
            this.gbTypeInformation.TabIndex = 0;
            this.gbTypeInformation.TabStop = false;
            this.gbTypeInformation.Text = "Informations";
            // 
            // pgTypeInfo
            // 
            this.pgTypeInfo.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.pgTypeInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgTypeInfo.HelpVisible = false;
            this.pgTypeInfo.Location = new System.Drawing.Point(3, 18);
            this.pgTypeInfo.Name = "pgTypeInfo";
            this.pgTypeInfo.Size = new System.Drawing.Size(218, 329);
            this.pgTypeInfo.TabIndex = 0;
            this.pgTypeInfo.ToolbarVisible = false;
            // 
            // gbFiledProperties
            // 
            this.gbFiledProperties.Controls.Add(this.dlvFields);
            this.gbFiledProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbFiledProperties.Location = new System.Drawing.Point(0, 0);
            this.gbFiledProperties.Name = "gbFiledProperties";
            this.gbFiledProperties.Size = new System.Drawing.Size(232, 350);
            this.gbFiledProperties.TabIndex = 0;
            this.gbFiledProperties.TabStop = false;
            this.gbFiledProperties.Text = "Fields / Properties";
            // 
            // dlvFields
            // 
            this.dlvFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlvFields.FullRowSelect = true;
            this.dlvFields.HideSelection = false;
            this.dlvFields.Location = new System.Drawing.Point(3, 18);
            this.dlvFields.Name = "dlvFields";
            this.dlvFields.OwnerDraw = true;
            this.dlvFields.ShowGroups = false;
            this.dlvFields.ShowImagesOnSubItems = true;
            this.dlvFields.Size = new System.Drawing.Size(226, 329);
            this.dlvFields.TabIndex = 0;
            this.dlvFields.UseCompatibleStateImageBehavior = false;
            this.dlvFields.View = System.Windows.Forms.View.Details;
            this.dlvFields.VirtualMode = true;
            // 
            // gbMethods
            // 
            this.gbMethods.Controls.Add(this.dlvMethods);
            this.gbMethods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMethods.Location = new System.Drawing.Point(0, 0);
            this.gbMethods.Name = "gbMethods";
            this.gbMethods.Size = new System.Drawing.Size(460, 177);
            this.gbMethods.TabIndex = 1;
            this.gbMethods.TabStop = false;
            this.gbMethods.Text = "Methods";
            // 
            // dlvMethods
            // 
            this.dlvMethods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlvMethods.FullRowSelect = true;
            this.dlvMethods.HideSelection = false;
            this.dlvMethods.Location = new System.Drawing.Point(3, 18);
            this.dlvMethods.Name = "dlvMethods";
            this.dlvMethods.OwnerDraw = true;
            this.dlvMethods.ShowGroups = false;
            this.dlvMethods.ShowImagesOnSubItems = true;
            this.dlvMethods.Size = new System.Drawing.Size(454, 156);
            this.dlvMethods.TabIndex = 0;
            this.dlvMethods.UseCompatibleStateImageBehavior = false;
            this.dlvMethods.View = System.Windows.Forms.View.Details;
            this.dlvMethods.VirtualMode = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.gbTypeInformation);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.gbFiledProperties);
            this.splitContainer3.Size = new System.Drawing.Size(460, 350);
            this.splitContainer3.SplitterDistance = 224;
            this.splitContainer3.TabIndex = 1;
            // 
            // TypeDetailsModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "TypeDetailsModule";
            this.Size = new System.Drawing.Size(460, 531);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbTypeInformation.ResumeLayout(false);
            this.gbFiledProperties.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dlvFields)).EndInit();
            this.gbMethods.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dlvMethods)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gbTypeInformation;
        private System.Windows.Forms.PropertyGrid pgTypeInfo;
        private System.Windows.Forms.GroupBox gbFiledProperties;
        private System.Windows.Forms.GroupBox gbMethods;
        private WinFwk.UITools.DefaultListView dlvFields;
        private WinFwk.UITools.DefaultListView dlvMethods;
        private System.Windows.Forms.SplitContainer splitContainer3;
    }
}
