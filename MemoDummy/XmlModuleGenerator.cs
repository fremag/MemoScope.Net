using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Xml.Serialization;

namespace MemoDummy
{
    public class XmlmoduleGeneratorScript : AbstractMemoScript
    {
        public override string Name => "Xmlmodule Generator";
        public override string Description => "Creates some xml serializers, frequency, quantity etc can be configured";

        [Category("Config")]
        public long Max { get; set; } = int.MaxValue;

        [Category("Config")]
        [DisplayName(nameof(Period) + " (ms)")]
        public int Period { get; set; } = 1;

        [Category("Config")]
        public int BatchSize { get; set; } = 100;

        private List<XmlSerializer> objects;

        public int NbObjects => objects?.Count ?? -1;

        public override void Run()
        {
            objects = new List<XmlSerializer>();

            while (objects.Count < Max && ! stopRequested)
            {
                for (int i = 0; i < BatchSize; i++)
                {
                    objects.Add(new XmlSerializer(typeof(object), new[] { typeof(List<int>), typeof(List<double>), typeof(List<float>)  } ));
                }
                Thread.Sleep(Period);
            }
        }
    }
}
