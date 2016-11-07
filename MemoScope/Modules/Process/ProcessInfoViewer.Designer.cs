namespace MemoScope.Modules.Process
{
    partial class ProcessInfoViewer
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dlvProcessInfoValues = new WinFwk.UITools.DefaultListView();
            this.colName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colValue = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.colGroup = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dlvProcessInfoValues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dlvProcessInfoValues);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chart);
            this.splitContainer1.Size = new System.Drawing.Size(889, 547);
            this.splitContainer1.SplitterDistance = 429;
            this.splitContainer1.TabIndex = 3;
            // 
            // dlvProcessInfoValues
            // 
            this.dlvProcessInfoValues.AllColumns.Add(this.colName);
            this.dlvProcessInfoValues.AllColumns.Add(this.colValue);
            this.dlvProcessInfoValues.CheckBoxes = true;
            this.dlvProcessInfoValues.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colValue});
            this.dlvProcessInfoValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlvProcessInfoValues.FullRowSelect = true;
            this.dlvProcessInfoValues.HideSelection = false;
            this.dlvProcessInfoValues.Location = new System.Drawing.Point(0, 0);
            this.dlvProcessInfoValues.Name = "dlvProcessInfoValues";
            this.dlvProcessInfoValues.OwnerDraw = true;
            this.dlvProcessInfoValues.ShowGroups = false;
            this.dlvProcessInfoValues.ShowImagesOnSubItems = true;
            this.dlvProcessInfoValues.Size = new System.Drawing.Size(429, 547);
            this.dlvProcessInfoValues.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.dlvProcessInfoValues.TabIndex = 2;
            this.dlvProcessInfoValues.UseCompatibleStateImageBehavior = false;
            this.dlvProcessInfoValues.View = System.Windows.Forms.View.Details;
            this.dlvProcessInfoValues.VirtualMode = true;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 150;
            // 
            // colValue
            // 
            this.colValue.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colValue.Text = "Value";
            this.colValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colValue.Width = 200;
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend1.Name = "Legend1";
            legend1.TableStyle = System.Windows.Forms.DataVisualization.Charting.LegendTableStyle.Wide;
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(0, 0);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(456, 547);
            this.chart.TabIndex = 0;
            this.chart.Text = "chart";
            // 
            // colGroup
            // 
            this.colGroup.DisplayIndex = 0;
            this.colGroup.IsVisible = false;
            this.colGroup.Text = "Group";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // ProcessInfoViewer
            // 
            this.Controls.Add(this.splitContainer1);
            this.Name = "ProcessInfoViewer";
            this.Size = new System.Drawing.Size(889, 547);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dlvProcessInfoValues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private WinFwk.UITools.DefaultListView dlvProcessInfoValues;
        private BrightIdeasSoftware.OLVColumn colName;
        private BrightIdeasSoftware.OLVColumn colValue;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private BrightIdeasSoftware.OLVColumn colGroup;
        private System.Windows.Forms.Timer timer;
    }
}
