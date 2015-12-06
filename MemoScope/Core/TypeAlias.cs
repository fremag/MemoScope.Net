namespace MemoScope.Core
{
    public class TypeAlias
    {
        public bool Active { get; set; } = true;
        public string OldTypeName { get; set; }
        public string NewTypeName { get; set; }
        public override int GetHashCode()
        {
            return (OldTypeName == null ? 0 : OldTypeName.GetHashCode()) + 37 * (NewTypeName == null ? 0 : NewTypeName.GetHashCode());
        }
        public override bool Equals(object o)
        {
            var other = o as TypeAlias;
            if (other == null)
            {
                return false;
            }
            bool b1 = other.NewTypeName == NewTypeName;
            bool b2 = other.OldTypeName == OldTypeName;
            return b1 && b2;
        }
        public override string ToString()
        {
            return "["+(Active ? "+": "-")+"] "+ OldTypeName + " => " + NewTypeName;
        }
    }
}
