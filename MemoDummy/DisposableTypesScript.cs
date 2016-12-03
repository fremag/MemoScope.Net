using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace MemoDummy
{
    public class DisposableTypes : AbstractMemoScript
    {
        public override string Name => "Disposable Types";
        public override string Description => "Create instances of IDisposable type and don't call Dispose()";

        [Category("Config")]
        public int N { get; set; } = 300;

        private List<object> objects;

        public override void Run()
        {
            for(int i=0; i < N; i++)
            {
                MyDisposableType obj = new MyDisposableType();
            }

            System.GC.WaitForFullGCComplete();
        }
    }

    public class MyDisposableType : IDisposable
    {
        IntPtr hglobal = Marshal.AllocHGlobal(100000);


        public void Dispose()
        {
            Marshal.FreeHGlobal(hglobal);
        }
    }
}
