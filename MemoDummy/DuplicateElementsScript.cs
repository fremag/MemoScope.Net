using System.Collections.Generic;
using System.ComponentModel;

namespace MemoDummy
{
    public class DuplicateElementsScript : AbstractMemoScript
    {
        public override string Name => "Generate arrays with duplicated elements";
        public override string Description => Name;

        [Category("Config")]
        public long Size { get; set; } = 1000;

        [Category("Config")]
        public int Count { get; set; } = 100;

        [Category("Config")]
        public int DuplicatePeriod { get; set; } = 4;

        private List<object> objects;

        public override void Run()
        {
            objects = new List<object>();

            for(int i=0; i< Count; i++)
            {
                if(stopRequested)
                {
                    break;
                }
                string[] stringArray = new string[Size];

                objects.Add(stringArray);

                for (int j = 0; j < Size; j++)
                {
                    stringArray[j] = $"#{i}_{j%DuplicatePeriod}";
                }
            }
        }
    }
}
