using System;
using System.Windows.Forms.DataVisualization.Charting;

namespace MemoScope.Modules.Process
{
    public class ProcessInfoValue
    {
        public string Name { get; private set; } 
        public string Alias{ get; private set; } 
        public string GroupName { get; private set; }
        public string Format { get; }
        public Func<ProcessWrapper, object> ValueGetter { get; }
        public Series Series { get; set; }
        public object Value { get; private set; }

        public ProcessInfoValue(string name, string alias, string groupName, Func<ProcessWrapper, object> valueGetter, string format)
        {
            Name = name;
            Alias = alias;
            GroupName = groupName;
            ValueGetter = valueGetter;
            Format = format;
        }

        public object GetValue(ProcessWrapper proc)
        {
            try
            {
                var o = ValueGetter(proc);
                Value = o;
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
}