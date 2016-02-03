using System.Threading;
namespace MemoDummy
{
    public class DeadLockedThreadScript : AbstractMemoScript
    {
        public override string Name => "Dead Locked Threads";
        public override string Description => "Creates two threads dead locked on the same objects";

        public override void Run()
        {
            string lockB = "Lock_A";
            string lockA = "Lock_B";
            Thread thread = new Thread(() =>
            {
                lock (lockA)
                {
                    Thread.Sleep(100);
                    lock (lockB)
                    {
                        while (!stopRequested)
                        {
                            Thread.Sleep(100);
                        }
                    }
                }
            });
            thread.Name = $"thread 1: locks A then B";
            thread.Start();

            thread = new Thread(() =>
            {
                lock (lockB)
                {
                    lock (lockA)
                    {
                        while (!stopRequested)
                        {
                            Thread.Sleep(100);
                        }
                    }
                }
            });
            thread.Name = $"thread 2: locks B then A";
            thread.Start();
        }
    }
}
