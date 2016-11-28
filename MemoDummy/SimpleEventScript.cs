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
        [Description("Nb instances that are only referenced by an event/delegate")]
        public int M  { get; set; } = 10;

        private List<object> objects;

        public override void Run()
        {
            objects = new List<object>();
            for(int i=0; i < N; i++)
            {
                var obj = new ClassWithEventHandlers();
                var firstCallBack = new FirstCallBacks();
                var secondCallBack = new SecondCallBacks();
                obj.FirstEventHandler += firstCallBack.MyFirstCallBack;
                obj.SecondEventHandler += secondCallBack.MySecondCallBack;
                if (i >= M)
                {
                    objects.Add(firstCallBack);
                }
                objects.Add(secondCallBack);
                objects.Add(obj);
            }
        }
    }

    public class FirstCallBacks
    {
        public int MyFirstCallBack(int x, int y)
        {
            throw new NotImplementedException();
        }
    }

    public class SecondCallBacks
    {
        public void MySecondCallBack(string s)
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
