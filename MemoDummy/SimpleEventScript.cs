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
        public long N { get; set; } = 10;

        private List<object> objects;

        public override void Run()
        {
            objects = new List<object>();
            for(int i=0; i < N; i++)
            {
                var obj = new ClassWithEventHandlers();
                obj.FirstEventHandler += MyCallBack;
                objects.Add(obj);
            }
        }

        private void MyCallBack(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }

    public class ClassWithEventHandlers
    {
        public event EventHandler FirstEventHandler;
        public event EventHandler SecondEventHandler;

        public void InvokeFirstEventHandler()
        {
            if(FirstEventHandler != null) FirstEventHandler(this, EventArgs.Empty );
        }
        public void InvokeSecondEventHandler()
        {
            if (SecondEventHandler != null) SecondEventHandler(this, EventArgs.Empty);
        }
    }
}
