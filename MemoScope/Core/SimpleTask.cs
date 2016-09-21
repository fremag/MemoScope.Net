using System;
using System.Threading.Tasks;

namespace MemoScope.Core
{
    public class SimpleTask
    {
        public Action Work { get; }
        public Action Callback { get; }
        public Action<Exception> OnError { get; }

        public TaskScheduler Scheduler { get; }

        public SimpleTask(Action work, Action callback) : this(work, callback,null, null)
        {
        }

        public SimpleTask(Action work) : this(work, null)
        {
        }

        public SimpleTask(Action work, Action callback, TaskScheduler sched)  : this(work, callback, null, sched)
        {
        }

        public SimpleTask(Action work, Action callback, Action<Exception> onError)  : this(work, callback, onError, null)
        {
        }

        public SimpleTask(Action work, Action callback, Action<Exception> onError, TaskScheduler sched)
        {
            Work = work;
            Callback = callback;
            Scheduler = sched;
            OnError = onError;
        }
    }
}