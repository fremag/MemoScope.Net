using System.Collections.Generic;

namespace MemoDummy
{
    public class TypeHierarchyScript : AbstractMemoScript
    {
        public override string Name => "Type Hierarchy";
        public override string Description => "Creates some type to study hierarchy";

        private List<object> objects;

        public override void Run()
        {
            objects = new List<object>();
            objects.Add(new FirstTestClass());
            objects.Add(new SecondTestClass());
        }
    }

    public abstract class MyAbstractClass
    {
        public string Name { get; }
        public abstract void Init();
    }

    public class FirstTestClass : MyAbstractClass, MySecondInterface
    {
        public int Id { get; private set; }
        public override void Init()
        {
        }
    }
    public class SecondTestClass : FirstTestClass, AnotherInterface
    {
        public string Description { get; protected set; }
        public void DoSomething()
        {
        }
    }
    public interface MyFirstInterface
    {

    }
    public interface MySecondInterface : MyFirstInterface
    {

    }
    public interface AnotherInterface
    {

    }
}
