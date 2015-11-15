using WeifenLuo.WinFormsUI.Docking;
using WinFwk.UITools;
using WinFwk.UITools.Log;
using WinFwk.UITools.Workplace;

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
            this.mainPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tspbProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.tsslStatusMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripContainer2 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip.SuspendLayout();
            this.toolStripContainer2.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer2.ContentPanel.SuspendLayout();
            this.toolStripContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.DockTopPortion = 100D;
            this.mainPanel.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingWindow;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(925, 694);
            this.mainPanel.TabIndex = 1;
            this.mainPanel.ActiveContentChanged += new System.EventHandler(this.OnActiveContentChanged);
            // 
            // statusStrip
            // 
            this.statusStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspbProgressBar,
            this.tsslStatusMessage});
            this.statusStrip.Location = new System.Drawing.Point(0, 0);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(925, 25);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // tspbProgressBar
            // 
            this.tspbProgressBar.Name = "tspbProgressBar";
            this.tspbProgressBar.Size = new System.Drawing.Size(100, 19);
            this.tspbProgressBar.Visible = false;
            // 
            // tsslStatusMessage
            // 
            this.tsslStatusMessage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsslStatusMessage.Name = "tsslStatusMessage";
            this.tsslStatusMessage.Size = new System.Drawing.Size(910, 20);
            this.tsslStatusMessage.Spring = true;
            this.tsslStatusMessage.Text = "Ok.";
            this.tsslStatusMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripContainer2
            // 
            // 
            // toolStripContainer2.BottomToolStripPanel
            // 
            this.toolStripContainer2.BottomToolStripPanel.Controls.Add(this.statusStrip);
            // 
            // toolStripContainer2.ContentPanel
            // 
            this.toolStripContainer2.ContentPanel.Controls.Add(this.mainPanel);
            this.toolStripContainer2.ContentPanel.Size = new System.Drawing.Size(925, 694);
            this.toolStripContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer2.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer2.Name = "toolStripContainer2";
            this.toolStripContainer2.Size = new System.Drawing.Size(925, 744);
            this.toolStripContainer2.TabIndex = 5;
            this.toolStripContainer2.Text = "toolStripContainer2";
            // 
            // UIModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 744);
            this.Controls.Add(this.toolStripContainer2);
            this.HelpButton = true;
            this.IsMdiContainer = true;
            this.Name = "UIModuleForm";
            this.Text = "UIModuleForm";
            this.Load += new System.EventHandler(this.UIModuleForm_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStripContainer2.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer2.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer2.ContentPanel.ResumeLayout(false);
            this.toolStripContainer2.ResumeLayout(false);
            this.toolStripContainer2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar tspbProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel tsslStatusMessage;
        private DockPanel mainPanel;
        private System.Windows.Forms.ToolStripContainer toolStripContainer2;

        protected void InitWorkplace()
        {
            DockModule(new WorkplaceModule(), DockState.DockLeft, false);
        }

        protected void InitLog()
        {
            DockModule(new LogModule(), DockState.DockBottomAutoHide, false);
        }
    }
}