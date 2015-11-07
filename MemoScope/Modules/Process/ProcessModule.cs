using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WinFwk.UIModules;

namespace MemoScope.Modules.Process
{
    public partial class ProcessModule : UIModule
    {
        private ProcessWrapper proc;
        readonly List<ProcessInfoValue> values = new List<ProcessInfoValue>();

        public ProcessModule()
        {
            InitializeComponent();
            Name = "Process";
            Summary = "Process";
            Icon = Properties.Resources.ddr_memory_small;
            colName.AspectGetter = rowObject => ((ProcessInfoValue) rowObject).Name;
            colValue.AspectGetter = rowObject => proc == null ? null : ((ProcessInfoValue) rowObject).GetValue(proc);
            colGroup.AspectGetter = rowObject => ((ProcessInfoValue) rowObject).GroupName;
            colGroup.GroupKeyGetter = rowObject => ((ProcessInfoValue)rowObject).GroupName;
            defaultListView1.CheckStateGetter = rowObject =>
            {
                var x = ((ProcessInfoValue) rowObject);
                if (x.Series != null)
                {
                    return x.Series.Enabled ? CheckState.Checked : CheckState.Unchecked;
                }
                return CheckState.Unchecked;
            };
            defaultListView1.CheckStatePutter = (rowObject, value) => {
                ((ProcessInfoValue)rowObject).Series.Enabled = (value == CheckState.Checked);
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

        private void AddValue(string name, string group, Func<ProcessWrapper, object> func, bool visible=false, string format= "{0:###,###,###,##0}", bool addSeries=true)
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
        
        private void cbProcess_DropDown(object sender, System.EventArgs e)
        {
            System.Diagnostics.Process[] procs = System.Diagnostics.Process.GetProcesses();

            cbProcess.Items.Clear();
            cbProcess.Items.AddRange(procs.Select( p=> new ProcessWrapper(p)).OrderBy(pw => pw.Process.ProcessName).Cast<object>().ToArray());
        }
        private void cbProcess_SelectedValueChanged(object sender, EventArgs e)
        {
            proc = cbProcess.SelectedItem as ProcessWrapper;
            if (proc != null)
                Summary = proc.Process.ProcessName;
            foreach (var processInfoValue in values)
            {
                processInfoValue.Reset();
            }
            defaultListView1.SetObjects(values);
            defaultListView1.BuildGroups(colGroup, SortOrder.Ascending);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (proc == null)
            {
                return;
            }
            var now = DateTime.Now.ToOADate();
            foreach (var v in values)
            {
                if (v.Series != null)
                {
                    var y = v.ValueGetter(proc);
                    var point = new DataPoint(now, Convert.ToDouble(y));
                    v.Series.Points.Add(point);
                }
                defaultListView1.RefreshObject(v);
            }
        }
    }

    public class ProcessInfoValue
    {
        public string Name { get; private set; }    
        public string GroupName { get; private set; }
        public string Format { get; private set; }
        public Func<ProcessWrapper, object> ValueGetter { get; private set; }
        public Series Series { get; set; }

        public ProcessInfoValue(string name, string groupName, Func<ProcessWrapper, object> valueGetter, string format)
        {
            Name = name;
            GroupName = groupName;
            ValueGetter = valueGetter;
            Format = format;
        }

        public object GetValue(ProcessWrapper proc)
        {
            try
            {
                var o = ValueGetter(proc);
                var d = string.Format(Format, o);
                return d;
            }
            catch
            {
                return "Err";
            }
        }

        public void Reset()
        {
            Series?.Points.Clear();
        }
    }

    public class ProcessWrapper : IEquatable<ProcessWrapper>
    {
        public long VirtualMemory => Process.VirtualMemorySize64;
        public long PeakVirtualMemory => Process.PeakVirtualMemorySize64;

        public long PagedMemory => Process.PagedMemorySize64;
        public long PeakPagedMemory => Process.PeakPagedMemorySize64;

        public long PeakWorkingSet => Process.PeakWorkingSet64;
        public long WorkingSet => Process.WorkingSet64;

        public long PrivateMemory => Process.PrivateMemorySize64;
        public long HandleCount => Process.HandleCount;

        public TimeSpan TotalProcessorTime => Process.TotalProcessorTime;
        public DateTime StartTime => Process.StartTime;
        public TimeSpan UserProcessorTime => Process.UserProcessorTime;

        public System.Diagnostics.Process Process { get; }

        public ProcessWrapper(System.Diagnostics.Process process)
        {
            Process = process;
        }

        public bool Equals(ProcessWrapper other)
        {
            return other.Process.Id == Process.Id;
        }

        public override string ToString()
        {
            return string.Format("[{1}] {0}", Process.ProcessName, Process.Id);
        }
    }
}