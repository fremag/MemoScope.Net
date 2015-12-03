using System.Collections.Generic;
using System.Linq;
using MemoScope.Core.Dac;
using Microsoft.Diagnostics.Runtime;
using System;
using WinFwk.UITools.Log;
using WinFwk.UIMessages;
using WinFwk.UIModules;
using System.Threading;

namespace MemoScope.Core
{
    public class ClrDump
    {
        private static int n = 0;
        public int Id { get; }
        private ClrRuntime Runtime { get; set; }
        private DataTarget Target { get; }
        public string DumpPath { get; }
        private ClrHeap Heap => Runtime.GetHeap();
        private MessageBus MessageBus { get; }

        private readonly SingleThreadWorker worker;

        public ClrDump(DataTarget target, string dumpPath, MessageBus msgBus)
        {
            Id = n++;
            Target = target;
            DumpPath = dumpPath;
            MessageBus = msgBus;
            worker = new SingleThreadWorker(dumpPath);
            worker.Run(InitRuntime);
        }

        private void InitRuntime()
        {
            MessageBus.Log(this, "InitRuntime: " + DumpPath);
            using (var locator = DacFinderFactory.CreateDactFinder("DacSymbols"))
            {
                var clrVersion = Target.ClrVersions[0];
                var dacFile = locator.FindDac(clrVersion);
                Runtime = clrVersion.CreateRuntime(dacFile);
            }
        }

        public List<ClrType> GetTypes()
        {
            List<ClrType> t = worker.Eval( () => t = Heap.EnumerateTypes().ToList());
            return t;
        }

        public List<ClrTypeStats> GetTypeStats()
        {
            var stats = worker.Eval(GetTypeStatsImpl);
            return stats;
        }

        private List<ClrTypeStats> GetTypeStatsImpl()
        {
            MessageBus.Log(this, "GetTypeStatsImpl: " + DumpPath);
            MessageBus.Status("GetTypeStatsImpl: " + DumpPath, StatusType.BeginTask);
            int n = 0;
            Dictionary<ClrType, ClrTypeStats> stats = new Dictionary<ClrType, ClrTypeStats>();
            foreach (var address in Heap.EnumerateObjectAddresses())
            {
                ClrType type = Heap.GetObjectType(address);
                if (type == null)
                {
                    continue;
                }
                ulong size = type.GetSize(address);

                ClrTypeStats stat;
                if (!stats.TryGetValue(type, out stat))
                {
                    stat = new ClrTypeStats(type);
                    stats[type] = stat;
                }
                stat.Inc(size);
                n++;
                if (n % 1024 == 0)
                {
                    MessageBus.Status($"Computing stats: n={n:###,###,###,##0}");
                }
            }
            MessageBus.Log(this, "Type stats computed: " + DumpPath);
            MessageBus.Status("Type stats computed: " + DumpPath, StatusType.EndTask);
            return stats.Values.ToList();
        }

        public T Eval<T>(Func<T> func)
        {
            return worker.Eval(func);
        }
    }
}