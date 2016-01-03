using System;
using System.Drawing;

namespace MemoDummy
{
    enum Flags { _True_, _False_, _FileNotFound_ }

    struct StructData
    {
        public Flags myFlags;
    }

    class InternalData
    {
        public string Desc;
        public bool IsNeg;
        public double X { get; set; }
        public double Y { get; set; }
    }

    internal class ComplexObject
    {
        static private int n = 0;
        int id;
        string Desc { get; }

        internal StructData StructData => structData;

        double value;
        InternalData data;
        bool isEven;
        DateTime date;
        TimeSpan time;
        StructData structData;
        Color color;
        public string[] SomeStrings { get; set; }
        int[] someInts;
        double[] someDoubles;

        public ComplexObject()
        {
            id = n++;
            Desc = "#" + id;
            data = new InternalData { X = 2 * id, Y = 3 * id * (isEven ? 1 : -1), IsNeg = ! isEven, Desc = (id %3==0 ? null: "_"+Desc+"_") };
            structData = new StructData();
            switch (id % 3)
            {
                case 0:
                    structData.myFlags = Flags._False_;
                    break;
                case 1:
                    structData.myFlags = Flags._True_;
                    break;
                default:
                    structData.myFlags = Flags._FileNotFound_;
                    break;
            }
            var r = id % 255;
            var g = (id + 1) % 255;
            var b = (id + 2) % 255;
            color = Color.FromArgb(r, g, b);
            isEven = (id % 2 == 0);
            value = 4 * id;
            date = new DateTime(2015, 12, 18).AddDays(id);
            time = TimeSpan.Zero.Add(TimeSpan.FromSeconds(id));
            SomeStrings = new string[id];
            someInts = new int[id];
            someDoubles = new double[id];
            for(int i=0; i < id % 32; i++)
            {
                int n = (id + i);
                SomeStrings[i] = n.ToString("X");
                someInts[i] = n;
                someDoubles[i] = 2 * (n + i);
            }
        }

    }
}