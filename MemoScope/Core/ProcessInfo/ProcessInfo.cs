using System;
using System.ComponentModel;
using System.Globalization;
using System.Xml.Serialization;

namespace MemoScope.Core.ProcessInfo
{
    public class ProcessInfo
    {
        public string MachineName { get; set; } = "Unknown";
        public string UserName { get; set; } = "Unknown";

        public string CommandLine { get; set; } = "Unknown";

        public long VirtualMemory { get; set; } = -1;
        public long PeakVirtualMemory { get; set; } = -1;

        public long PagedMemory { get; set; } = -1;
        public long PeakPagedMemory { get; set; } = -1;

        public long PeakWorkingSet { get; set; } = -1;
        public long WorkingSet { get; set; } = -1;

        public long PrivateMemory { get; set; } = -1;
        public long HandleCount { get; set; } = -1;

        [XmlIgnore]
        public TimeSpan TotalProcessorTime { get; set; }
        [Browsable(false)]
        public string TotalProcessorTimeStr {
            get
            {
                return TotalProcessorTime.ToString();
            }
            set
            {
                TotalProcessorTime = TimeSpan.Parse(value);
            }
        }
        [XmlIgnore]
        public DateTime StartTime { get; set; }
        [Browsable(false)]
        public string StartTimeStr
        {
            get
            {
                return StartTime.ToString("yyyy/MM/dd HH:mm:ss");
            }
            set
            {
                if (value != null)
                {
                    StartTime = DateTime.ParseExact(value, "yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture);
                }
            }
        }
        [XmlIgnore]
        public DateTime DumpTime { get; set; }
        [Browsable(false)]
        public string DumpTimeStr
        {
            get
            {
                return DumpTime.ToString("yyyy/MM/dd HH:mm:ss");
            }
            set
            {
                if (value != null)
                {
                    DumpTime = DateTime.ParseExact(value, "yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture);
                }
            }
        }
        [XmlIgnore]
        public TimeSpan UserProcessorTime { get; set; }
        [Browsable(false)]
        public string UserProcessorTimeStr
        {
            get
            {
                return UserProcessorTime.ToString();
            }
            set
            {
                UserProcessorTime = TimeSpan.Parse(value);
            }
        }

        public ProcessInfo()
        {
        }

        public ProcessInfo(System.Diagnostics.Process process)
        {
            MachineName = Environment.MachineName;
            UserName = Environment.UserName;
            CommandLine = process.StartInfo.Arguments;
            VirtualMemory = process.VirtualMemorySize64;
            PeakVirtualMemory = process.PeakVirtualMemorySize64;
            PagedMemory = process.PagedMemorySize64;
            PeakPagedMemory = process.PeakPagedMemorySize64;
            PeakWorkingSet = process.PeakWorkingSet64;
            WorkingSet = process.WorkingSet64;
            PrivateMemory = process.PrivateMemorySize64;
            HandleCount = process.HandleCount;
            TotalProcessorTime = process.TotalProcessorTime;
            StartTime = process.StartTime;
            DumpTime = DateTime.Now;
            UserProcessorTime = process.UserProcessorTime;
        }
    }
}
