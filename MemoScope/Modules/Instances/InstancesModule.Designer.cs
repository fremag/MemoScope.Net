namespace MemoScope.Modules.Instances
{
    partial class InstancesModule
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
            this.dlvAdresses = new WinFwk.UITools.DefaultListView();
            ((System.ComponentModel.ISupportInitialize)(this.dlvAdresses)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultListView1
            // 
            this.dlvAdresses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlvAdresses.FullRowSelect = true;
            this.dlvAdresses.HideSelection = false;
            this.dlvAdresses.Location = new System.Drawing.Point(0, 0);
            this.dlvAdresses.Name = "defaultListView1";
            this.dlvAdresses.OwnerDraw = true;
            this.dlvAdresses.ShowGroups = false;
            this.dlvAdresses.ShowImagesOnSubItems = true;
            this.dlvAdresses.Size = new System.Drawing.Size(570, 544);
            this.dlvAdresses.TabIndex = 0;
            this.dlvAdresses.UseCompatibleStateImageBehavior = false;
            this.dlvAdresses.View = System.Windows.Forms.View.Details;
            this.dlvAdresses.VirtualMode = true;
            // 
            // InstancesModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dlvAdresses);
            this.Name = "InstancesModule";
            this.Size = new System.Drawing.Size(570, 544);
            ((System.ComponentModel.ISupportInitialize)(this.dlvAdresses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private WinFwk.UITools.DefaultListView dlvAdresses;
    }
}
