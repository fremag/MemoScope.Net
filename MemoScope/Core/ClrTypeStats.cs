using System.Windows.Forms;
using BrightIdeasSoftware;
using Microsoft.Diagnostics.Runtime;
using MemoScope.Core.Helpers;

namespace MemoScope.Core
{
    public class ClrTypeStats
    {
        public ClrType Type { get; }
        public ulong MethodTable { get; }

        [OLVColumn(Title = "Type Name", Width = 500)]
        public string TypeName => TypeHelpers.ManageAlias(Type);

        [OLVColumn(Title = "Nb", AspectToStringFormat = "{0:###,###,###,##0}", TextAlign = HorizontalAlignment.Right)]
        public long NbInstances { get; private set; }

        [OLVColumn(Title = "Total Size", AspectToStringFormat = "{0:###,###,###,##0}", TextAlign = HorizontalAlignment.Right)]
        public ulong TotalSize { get; private set; }

        public ClrTypeStats(ClrType type)
        {
            MethodTable = type.MethodTable;
            Type = type;
        }

        public ClrTypeStats(ClrType type, long nbInstances, ulong totalSize) : this(type)
        {
            NbInstances = nbInstances;
            TotalSize= totalSize;
        }

        public void Inc(ulong size)
        {
            TotalSize += size;
            NbInstances++;
        }
    }
}