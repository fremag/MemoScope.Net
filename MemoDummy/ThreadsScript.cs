using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;

namespace MemoDummy
{
    public class ThreadsScript : AbstractMemoScript
    {
        public override string Name => "Threads";
        public override string Description => "Create N threads";

        [Category("Config")]
        public int N { get; set; } = 8;

        public override void Run()
        {
            for(int i=0; i < N; i++)
            {
                Thread t = new Thread(() => DoSomething(i));
                t.Name = $"Thread #{i}";
                t.Start();
                switch(i%8)
                {
                    case 0:
                        t.Abort();
                        break;
                    case 1:
                        t.DisableComObjectEagerCleanup();
                        break;
                    case 2:
                        t.IsBackground = true;
                        break;
                    case 3:
                        t.Interrupt();
                        break;
                    case 4:
                        t.Priority = ThreadPriority.AboveNormal;
                        break;
                    case 5:
                        t.Priority = ThreadPriority.BelowNormal;
                        break;
                    case 6:
                        t.Priority = ThreadPriority.Highest;
                        break;
                    case 7:
                        t.Priority = ThreadPriority.Lowest;
                        break;
                }
            }
        }

        private void DoSomething(int n)
        {
            while(true)
            {
                try { Thread.Sleep(100); } catch { }
                long j = 0;
                for (int i = 0; i < 1000; i++)
                {
                    j = Syracuse(j);
                    if( j < 0)
                    {
                        throw new Exception();
                    }
                }
            }
        }

        private long Syracuse(long j)
        {
            if( j % 2 == 0)
            {
                return j / 2;
            }
            return 3 * j + 1;
        }
    }
}
