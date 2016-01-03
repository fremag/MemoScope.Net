using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;

namespace MemoDummy
{
    public class ComplexObjectGeneratorScript : AbstractMemoScript
    {
        public override string Name => "Complex Object Generator";
        public override string Description => "Creates some complex objects, frequency, quantity etc can be configured";

        [Category("Config")]
        public long MaxObject { get; set; } = 10000000;

        [Category("Config")]
        [DisplayName(nameof(Period) + " (ms)")]
        public int Period { get; set; } = 1;

        [Category("Config")]
        public int BatchSize { get; set; } = 100;

        private List<ComplexObject> objects;

        public int NbObjects => objects?.Count ?? -1;

        public override void Run()
        {
            objects = new List<ComplexObject>();

            while (objects.Count < MaxObject && ! stopRequested)
            {
                for (int i = 0; i < BatchSize; i++)
                {
                    objects.Add(new ComplexObject());
                }
                Thread.Sleep(Period);
            }
        }
    }
}
