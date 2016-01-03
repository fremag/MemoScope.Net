using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BrightIdeasSoftware;
using WinFwk.UIMessages;
using WinFwk.UITools.Log;
using MemoScope.Core.Data;
using System;

namespace MemoScope.Modules.Process
{
    public partial class ProcessTriggersControl : UserControl
    {
        public List<CodeTrigger> Triggers => triggers;
        public MessageBus MessageBus { get; set; }
        public Func<object, string> CodeGetter;

        private List<CodeTrigger> triggers;
        private CodeTrigger currentTrigger;

        public ProcessTriggersControl()
        {
            InitializeComponent();

            dlvTriggers.CheckStatePutter = (rowObject, value) =>
            {
                ((CodeTrigger) rowObject).Active = (value == CheckState.Checked);
                return value;
            };
            dlvTriggers.CheckStateGetter = rowObject => ((CodeTrigger) rowObject).Active ? CheckState.Checked : CheckState.Unchecked;
            Generator.GenerateColumns(dlvTriggers, typeof (CodeTrigger), false);
        }

        private void tsbNetTrigger_Click(object sender, System.EventArgs e)
        {
            triggers.Add(new CodeTrigger());
            RefreshTriggers();
        }

        public void RefreshTriggers()
        {
            dlvTriggers.SetObjects(triggers);
            dlvTriggers.BuildGroups(nameof(CodeTrigger.Group), SortOrder.Ascending);
        }

        private void tsbSaveAllTriggers_Click(object sender, System.EventArgs e)
        {
            MemoScopeSettings.Instance.Triggers = new List<CodeTrigger>(triggers.Select(t => t.Clone()));
            MemoScopeSettings.Instance.Save();
        }

        private void tsbCloneTrigger_Click(object sender, System.EventArgs e)
        {
            ListView.SelectedIndexCollection selectedTriggers = dlvTriggers.SelectedIndices;
            foreach (int idx in selectedTriggers)
            {
                CodeTrigger trig = triggers[idx];
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
                CodeTrigger trig = triggers[idx];
                triggers.Remove(trig);
            }
            RefreshTriggers();
        }

        private void dlvTriggers_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            currentTrigger = dlvTriggers.SelectedObject as CodeTrigger;

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
                triggers = new List<CodeTrigger>(MemoScopeSettings.Instance.Triggers.Select(t => t.Clone()));
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
            foreach (object obj in data.ModelObjects)
            {
                if (tbCode.Text == null)
                {
                    tbCode.Text = CodeGetter(obj);
                }
                else
                {
                    tbCode.Text = tbCode.Text.Insert(tbCode.SelectionStart, CodeGetter(obj));
                }
            }
        }
        
        protected void Log(string text, LogLevelType logLevel = LogLevelType.Info)
        {
            MessageBus.SendMessage(new LogMessage(this, text, logLevel));
        }
    }
}