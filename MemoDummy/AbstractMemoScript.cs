using System.ComponentModel;

namespace MemoDummy
{
    public abstract class AbstractMemoScript
    {
        protected bool stopRequested;

        [Category("_ Info _")]
        [ReadOnly(true)]
        public abstract string Name { get; }
        [Category("_ Info _")]
        [ReadOnly(true)]
        public abstract string Description { get; }

        public abstract void Run();

        public override string ToString()
        {
            return Name;
        }

        public void Stop()
        {
            stopRequested = true;
        }
    }
}
