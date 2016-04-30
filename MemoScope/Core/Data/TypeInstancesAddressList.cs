using Microsoft.Diagnostics.Runtime;

namespace MemoScope.Core.Data
{
    public class TypeInstancesAddressList : AddressList
    {
        public TypeInstancesAddressList(ClrDumpType clrDumpType) : this(clrDumpType.ClrDump, clrDumpType.ClrType)
        {

        }

        public TypeInstancesAddressList(ClrDump clrDump, ClrType clrType) : base(clrDump, clrType)
        {
        }
        public TypeInstancesAddressList(ClrDump clrDump, string typeName) : this(clrDump, clrDump.GetClrType(typeName))
        {
        }

        public void Init()
        {
            Init(new TypeAddressContainer(ClrDump, ClrType));
        }
    }

    public class TypeAddressContainer : IAddressContainer
    {
        private ClrDump clrDump;
        private ClrType clrType;

        AddressContainerList addressList;

        public TypeAddressContainer(ClrDump clrDump, ClrType clrType)
        {
            this.clrDump = clrDump;
            this.clrType = clrType;
            addressList = new AddressContainerList(clrDump.GetInstances(clrType));
        }

        public ulong this[int index] => addressList[index] ;
        public int Count => addressList.Count;
    }
}