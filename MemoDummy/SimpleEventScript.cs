using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MemoDummy
{
    public class SimpleEventScript : AbstractMemoScript
    {
        public override string Name => "Simple Event";
        public override string Description => "Create instances with one subscriber";

        [Category("Config")]
        public long N { get; set; } = 300;

        private List<object> objects;

        public override void Run()
        {
            objects = new List<object>();
            for(int i=0; i < N; i++)
            {
                var obj = new ClassWithEventHandlers();
                obj.FirstEventHandler += MyFirstCallBack;
                obj.SecondEventHandler += MySecondCallBack;
                objects.Add(obj);
            }
        }

        private void MySecondCallBack(string s)
        {
            throw new NotImplementedException();
        }

        private int MyFirstCallBack(int x, int y)
        {
            throw new NotImplementedException();
        }
    }

    public class ClassWithEventHandlers
    {
        public delegate int MyIntDelegate(int x, int y);
        public delegate void MyVoidDelegate(string s);

        public event MyIntDelegate FirstEventHandler;
        public event MyVoidDelegate SecondEventHandler;

        public void InvokeFirstEventHandler()
        {
            if(FirstEventHandler != null) FirstEventHandler(0,1 );
        }
        public void InvokeSecondEventHandler()
        {
            if (SecondEventHandler != null) SecondEventHandler(string.Empty);
        }
    }
}
