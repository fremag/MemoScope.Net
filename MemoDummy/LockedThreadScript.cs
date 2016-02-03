using System.ComponentModel;
using System.Threading;
namespace MemoDummy
{
    public class LockedThreadScript : AbstractMemoScript
    {
        public override string Name => "Locked Threads";
        public override string Description => "Creates some threads locking/waiting some objects";

        [Category("Config")]
        public long NbThreads { get; set; } = 4;

        string[] locks;
        public override void Run()
        {
            locks = new string[NbThreads];
            for (int i = 0; i < NbThreads; i++)
            {
                locks[i] = $"lock_{i}";
            }

            for (int i = 0; i < NbThreads; i++)
            {
                string myLock = locks[i];
                Thread thread = new Thread(() =>
                {
                    lock (myLock)
                    {
                        while (!stopRequested)
                        {
                            Thread.Sleep(100);
                        }
                    }
                });
                thread.Name = $"thread #{i} LOCK";
                thread.Start();
                Thread.Sleep(100);
                thread = new Thread(() =>
                {
                    lock (myLock)
                    {
                        while (!stopRequested)
                        {
                            Thread.Sleep(100);
                        }
                    }
                });
                thread.Name = $"thread #{i} WAIT";
                thread.Start();
            }
        }
    }
}
