using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MemoScope.Modules.Process
{
    public partial class ProcessInfoViewer : UserControl
    {
        private readonly List<ProcessInfoValue> values = new List<ProcessInfoValue>();

        private ProcessWrapper processWrapper;

        public ProcessWrapper ProcessWrapper
        {
            set
            {
                processWrapper = value;
                foreach (var processInfoValue in values)
                {
                    processInfoValue.Reset();
                }
                defaultListView1.SetObjects(values);
                defaultListView1.BuildGroups(colGroup, SortOrder.Ascending);
            }
        }

        public ProcessInfoViewer()
        {
            InitializeComponent();
            colName.AspectGetter = rowObject => ((ProcessInfoValue) rowObject).Name;
            colValue.AspectGetter = rowObject => processWrapper == null ? null : ((ProcessInfoValue) rowObject).GetValue(processWrapper);
            colGroup.AspectGetter = rowObject => ((ProcessInfoValue) rowObject).GroupName;
            defaultListView1.CheckStateGetter = rowObject =>
            {
                var x = ((ProcessInfoValue) rowObject);
                if (x.Series != null)
                {
                    return x.Series.Enabled ? CheckState.Checked : CheckState.Unchecked;
                }
                return CheckState.Indeterminate;
            };
            defaultListView1.CheckStatePutter = (rowObject, value) =>
            {
                var series = ((ProcessInfoValue) rowObject).Series;
                if (series == null)
                {
                    return CheckState.Indeterminate;
                }
                series.Enabled = (value == CheckState.Checked);
                return value;
            };

            AddValue("VirtualMemory", "Virtual", proc => proc.VirtualMemory, true);
            AddValue("PeakVirtualMemory", "Virtual", proc => proc.PeakVirtualMemory);

            AddValue("PagedMemory", "Paged", proc => proc.PagedMemory, true);
            AddValue("PeakPagedMemory", "Paged", proc => proc.PeakPagedMemory);

            AddValue("WorkingSet", "WorkingSet", proc => proc.WorkingSet, true);
            AddValue("PeakWorkingSet", "WorkingSet", proc => proc.PeakWorkingSet);

            AddValue("Private", "Private", proc => proc.PrivateMemory);
            AddValue("HandleCount", "Handles", proc => proc.HandleCount);

            AddValue("Start Time", "_Time_", proc => proc.StartTime, false, "{0}", false);
            AddValue("User Processor Time", "_Time_", proc => proc.UserProcessorTime, false, "{0}", false);
            AddValue("Total Processor Time", "_Time_", proc => proc.TotalProcessorTime, false, "{0}", false);

            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "###,###,###,##0";
            chart1.ChartAreas[0].AxisY.IsStartedFromZero = false;
        }

        private void AddValue(string name, string group, Func<ProcessWrapper, object> func, bool visible = false, string format = "{0:###,###,###,##0}", bool addSeries = true)
        {
            var x = new ProcessInfoValue(name, group, func, format);
            values.Add(x);
            if (addSeries)
            {
                var series = new Series(name) {XValueType = ChartValueType.DateTime, ChartType = SeriesChartType.FastLine};
                x.Series = series;
                series.Enabled = visible;
                chart1.Series.Add(x.Series);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (processWrapper == null || processWrapper.Process.HasExited)
                {
                    return;
                }
            }
            catch (Win32Exception)
            {
                return;
            }
            // refresh process info !
            processWrapper.Process.Refresh();

            var now = DateTime.Now.ToOADate();
            foreach (var v in values)
            {
                if (v.Series != null)
                {
                    var y = v.ValueGetter(processWrapper);
                    var point = new DataPoint(now, Convert.ToDouble(y));
                    v.Series.Points.Add(point);
                }
                defaultListView1.RefreshObject(v);
            }
        }
    }
}