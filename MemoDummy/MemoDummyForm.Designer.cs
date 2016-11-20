namespace MemoDummy
{
    partial class MemoDummyForm
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
            this.components = new System.ComponentModel.Container();
            this.lbScripts = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbScripts = new System.Windows.Forms.GroupBox();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.gbconfig = new System.Windows.Forms.GroupBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbScripts.SuspendLayout();
            this.gbconfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbScripts
            // 
            this.lbScripts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbScripts.FormattingEnabled = true;
            this.lbScripts.ItemHeight = 16;
            this.lbScripts.Location = new System.Drawing.Point(3, 18);
            this.lbScripts.Name = "lbScripts";
            this.lbScripts.Size = new System.Drawing.Size(261, 463);
            this.lbScripts.TabIndex = 0;
            this.lbScripts.SelectedIndexChanged += new System.EventHandler(this.lbScripts_SelectedIndexChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbScripts);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gbconfig);
            this.splitContainer1.Size = new System.Drawing.Size(802, 484);
            this.splitContainer1.SplitterDistance = 267;
            this.splitContainer1.TabIndex = 1;
            // 
            // gbScripts
            // 
            this.gbScripts.Controls.Add(this.lbScripts);
            this.gbScripts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbScripts.Location = new System.Drawing.Point(0, 0);
            this.gbScripts.Name = "gbScripts";
            this.gbScripts.Size = new System.Drawing.Size(267, 484);
            this.gbScripts.TabIndex = 1;
            this.gbScripts.TabStop = false;
            this.gbScripts.Text = "Memo Scripts";
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid1.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.propertyGrid1.Location = new System.Drawing.Point(6, 21);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(513, 407);
            this.propertyGrid1.TabIndex = 0;
            // 
            // gbconfig
            // 
            this.gbconfig.Controls.Add(this.btnStop);
            this.gbconfig.Controls.Add(this.btnRun);
            this.gbconfig.Controls.Add(this.propertyGrid1);
            this.gbconfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbconfig.Location = new System.Drawing.Point(0, 0);
            this.gbconfig.Name = "gbconfig";
            this.gbconfig.Size = new System.Drawing.Size(531, 484);
            this.gbconfig.TabIndex = 1;
            this.gbconfig.TabStop = false;
            this.gbconfig.Text = "Config";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(444, 434);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 38);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(6, 440);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 38);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = false;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MemoDummyForm
            // 
            this.ClientSize = new System.Drawing.Size(802, 484);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MemoDummyForm";
            this.Text = "Memory Dummy";
            this.Load += new System.EventHandler(this.MemoDummyForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbScripts.ResumeLayout(false);
            this.gbconfig.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbScripts;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gbScripts;
        private System.Windows.Forms.GroupBox gbconfig;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Timer timer1;
    }
}