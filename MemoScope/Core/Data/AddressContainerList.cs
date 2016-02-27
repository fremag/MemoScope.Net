using System.Collections.Generic;

namespace MemoScope.Core.Data
{
    internal class AddressContainerList : IAddressContainer
    {
        private List<ulong> addresses;

        public ulong this[int index] => addresses[index];
        public int Count => addresses.Count;

        public AddressContainerList(List<ulong> addresses)
        {
            this.addresses = addresses;
        }
    }
}