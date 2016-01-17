using Microsoft.Diagnostics.Runtime;
using System.Collections.Generic;

namespace MemoScope.Core.Data
{
    public class AddressList
    {
        public List<ulong> Addresses { get; }
        public ClrDump ClrDump { get; }
        public ClrType ClrType { get; }

        public AddressList(ClrDump clrDump, ClrType clrType)
        {
            ClrDump = clrDump;
            ClrType = clrType;
            Addresses = ClrDump.GetInstances(clrType);
        }
        public AddressList(ClrDump clrDump, ClrType clrType, List<ulong> addresses)
        {
            ClrDump = clrDump;
            ClrType = clrType;
            Addresses = addresses;
        }
    }
}