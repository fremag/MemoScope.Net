using System.ComponentModel;
using System.Threading;
using System;
namespace MemoDummy
{
    public class ExceptionThreadScript : AbstractMemoScript
    {
        public override string Name => "Exception Threads";
        public override string Description => "Creates some threads throwing exceptions";

        [Category("Config")]
        public long NbThreads { get; set; } = 4;

        public override void Run()
        {
            for(int i=0; i < NbThreads; i++)
            {
                Thread thread = new Thread(() => { throw new IndexOutOfRangeException(); });
                thread.Name = "thread #" + i;
                thread.Start();
            }
        }
    }
}
