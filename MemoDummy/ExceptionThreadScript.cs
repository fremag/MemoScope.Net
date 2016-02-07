using System.ComponentModel;
using System.Threading;
using System;
using System.Diagnostics;

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
                Thread thread = new Thread(() =>
                {
                    int[] arrayInt = new int[5];
                    try
                    {
                        int x = arrayInt[arrayInt.Length];
                        if( x < 0)
                        {
                            Debug.WriteLine("Huh ?");
                        }
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Something failed !", e);
                    }
                });
                thread.Name = "thread #" + i;
                thread.Start();
            }
        }
    }
}
