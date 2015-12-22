namespace WinFwk.UITools.Workplace
{
    partial class WorkplaceModule
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
            this.tlvModules = new WinFwk.UITools.DefaultTreeListView();
            this.colName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colSummary = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.tlvModules)).BeginInit();
            this.SuspendLayout();
            // 
            // tlvModules
            // 
            this.tlvModules.AllColumns.Add(this.colName);
            this.tlvModules.AllColumns.Add(this.colSummary);
            this.tlvModules.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colSummary});
            this.tlvModules.DataSource = null;
            this.tlvModules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlvModules.FullRowSelect = true;
            this.tlvModules.HideSelection = false;
            this.tlvModules.Location = new System.Drawing.Point(0, 0);
            this.tlvModules.Name = "tlvModules";
            this.tlvModules.OwnerDraw = true;
            this.tlvModules.RootKeyValueString = "";
            this.tlvModules.ShowGroups = false;
            this.tlvModules.ShowImagesOnSubItems = true;
            this.tlvModules.Size = new System.Drawing.Size(539, 519);
            this.tlvModules.TabIndex = 0;
            this.tlvModules.UseCompatibleStateImageBehavior = false;
            this.tlvModules.View = System.Windows.Forms.View.Details;
            this.tlvModules.VirtualMode = true;
            this.tlvModules.SelectionChanged += new System.EventHandler(this.tlvModules_SelectionChanged);
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 150;
            // 
            // colSummary
            // 
            this.colSummary.Text = "Summary";
            this.colSummary.Width = 250;
            // 
            // WorkplaceModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlvModules);
            this.Name = "WorkplaceModule";
            this.Size = new System.Drawing.Size(539, 519);
            ((System.ComponentModel.ISupportInitialize)(this.tlvModules)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DefaultTreeListView tlvModules;
        private BrightIdeasSoftware.OLVColumn colName;
        private BrightIdeasSoftware.OLVColumn colSummary;
    }
}
