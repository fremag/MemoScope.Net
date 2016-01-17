using MemoScope.Core;
using Microsoft.Diagnostics.Runtime;
using System.Collections.Generic;
using MemoScope.Core.Data;
using BrightIdeasSoftware;
using System.Windows.Forms;

namespace MemoScope.Modules.Finalizer
{
    public class FinalizerInformation
    {
        public AddressList AddressList { get; }

        public FinalizerInformation(ClrDump clrDump, ClrType type, List<ulong> addresses)
        {
            AddressList = new AddressList(clrDump, type, addresses);
        }

        [OLVColumn]
        public string TypeName => AddressList.ClrType.Name;

        [OLVColumn(TextAlign = HorizontalAlignment.Right, AspectToStringFormat ="{0:###,###,###,##0}")]
        public int Count => AddressList.Addresses.Count;
    }
}