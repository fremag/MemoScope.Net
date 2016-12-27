using System.ComponentModel;
using System.Threading;

namespace MemoDummy
{
    public class ThreadPoolScript : AbstractMemoScript
    {
        public override string Name => "ThreadPool";
        public override string Description => "Queue tasks to the ThreadPool ";

        [Category("Config")]
        public int MaxWorkerThreads { get; set; } = 4;
        [Category("Config")]
        public int MinWorkerThreads { get; set; } = 4;
        [Category("Config")]
        public int MinCompletionThreads { get; set; } = 4;
        [Category("Config")]
        public int MaxCompletionThreads { get; set; } = 4;
        [Category("Tasks")]
        public int NbTasks { get; set; } = 40;
        [Category("Tasks")]
        public int DurationInSeconds { get; set; } = 60;

        public override void Run()
        {
            ThreadPool.SetMaxThreads(MaxWorkerThreads, MaxCompletionThreads);
            ThreadPool.SetMinThreads(MinWorkerThreads, MinCompletionThreads);

            for (int i=0; i < NbTasks; i++)
            {
                ThreadPool.QueueUserWorkItem(CallBack, $"Task_{i}");
            }
        }

        private void CallBack(object state)
        {
            int j = 0;
            for(int i=0; i < 1000; i++)
            {
                j += i;
                Thread.Sleep(10);
            }
        }
    }
}
