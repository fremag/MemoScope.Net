using MemoScope.Core.Cache;
using MemoScope.Core.ProcessInfo;
using System;
using System.Collections.Generic;
using System.IO;

namespace MemoScope.Modules.Explorer
{
    public class FileData : AbstractDumpExplorerData
    {
        public override FileInfo FileInfo { get; }
        ProcessInfo processInfo;
        public FileData(FileInfo fileInfo)
        {
            FileInfo = fileInfo;
            Name = fileInfo.Name;
            Icon = Properties.Resources.file_extension_bin;
            var clrDumpInfo = ClrDumpInfo.Load(fileInfo.FullName);
            processInfo = clrDumpInfo.ProcessInfo;
        }

        public override long Size => FileInfo.Length / 1000000;
        public override bool CanExpand => false;
        public override List<AbstractDumpExplorerData> Children => null;
        public override string GetCachePath()
        {
            var cachePath = ClrDumpCache.GetCachePath(FileInfo.FullName);
            return cachePath;
        }

        public override long? HandleCount => processInfo?.HandleCount;
        public override string CommandLine => processInfo?.CommandLine;
        public override DateTime? DumpTime 
        {
            get
            {
                if(processInfo == null || processInfo.DumpTime == DateTime.MinValue)
                {
                    return null;
                }
                return processInfo.StartTime;
            }
        }

        public override string MachineName => processInfo?.MachineName;
        public override long? PagedMemory => processInfo?.PagedMemory / 1000000;
        public override long? PeakPagedMemory => processInfo?.PeakPagedMemory / 1000000;
        public override long? PeakVirtualMemory => processInfo?.PeakVirtualMemory / 1000000;
        public override long? PeakWorkingSet => processInfo?.PeakWorkingSet / 1000000;
        public override long? PrivateMemory => processInfo?.PrivateMemory / 1000000;
        public override DateTime? StartTime
        {
            get
            {
                if(processInfo == null || processInfo.StartTime == DateTime.MinValue)
                {
                    return null;
                }
                return processInfo.StartTime;
            }
        }

        public override TimeSpan? TotalProcessorTime
        {
            get
            {
                if(processInfo == null || processInfo.TotalProcessorTime == TimeSpan.Zero)
                {
                    return null;
                }
                return processInfo.TotalProcessorTime;
            }
        }

        public override string UserName => processInfo?.UserName;
        public override TimeSpan? UserProcessorTime
        {
            get
            {
                if (processInfo == null || processInfo.UserProcessorTime == TimeSpan.Zero )
                {
                    return null;
                }
                return processInfo.UserProcessorTime;
            }
        }
        
        public override long? VirtualMemory => processInfo?.VirtualMemory / 1000000;
        public override long? WorkingSet => processInfo?.WorkingSet / 1000000;
    }
}