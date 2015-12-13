using System.Collections.Generic;
using System.Linq;
using MemoScope.Core.Dac;
using Microsoft.Diagnostics.Runtime;
using System;
using WinFwk.UITools.Log;
using WinFwk.UIMessages;
using WinFwk.UIModules;
using MemoScope.Core.Cache;

namespace MemoScope.Core
{
    public class ClrDump
    {
        private static int n = 0;
        public int Id { get; }
        public ClrRuntime Runtime { get; set; }
        public DataTarget Target { get; }
        public string DumpPath { get; }
        public ClrHeap Heap => Runtime.GetHeap();
        public MessageBus MessageBus { get; }

        private readonly SingleThreadWorker worker;
        private ClrDumpCache cache;

        public ClrDump(DataTarget target, string dumpPath, MessageBus msgBus)
        {
            Id = n++;
            Target = target;
            DumpPath = dumpPath;
            MessageBus = msgBus;
            worker = new SingleThreadWorker(dumpPath);
            worker.Run(InitRuntime);

            cache = new ClrDumpCache(this);
            cache.Init();
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
            var stats = cache.LoadTypeStat();
            return stats;
        }

        public ClrType GetType(ulong methodTable)
        {
            var type = Eval(() => Heap.GetTypeByMethodTable(methodTable));
            return type;
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

            cache.BeginUpdate();
            foreach(var stat in stats.Values)
            {
                cache.InsertTypeStat(stat);
            }
            cache.EndUpdate();

            return stats.Values.ToList();
        }

        public T Eval<T>(Func<T> func)
        {
            return worker.Eval(func);
        }
    }
}