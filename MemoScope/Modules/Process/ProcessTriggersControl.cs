using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BrightIdeasSoftware;
using ExpressionEvaluator;
using WinFwk.UIMessages;
using WinFwk.UITools.Log;

namespace MemoScope.Modules.Process
{
    public partial class ProcessTriggersControl : UserControl
    {
        private List<DumpTrigger> triggers;
        private DumpTrigger currentTrigger;
        public MessageBus MessageBus { get; set; }
        public List<ProcessInfoValue> ProcessInfoValues { get; set; }
        public ProcessWrapper ProcessWrapper { get; set; }

        public ProcessTriggersControl()
        {
            InitializeComponent();

            dlvTriggers.CheckStatePutter = (rowObject, value) =>
            {
                ((DumpTrigger) rowObject).Active = (value == CheckState.Checked);
                return value;
            };
            dlvTriggers.CheckStateGetter = rowObject => ((DumpTrigger) rowObject).Active ? CheckState.Checked : CheckState.Unchecked;
            Generator.GenerateColumns(dlvTriggers, typeof (DumpTrigger), false);
        }

        private void tsbNetTrigger_Click(object sender, System.EventArgs e)
        {
            triggers.Add(new DumpTrigger());
            RefreshTriggers();
        }

        private void RefreshTriggers()
        {
            dlvTriggers.SetObjects(triggers);
            dlvTriggers.BuildGroups(nameof(DumpTrigger.Group), SortOrder.Ascending);
        }

        private void tsbSaveAllTriggers_Click(object sender, System.EventArgs e)
        {
            MemoScopeSettings.Instance.Triggers = new List<DumpTrigger>(triggers.Select(t => t.Clone()));
            MemoScopeSettings.Instance.Save();
        }

        private void tsbCloneTrigger_Click(object sender, System.EventArgs e)
        {
            ListView.SelectedIndexCollection selectedTriggers = dlvTriggers.SelectedIndices;
            foreach (int idx in selectedTriggers)
            {
                DumpTrigger trig = triggers[idx];
                var newTrig = trig.Clone();
                triggers.Add(newTrig);
            }
            RefreshTriggers();
        }

        private void tsbDeleteTrigger_Click(object sender, System.EventArgs e)
        {
            ListView.SelectedIndexCollection selectedTriggers = dlvTriggers.SelectedIndices;
            foreach (int idx in selectedTriggers)
            {
                DumpTrigger trig = triggers[idx];
                triggers.Remove(trig);
            }
            RefreshTriggers();
        }

        private void defaultListView1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            currentTrigger = dlvTriggers.SelectedObject as DumpTrigger;

            tbGroup.Text = currentTrigger?.Group;
            tbName.Text = currentTrigger?.Name;
            tbCode.Text = currentTrigger?.Code;
            cbActive.Checked = currentTrigger?.Active ?? false;
        }

        private void tbGroup_TextChanged(object sender, System.EventArgs e)
        {
            if (currentTrigger != null)
            {
                currentTrigger.Group = tbGroup.Text;
                RefreshTriggers();
            }
        }

        private void ProcessTriggers_Load(object sender, System.EventArgs e)
        {
            if (MemoScopeSettings.Instance != null)
            {
                triggers = new List<DumpTrigger>(MemoScopeSettings.Instance.Triggers.Select(t => t.Clone()));
                RefreshTriggers();
            }
        }

        private void tbName_TextChanged(object sender, System.EventArgs e)
        {
            if (currentTrigger != null)
            {
                currentTrigger.Name = tbName.Text;
                RefreshTriggers();
            }
        }

        private void tbCode_TextChanged(object sender, System.EventArgs e)
        {
            if (currentTrigger != null)
            {
                currentTrigger.Code = tbCode.Text;
                RefreshTriggers();
            }
        }

        private void tbCode_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void tbCode_DragDrop(object sender, DragEventArgs e)
        {
            var data = e.Data as OLVDataObject;
            if (data == null)
            {
                return;
            }
            foreach (ProcessInfoValue piv in data.ModelObjects)
            {
                if (tbCode.Text == null)
                {
                    tbCode.Text = piv.Name;
                }
                else
                {
                    tbCode.Text = tbCode.Text.Insert(tbCode.SelectionStart, piv.Alias);
                }
            }
        }

        private void tsbClock_CheckStateChanged(object sender, System.EventArgs e)
        {
            tsbClock.Image = tsbClock.Checked ? Properties.Resources.clock_stop : Properties.Resources.clock_go;
            tsbClock.ToolTipText = tsbClock.Checked ? "Stop": "Start";
        }

        private void tsbClock_Click(object sender, System.EventArgs e)
        {
            if (tsbClock.Checked)
            {
                string timespanStr = tscbPeriod.Text;
                TimeSpan timespan;
                if (TimeSpan.TryParse(timespanStr, out timespan))
                {
                    timer.Interval = (int) timespan.TotalMilliseconds;
                    timer.Enabled = true;
                }
                else
                {
                    Log("Can't parse timespan: '"+timespanStr+"'", LogLevelType.Error);
                    tsbClock.Checked = false;
                }
            }
            else
            {
                timer.Enabled = false;
            }
            RefreshNextTick();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (ProcessWrapper == null || ProcessWrapper.Process.HasExited)
            {
                timer.Enabled = false;
                tsbClock.Checked = false;
            }
            else
            {
                CheckDumpTriggers();
            }
            RefreshNextTick();
        }

        private void CheckDumpTriggers()
        {
            TypeRegistry reg = new TypeRegistry();
            reg.RegisterType<DateTime>();
            reg.RegisterType<TimeSpan>();
            reg.RegisterType<Regex>();

            foreach (var procInfoVal in ProcessInfoValues)
            {
                reg.RegisterSymbol(procInfoVal.Alias, procInfoVal.Value);
            }
            
            foreach (DumpTrigger trigger in triggers.Where(dt => dt.Active))
            {
                CompiledExpression<bool> exp = new CompiledExpression<bool>(trigger.Code) {TypeRegistry = reg};
                bool r = exp.Eval();
                if (r)
                {
                    trigger.Active = false;
                    Log("Trigger: " +trigger.Name+", Code: "+trigger.Code);
                    RefreshTriggers();
                    MessageBus.SendMessage(new DumpRequest(ProcessWrapper));
                }
            }
        }

        private void RefreshNextTick()
        {
            tslNextTick.Visible = tsbClock.Checked;
            tslNextTick.Text = "Next: " + (DateTime.Now + TimeSpan.FromMilliseconds(timer.Interval)).ToString("HH:mm:ss");
        }

        public void Init(List<ProcessInfoValue> processInfoValues)
        {
            ProcessInfoValues  = processInfoValues;
        }

        protected void Log(string text, LogLevelType logLevel = LogLevelType.Info)
        {
            MessageBus.SendMessage(new LogMessage(this, text, logLevel));
        }

    }
}