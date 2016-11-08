namespace MemoScope.Tools.RegexFilter
{
    partial class RegexFilterControl
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
            this.lblFilterName = new System.Windows.Forms.Label();
            this.tbRegex = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cbIgnoreCase = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFilterName
            // 
            this.lblFilterName.AutoSize = true;
            this.lblFilterName.Location = new System.Drawing.Point(9, 6);
            this.lblFilterName.Name = "lblFilterName";
            this.lblFilterName.Size = new System.Drawing.Size(47, 17);
            this.lblFilterName.TabIndex = 0;
            this.lblFilterName.Text = "Filter :";
            // 
            // tbRegex
            // 
            this.tbRegex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRegex.Location = new System.Drawing.Point(71, 4);
            this.tbRegex.Name = "tbRegex";
            this.tbRegex.Size = new System.Drawing.Size(489, 22);
            this.tbRegex.TabIndex = 1;
            this.tbRegex.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbRegex_KeyUp);
            // 
            // cbIgnoreCase
            // 
            this.cbIgnoreCase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbIgnoreCase.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbIgnoreCase.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbIgnoreCase.Image = global::MemoScope.Properties.Resources.text_uppercase;
            this.cbIgnoreCase.Location = new System.Drawing.Point(626, 4);
            this.cbIgnoreCase.Name = "cbIgnoreCase";
            this.cbIgnoreCase.Size = new System.Drawing.Size(25, 23);
            this.cbIgnoreCase.TabIndex = 4;
            this.toolTip1.SetToolTip(this.cbIgnoreCase, "Check to filter case sensitive");
            this.cbIgnoreCase.UseVisualStyleBackColor = true;
            this.cbIgnoreCase.CheckedChanged += new System.EventHandler(this.cbIgnoreCase_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Image = global::MemoScope.Properties.Resources.cancel;
            this.btnCancel.Location = new System.Drawing.Point(597, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(25, 23);
            this.btnCancel.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btnCancel, "Apply RegEx filter");
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Image = global::MemoScope.Properties.Resources.accept_button;
            this.btnApply.Location = new System.Drawing.Point(566, 4);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(25, 23);
            this.btnApply.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btnApply, "Apply RegEx filter");
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // RegexFilterControl
            // 
            this.Controls.Add(this.cbIgnoreCase);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.tbRegex);
            this.Controls.Add(this.lblFilterName);
            this.Name = "RegexFilterControl";
            this.Size = new System.Drawing.Size(659, 32);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFilterName;
        private System.Windows.Forms.TextBox tbRegex;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox cbIgnoreCase;
    }
}
