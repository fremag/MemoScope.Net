namespace WinFwk.UIModules
{
    partial class UIModuleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tspbProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.tsslStatusMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspbProgressBar,
            this.tsslStatusMessage});
            this.statusStrip.Location = new System.Drawing.Point(0, 625);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(990, 25);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // tspbProgressBar
            // 
            this.tspbProgressBar.Name = "tspbProgressBar";
            this.tspbProgressBar.Size = new System.Drawing.Size(100, 19);
            // 
            // tsslStatusMessage
            // 
            this.tsslStatusMessage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsslStatusMessage.Name = "tsslStatusMessage";
            this.tsslStatusMessage.Size = new System.Drawing.Size(873, 20);
            this.tsslStatusMessage.Spring = true;
            this.tsslStatusMessage.Text = "Ok.";
            this.tsslStatusMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UIModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 650);
            this.Controls.Add(this.statusStrip);
            this.Name = "UIModuleForm";
            this.Text = "UIModuleForm";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar tspbProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel tsslStatusMessage;
    }
}