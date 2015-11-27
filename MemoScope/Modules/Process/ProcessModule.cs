using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MemoScopeApi;
using Microsoft.Diagnostics.Runtime;
using Microsoft.Diagnostics.Runtime.Interop;
using WinFwk.UIMessages;
using WinFwk.UIModules;
using WinFwk.UITools.Log;
using Cursor = System.Windows.Forms.Cursor;

namespace MemoScope.Modules.Process
{
    public partial class ProcessModule : UIModule,
        IMessageListener<DumpRequest>

    {
        public static readonly MemoScopeServer DumpServer;
        private ProcessWrapper proc;
        private List<ProcessWrapper> processList;

        private Cursor CurrentCursor { get; set; }
        private FormWindowState CurrentWindowState { get; set; }

        static ProcessModule()
        {
            DumpServer = new MemoScopeServer(MemoScopeService.Instance);
        }

        public ProcessModule()
        {
            InitializeComponent();
            Name = "Process";
            Summary = "No process selected";
            Icon = Properties.Resources.ddr_memory_small;

            tbRootDir.Text = MemoScopeSettings.Instance.RootDir;
            MemoScopeService.Instance.DumpRequested += OnDumpRequested;
            processTriggersControl.Init(processInfoViewer.ProcessInfoValues);
        }

        private void cbProcess_DropDown(object sender, EventArgs e)
        {
            RefreshProcess();
            InitProcessItems();
        }

        private void InitProcessItems()
        {
            object[] processWrappers = processList.Cast<object>().ToArray();
            cbProcess.Items.Clear();
            cbProcess.Items.AddRange(processWrappers);
        }

        private void cbProcess_SelectedValueChanged(object sender, EventArgs e)
        {
            proc = cbProcess.SelectedItem as ProcessWrapper;
            if (proc != null)
            {
                Summary = proc.Process.ProcessName;
                MemoScopeSettings.Instance.LastProcessName = proc.Process.ProcessName;
                MemoScopeSettings.Instance.Save();
            }

            processInfoViewer.ProcessWrapper = proc;
            processTriggersControl.ProcessWrapper = proc;
        }

        // Called in UI thread
        public override void PostInit()
        {
            RefreshProcess();
            InitProcessItems();

            // check user settings if a previous process has been selected
            string lastProcessName = MemoScopeSettings.Instance.LastProcessName;
            if (string.IsNullOrEmpty(lastProcessName))
            {
                return;
            }

            var lastProcess = cbProcess.Items.Cast<ProcessWrapper>().FirstOrDefault(pw => pw.Process.ProcessName == lastProcessName);
            if (lastProcess != null)
            {
                cbProcess.SelectedItem = lastProcess;
                proc = (ProcessWrapper)lastProcess;
            }
            processInfoViewer.ProcessWrapper = proc;
            processTriggersControl.MessageBus = MessageBus;
        }

        private void RefreshProcess()
        {
            System.Diagnostics.Process[] procs = System.Diagnostics.Process.GetProcesses();
            processList = procs.Select(p => new ProcessWrapper(p)).OrderBy(pw => pw.Process.ProcessName).ToList();
        }

        private void OnDumpRequested(int procId)
        {
            if (proc != null && proc.Process.Id == procId)
            {
                Dump();
            }
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
            string dumpDir = Path.Combine(tbRootDir.Text, proc.Process.ProcessName);
            if (!Directory.Exists(dumpDir))
            {
                try
                {
                    Directory.CreateDirectory(dumpDir);
                }
                catch (Exception ex)
                {
                    Log("Can't create directory: " + dumpDir, ex);
                    return;
                }
            }
            DataTarget target = null;
            try
            {
                target = DataTarget.AttachToProcess(proc.Process.Id, 5000, AttachFlag.NonInvasive);
                string dumpFileName = string.Format("{0}_{1:yyyy_MM_dd_HH_mm_ss}.dmp", proc.Process.ProcessName, DateTime.Now);
                string dumpPath = Path.Combine(dumpDir, dumpFileName);

                int r = target.DebuggerInterface.WriteDumpFile(dumpPath, DEBUG_DUMP.DEFAULT);
                if (r == 0)
                {
                    Log(string.Format("Process dumped ! {0}{1}{0}Process Id: {2}", Environment.NewLine, dumpPath, proc.Process.Id), LogLevelType.Notify);
                }
                else
                {
                    Log(string.Format("Failed to dump process ! {0}{1}{0}Process Id: {2}", Environment.NewLine, dumpPath, proc.Process.Id), LogLevelType.Notify);
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
            RefreshProcess();
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

        void IMessageListener<DumpRequest>.HandleMessage(DumpRequest message)
        {
            if (message.ProcessWrapper == proc)
            {
                Dump();
            }
        }
    }
}