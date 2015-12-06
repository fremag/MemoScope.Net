using System.Windows.Forms;
using BrightIdeasSoftware;
using Microsoft.Diagnostics.Runtime;

namespace MemoScope.Core
{
    public class ClrTypeStats
    {
        public ClrType Type { get; }

        [OLVColumn(Name = "Type Name", Width = 500)]
        public string TypeName => Type != null ? TypeHelpers.ManageAlias(Type.Name, MemoScopeSettings.Instance.TypeAliases) : "???";

        [OLVColumn(Title = "Nb", AspectToStringFormat = "{0:###,###,###,##0}", TextAlign = HorizontalAlignment.Right)]
        public long NbInstances { get; private set; }

        [OLVColumn(Name = "Total Size", AspectToStringFormat = "{0:###,###,###,##0}", TextAlign = HorizontalAlignment.Right)]
        public ulong TotalSize { get; private set; }

        public ClrTypeStats(ClrType type)
        {
            Type = type;
        }

        public void Inc(ulong size)
        {
            TotalSize += size;
            NbInstances++;
        }
    }
}