using System;

namespace MemoScope.Core.Data
{
    public class ArrayElementsAddressContainer : IAddressContainer
    {
        ClrDumpObject clrDumpObject;
        private ClrObject clrObject;
        public ArrayElementsAddressContainer(ClrDumpObject clrDumpObject)
        {
            this.clrDumpObject = clrDumpObject;
            if (!clrDumpObject.ClrType.IsArray)
            {
                throw new ArgumentException($"{clrDumpObject.TypeName} is not an array !");
            }
            clrObject = new ClrObject(clrDumpObject.Address, clrDumpObject.ClrType, clrDumpObject.IsInterior);
            Count = clrDumpObject.ArrayLength;
        }

        public ulong this[int index]
        {
            get
            {
                var obj = clrObject[index];
                return obj.Address;
            }
        }
        public int Count { get; }
    }
}
