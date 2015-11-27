using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MemoScope.Modules.Process
{
    public partial class ProcessInfoViewer : UserControl
    {
        public List<ProcessInfoValue> ProcessInfoValues { get; } = new List<ProcessInfoValue>();
        private ProcessWrapper processWrapper;

        public ProcessWrapper ProcessWrapper
        {
            set
            {
                processWrapper = value;
                foreach (var processInfoValue in ProcessInfoValues)
                {
                    processInfoValue.Reset();
                }
                dlvProcessInfoValues.SetObjects(ProcessInfoValues);
                dlvProcessInfoValues.BuildGroups(colGroup, SortOrder.Ascending);
                dlvProcessInfoValues.IsSimpleDragSource = true;
            }
        }

        public ProcessInfoViewer()
        {
            InitializeComponent();
            colName.AspectGetter = rowObject => ((ProcessInfoValue) rowObject).Name;
            colValue.AspectGetter = rowObject =>
            {
                try
                {
                    if (processWrapper == null || processWrapper.Process.HasExited)
                    {
                        return null;
                    }
                    var val = ((ProcessInfoValue) rowObject).GetValue(processWrapper);
                    return val;
                }
                catch
                {
                    return null;
                }
            };
            colGroup.AspectGetter = rowObject => ((ProcessInfoValue) rowObject).GroupName;
            dlvProcessInfoValues.CheckStateGetter = rowObject =>
            {
                var x = ((ProcessInfoValue) rowObject);
                if (x.Series != null)
                {
                    return x.Series.Enabled ? CheckState.Checked : CheckState.Unchecked;
                }
                return CheckState.Indeterminate;
            };
            dlvProcessInfoValues.CheckStatePutter = (rowObject, value) =>
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

            AddValue("Start Time", "StartTime",  "_Time_", proc => proc.StartTime, false, "{0}", false);
            AddValue("User Processor Time", "UserTime", "_Time_", proc => proc.UserProcessorTime, false, "{0}", false);
            AddValue("Total Processor Time", "totaltime", "_Time_", proc => proc.TotalProcessorTime, false, "{0}", false);

            var chartArea = chart.ChartAreas[0];
            chartArea.AxisX.LabelStyle.Format = "HH:mm:ss";
            chartArea.AxisY.LabelStyle.Format = "###,###,###,##0";
            chartArea.AxisY.IsStartedFromZero = false;
        }

        private void AddValue(string name, string group, Func<ProcessWrapper, object> func, bool visible = false, string format = "{0:###,###,###,##0}", bool addSeries = true)
        {
            AddValue(name, name, group, func, visible, format, addSeries);
        }

        private void AddValue(string name, string alias, string group, Func<ProcessWrapper, object> func, bool visible = false, string format = "{0:###,###,###,##0}", bool addSeries = true)
        {
            var x = new ProcessInfoValue(name, alias, group, func, format);
            ProcessInfoValues.Add(x);
            if (addSeries)
            {
                var series = new Series(name) {XValueType = ChartValueType.DateTime, ChartType = SeriesChartType.FastLine};
                x.Series = series;
                series.Enabled = visible;
                chart.Series.Add(x.Series);
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
            foreach (var v in ProcessInfoValues)
            {
                if (v.Series != null)
                {
                    var y = v.ValueGetter(processWrapper);
                    var point = new DataPoint(now, Convert.ToDouble(y));
                    v.Series.Points.Add(point);
                }
                dlvProcessInfoValues.RefreshObject(v);
            }
        }
    }
}