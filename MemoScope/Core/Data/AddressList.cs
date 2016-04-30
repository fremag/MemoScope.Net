using Microsoft.Diagnostics.Runtime;
using System.Collections.Generic;

namespace MemoScope.Core.Data
{
    public class AddressList
    {
        public IAddressContainer Addresses { get; private set; }
        public ClrDump ClrDump { get; }
        public ClrType ClrType { get; }

        public AddressList(ClrDump clrDump, ClrType clrType, List<ulong> addresseList) : this(clrDump, clrType, new AddressContainerList(addresseList))
        {
        }
        public AddressList(ClrDump clrDump, ClrType clrType, IAddressContainer addresses) : this(clrDump, clrType)
        {
            Init(addresses);
        }

        protected void Init(IAddressContainer addresses)
        {
            Addresses = addresses;
        }

        public AddressList(ClrDump clrDump, ClrType clrType)
        {
            ClrDump = clrDump;
            ClrType = clrType;
        }
    }

    public interface IAddressContainer 
    {
        int Count { get; }
        ulong this[int index] { get; }
    }
}