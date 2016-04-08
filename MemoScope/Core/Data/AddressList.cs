using Microsoft.Diagnostics.Runtime;
using System.Collections.Generic;

namespace MemoScope.Core.Data
{
    public class AddressList
    {
        public IAddressContainer Addresses { get; }
        public ClrDump ClrDump { get; }
        public ClrType ClrType { get; }

        public AddressList(ClrDump clrDump, ClrType clrType, List<ulong> addresseList)
        {
            ClrDump = clrDump;
            ClrType = clrType;
            Addresses = new AddressContainerList(addresseList);
        }
        public AddressList(ClrDump clrDump, ClrType clrType, IAddressContainer addresses)
        {
            ClrDump = clrDump;
            ClrType = clrType;
            Addresses = addresses;
        }
    }

    public interface IAddressContainer 
    {
        int Count { get; }
        ulong this[int index] { get; }
    }
}