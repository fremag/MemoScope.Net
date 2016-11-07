namespace MemoScope.Modules.TypeStats
{
    partial class TypeStatModule
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
            this.dlvTypeStats = new WinFwk.UITools.DefaultListView();
            this.regexFilterControl = new MemoScope.Tools.RegexFilter.RegexFilterControl();
            this.lblDumpPath = new System.Windows.Forms.Label();
            this.tbDumpPath = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dlvTypeStats)).BeginInit();
            this.SuspendLayout();
            // 
            // dlvTypeStats
            // 
            this.dlvTypeStats.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dlvTypeStats.CellEditUseWholeCell = false;
            this.dlvTypeStats.FullRowSelect = true;
            this.dlvTypeStats.HideSelection = false;
            this.dlvTypeStats.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this.dlvTypeStats.HighlightForegroundColor = System.Drawing.Color.Empty;
            this.dlvTypeStats.Location = new System.Drawing.Point(0, 77);
            this.dlvTypeStats.Name = "dlvTypeStats";
            this.dlvTypeStats.ShowGroups = false;
            this.dlvTypeStats.ShowImagesOnSubItems = true;
            this.dlvTypeStats.Size = new System.Drawing.Size(452, 409);
            this.dlvTypeStats.TabIndex = 0;
            this.dlvTypeStats.UseCompatibleStateImageBehavior = false;
            this.dlvTypeStats.View = System.Windows.Forms.View.Details;
            this.dlvTypeStats.VirtualMode = true;
            this.dlvTypeStats.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.dlvTypeStats_CellClick);
            // 
            // regexFilterControl
            // 
            this.regexFilterControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.regexFilterControl.Location = new System.Drawing.Point(0, 34);
            this.regexFilterControl.Name = "regexFilterControl";
            this.regexFilterControl.Size = new System.Drawing.Size(449, 37);
            this.regexFilterControl.TabIndex = 1;
            // 
            // lblDumpPath
            // 
            this.lblDumpPath.AutoSize = true;
            this.lblDumpPath.Location = new System.Drawing.Point(10, 9);
            this.lblDumpPath.Name = "lblDumpPath";
            this.lblDumpPath.Size = new System.Drawing.Size(45, 17);
            this.lblDumpPath.TabIndex = 2;
            this.lblDumpPath.Text = "Path :";
            // 
            // tbDumpPath
            // 
            this.tbDumpPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDumpPath.Location = new System.Drawing.Point(71, 6);
            this.tbDumpPath.Name = "tbDumpPath";
            this.tbDumpPath.ReadOnly = true;
            this.tbDumpPath.Size = new System.Drawing.Size(378, 22);
            this.tbDumpPath.TabIndex = 3;
            // 
            // TypeStatModule
            // 
            this.Controls.Add(this.tbDumpPath);
            this.Controls.Add(this.lblDumpPath);
            this.Controls.Add(this.regexFilterControl);
            this.Controls.Add(this.dlvTypeStats);
            this.Name = "TypeStatModule";
            this.Size = new System.Drawing.Size(452, 486);
            ((System.ComponentModel.ISupportInitialize)(this.dlvTypeStats)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
#pragma warning restore CS0618 // Le type ou le membre est obsolète

        private WinFwk.UITools.DefaultListView dlvTypeStats;
        private MemoScope.Tools.RegexFilter.RegexFilterControl regexFilterControl;
        private System.Windows.Forms.Label lblDumpPath;
        private System.Windows.Forms.TextBox tbDumpPath;
    }
}
