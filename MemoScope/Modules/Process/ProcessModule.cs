using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceModel;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MemoScopeApi;
using Microsoft.Diagnostics.Runtime;
using Microsoft.Diagnostics.Runtime.Interop;
using WinFwk.UIModules;
using WinFwk.UITools.Log;
using Cursor = System.Windows.Forms.Cursor;

namespace MemoScope.Modules.Process
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    public partial class ProcessModule : UIModule, IMemoScopeService
    {
        private readonly List<ProcessInfoValue> values = new List<ProcessInfoValue>();
        private MemoScopeServer dumpServer;
        private ProcessWrapper proc;

        private Cursor CurrentCursor { get; set; }
        private FormWindowState CurrentWindowState { get; set; }

        public ProcessModule()
        {
            InitializeComponent();
            Name = "Process";
            Summary = "No process selected";
            Icon = Properties.Resources.ddr_memory_small;
            colName.AspectGetter = rowObject => ((ProcessInfoValue) rowObject).Name;
            colValue.AspectGetter = rowObject => proc == null ? null : ((ProcessInfoValue) rowObject).GetValue(proc);
            colGroup.AspectGetter = rowObject => ((ProcessInfoValue) rowObject).GroupName;
            colGroup.GroupKeyGetter = rowObject => ((ProcessInfoValue) rowObject).GroupName;
            defaultListView1.CheckStateGetter = rowObject =>
            {
                var x = ((ProcessInfoValue) rowObject);
                if (x.Series != null)
                {
                    return x.Series.Enabled ? CheckState.Checked : CheckState.Unchecked;
                }
                return CheckState.Unchecked;
            };
            defaultListView1.CheckStatePutter = (rowObject, value) =>
            {
                ((ProcessInfoValue) rowObject).Series.Enabled = (value == CheckState.Checked);
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

            tbRootDir.Text = MemoScopeSettings.Instance.RootDir;
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

        private void cbProcess_DropDown(object sender, EventArgs e)
        {
            Init();
        }

        private void cbProcess_SelectedValueChanged(object sender, EventArgs e)
        {
            dumpServer?.Close();

            proc = cbProcess.SelectedItem as ProcessWrapper;
            if (proc != null)
            {
                Summary = proc.Process.ProcessName;
                MemoScopeSettings.Instance.LastProcessName = proc.Process.ProcessName;
                MemoScopeSettings.Instance.Save();

                dumpServer = new MemoScopeServer(this, proc.Process.Id);
                Log("DumpServer: state=" + dumpServer.State + ", address=" + dumpServer.BaseAddresses[0].AbsolutePath);
            }

            foreach (var processInfoValue in values)
            {
                processInfoValue.Reset();
            }
            defaultListView1.SetObjects(values);
            defaultListView1.BuildGroups(colGroup, SortOrder.Ascending);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (proc == null || proc.Process.HasExited)
                {
                    return;
                }
            }
            catch (Win32Exception)
            {
                return;
            }
            // refresh process info !
            proc.Process.Refresh();

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

        public void Init()
        {
            System.Diagnostics.Process[] procs = System.Diagnostics.Process.GetProcesses();

            object[] processWrappers = procs.Select(p => new ProcessWrapper(p)).OrderBy(pw => pw.Process.ProcessName).Cast<object>().ToArray();
            cbProcess.Items.Clear();
            cbProcess.Items.AddRange(processWrappers);

            string lastProcessName = MemoScopeSettings.Instance.LastProcessName;
            if (string.IsNullOrEmpty(lastProcessName))
            {
                return;
            }

            var lastProcess = processWrappers.FirstOrDefault(pw => ((ProcessWrapper) pw).Process.ProcessName == lastProcessName);
            if (lastProcess != null)
            {
                cbProcess.SelectedItem = lastProcess;
                proc = (ProcessWrapper) lastProcess;
            }
        }

        public void DumpMe()
        {
            Dump();
        }

        private void btnDump_Click(object sender, EventArgs e)
        {
            Dump();
        }

        public void Dump()
        {
            if (proc == null)
            {
                Log("Can't dump: no process selected !", LogLevelType.Error);
                return;
            }

            if (proc.Process.HasExited)
            {
                Log("Can't dump: process has exited !", LogLevelType.Error);
                return;
            }

            if (!Directory.Exists(tbRootDir.Text))
            {
                try
                {
                    Directory.CreateDirectory(tbRootDir.Text);
                }
                catch (Exception ex)
                {
                    Log("Can't create directory: " + tbRootDir.Text, ex);
                    return;
                }
            }
            DataTarget target = null;
            try
            {
                target = DataTarget.AttachToProcess(proc.Process.Id, 5000, AttachFlag.NonInvasive);
                string dumpFileName = string.Format("{0}_{1:yyyy_MM_dd_HH_mm_ss}.dmp", proc.Process.ProcessName, DateTime.Now);
                string dumpPath = Path.Combine(tbRootDir.Text, dumpFileName);

                int r = target.DebuggerInterface.WriteDumpFile(dumpPath, DEBUG_DUMP.DEFAULT);
                if (r == 0)
                {
                    Log("Process dumped ! " + Environment.NewLine + dumpPath, LogLevelType.Notify);
                }
            }
            catch (Exception ex)
            {
                Log("Can't dump process !", ex);
            }
            finally
            {
                if (target != null)
                {
                    target.DebuggerInterface?.DetachProcesses();
                    target.Dispose();
                }
            }
        }

        [DllImport("user32.dll")]
        private static extern IntPtr WindowFromPoint(CursorPos pos);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(out CursorPos pt);

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr handle, out uint pId);

        private void btnFindProcess_MouseDown(object sender, MouseEventArgs e)
        {
            var form = GetMainForm();
            CurrentWindowState = form.WindowState;
            form.WindowState = FormWindowState.Normal;
            form.SendToBack();
            CurrentCursor = Cursor.Current;
            Cursor.Current = Cursors.UpArrow;
        }

        private void btnFindProcess_MouseUp(object sender, MouseEventArgs e)
        {
            uint pId = GetProcessFromWindow();
            var processWrapper = cbProcess.Items.Cast<ProcessWrapper>().FirstOrDefault(pw => pw.Process.Id == pId);
            if (processWrapper != null)
            {
                cbProcess.SelectedItem = processWrapper;
            }

            var form = GetMainForm();
            form.BringToFront();
            form.WindowState = CurrentWindowState;
            Cursor.Current = CurrentCursor;
        }

        private uint GetProcessFromWindow()
        {
            CursorPos pos;
            GetCursorPos(out pos);
            IntPtr winHandle = WindowFromPoint(pos);
            uint pId;
            GetWindowThreadProcessId(winHandle, out pId);
            return pId;
        }

        private Form GetMainForm()
        {
            var forms = Application.OpenForms.Cast<Form>().ToArray();
            var handle = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
            var mainForm = forms.First(form => form.Handle == handle);
            return mainForm;
        }

        public struct CursorPos
        {
            public int xx;
            public int yy;
        }
    }
}