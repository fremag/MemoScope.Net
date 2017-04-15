using System;
using System.ComponentModel;
using System.Threading;

namespace MemoDummy
{
    public class GarbageCollectorStressScript : AbstractMemoScript
    {
        public override string Name => "Garbage collecor stress";
        public override string Description => "Creates many object to force GC to happen often";

        [Category("Config")]
        public long GCCallPeriodInMs { get; set; } = 100;

        [Category("Info")]
        public int GCCount0 => GC.CollectionCount(0);

        [Category("Info")]
        public int GCCount1 => GC.CollectionCount(1);

        [Category("Info")]
        public int GCCount2 => GC.CollectionCount(2);

        [Category("Info")]
        public long NbObjects => nbObjects;

        const int N = 1024;

        private object[] objects = new object[N];
        Timer timer;
        long nbObjects=0;
        public override void Run()
        {
            timer = new Timer(RunGC);
            timer.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(GCCallPeriodInMs));
            Random r = new Random();
            while(! stopRequested)
            {
                int idx = r.Next(N);
                nbObjects++;
                objects[idx] = new object[r.Next(N)];
            }
            timer.Dispose();
        }


        private void RunGC(object state)
        {
            GC.Collect();
        }
    }
}
