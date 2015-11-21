using System;
using System.Threading.Tasks;

namespace MemoScope.Core
{
    public class SimpleTask
    {
        public Action Work { get; }
        public Action Callback { get; }
        public TaskScheduler Scheduler { get; }

        public SimpleTask(Action work, Action callback) : this(work, callback, null)
        {
        }

        public SimpleTask(Action work) : this(work, null)
        {
            
        }

        public SimpleTask(Action work, Action callback, TaskScheduler sched) 
        {
            Work = work;
            Callback = callback;
            Scheduler = sched;
        }
    }
}