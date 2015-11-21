using System.Collections.Generic;
using System.Linq;
using MemoScope.Core.Dac;
using Microsoft.Diagnostics.Runtime;

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

        private readonly SingleThreadWorker worker;

        public ClrDump(DataTarget target, string dumpPath)
        {
            Id = n++;
            Target = target;
            DumpPath = dumpPath;
            worker = new SingleThreadWorker(dumpPath);
            worker.Run(InitRuntime);
        }

        private void InitRuntime()
        {
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
            }
            return stats.Values.ToList();
        }
    }
}