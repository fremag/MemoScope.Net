using System;
using System.Windows.Forms.DataVisualization.Charting;

namespace MemoScope.Modules.Process
{
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
}