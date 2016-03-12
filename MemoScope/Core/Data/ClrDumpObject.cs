using Microsoft.Diagnostics.Runtime;

namespace MemoScope.Core.Data
{
    public class ClrDumpObject : ClrDumpType
    {
        public ulong Address { get; }
        public object Value => ClrDump.Eval(GetValue);
        public bool IsInterior { get; private set; }
        public int ArrayLength => ClrDump.Eval( () => ClrType.GetArrayLength(Address));

        public ClrObject ClrObject => new ClrObject(Address, ClrType, IsInterior);

        private object GetValue()
        {
            var clrObject = new ClrObject(Address, ClrType, IsInterior);
            if (clrObject.HasSimpleValue && ! clrObject.IsNull)
            {
                return clrObject.SimpleValue;
            }
            else
            {
                return null;
            }

        }
        public ClrDumpObject(ClrDump dump, ClrType type, ulong address, bool isInterior=false) : base(dump, type)
        {
            Address = address;
            IsInterior = isInterior;
        }

        public ClrDumpObject(ClrDumpType clrDumpType, ulong address) : this(clrDumpType.ClrDump, clrDumpType.ClrType, address)
        {
        }
    }
}
