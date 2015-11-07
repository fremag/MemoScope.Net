using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;

namespace MemoDummy
{
    public class ObjectGeneratorScript : AbstractMemoScript
    {
        public override string Name => "Object Generator";
        public override string Description => "Creates some objects, frequency, quantity etc can be configured";

        [Category("Config")]
        public long MaxObject { get; set; } = int.MaxValue;

        [Category("Config")]
        [DisplayName(nameof(Period) + " (ms)")]
        public int Period { get; set; } = 1;

        [Category("Config")]
        public int BatchSize { get; set; } = 100;

        private List<object> objects;

        public int NbObjects => objects?.Count ?? -1;

        public override void Run()
        {
            objects = new List<object>();

            while (objects.Count < MaxObject && ! stopRequested)
            {
                for (int i = 0; i < BatchSize; i++)
                {
                    objects.Add(new object());
                }
                Thread.Sleep(Period);
            }
        }
    }
}
