using System.Collections;
using System.Collections.Generic;

namespace WinFwk.UITools
{
    public abstract class DefaultModel<T> : IEnumerable where T : class
    {
        private readonly List<T> items = new List<T>();
        public IEnumerator GetEnumerator()
        {
            return items.GetEnumerator();
        }

        public void Add(T item)
        {
            items.Add(item);
        }

        public void AddRange(IEnumerable<T> newItems)
        {
            items.AddRange(newItems);
            items.TrimExcess();
        }

        public T GetObject(object o)
        {
            return o as T;
        }
    }
}