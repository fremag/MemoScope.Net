using System;
using System.Drawing;

namespace MemoDummy
{
    enum Flags { _True_, _False_, _FileNotFound_ }

    struct StructData
    {
        public Flags myFlags;
    }

    public interface IMyInterface
    {
        int Id { get; }
        double MyDoubleValue { get; }
    }

    public class MyInterfaceImpl_V1 : IMyInterface
    {
        private static int n = 0;
        protected int backfield_id;
        public int Id {
            get {
                return backfield_id;
            }
        }
        public double MyDoubleValue { get; set; }
        public string name;
        public MyInterfaceImpl_V1()
        {
            backfield_id = n++;
            MyDoubleValue = backfield_id + 0.001;
            name = $"#{0:Id}";
        }
    }

    public class MyInterfaceImpl_V2 : MyInterfaceImpl_V1
    {
        public DateTime TimeStamp { get; set; }
        public MyInterfaceImpl_V2()
        {
            backfield_id *= -1;
            MyDoubleValue = backfield_id - 0.001;
            TimeStamp = DateTime.Now;
        }
    }

    class InternalData
    {
        public string Desc;
        public bool IsNeg;
        public double X { get; set; }
        public double Y { get; set; }
    }
    public abstract class AnAbstractType 
    {
        public abstract double AbstractDoubleProperty { get; }
        public double MyDoubleProperty { get; set; }
    }

    public class AnAbstractTypeImpl : AnAbstractType
    {
        private static int n = 0;
        public new double MyDoubleProperty { get; }
        public override double AbstractDoubleProperty { get; }

        public AnAbstractTypeImpl()
        {
            n++;
            AbstractDoubleProperty = -n - 0.0005;
            base.MyDoubleProperty = n + 0.0005;
            this.MyDoubleProperty = n + 0.0006;
        }
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
        IMyInterface myInterface;
        AnAbstractType aFieldWithAbstractType;
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
            SomeStrings = new string[id%32];
            someInts = new int[id % 32];
            someDoubles = new double[id % 32];
            for(int i=0; i < id % 32; i++)
            {
                int n = (id + i);
                SomeStrings[i] = n.ToString("X");
                someInts[i] = n;
                someDoubles[i] = 2 * (n + i);
            }
            myInterface = id % 2 == 0 ? new MyInterfaceImpl_V1() : new MyInterfaceImpl_V2();
            aFieldWithAbstractType = new AnAbstractTypeImpl();
        }
    }
}