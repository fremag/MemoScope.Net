using BrightIdeasSoftware;
using Microsoft.Diagnostics.Runtime;
using MemoScope.Core.Data;
using WinFwk.UITools;

namespace MemoScope.Core
{
    public class ClrTypeStats : ITypeNameData
    {
        public int Id { get; }
        public ClrType Type { get; }
        public ulong MethodTable { get; }

        [OLVColumn(Title = "Type Name", Width = 500)]
        public string TypeName { get; }

        [IntColumn(Title = "Nb")]
        public long NbInstances { get; private set; }

        [IntColumn(Title = "Total Size")]
        public ulong TotalSize { get; private set; }

        public ClrTypeStats(int id, ClrType type)
        {
            Id = id;
            MethodTable = type.MethodTable;
            Type = type;
        }

        public ClrTypeStats(int id, ClrType type, long nbInstances, ulong totalSize) : this(id, type)
        {
            NbInstances = nbInstances;
            TotalSize= totalSize;
            TypeName = Type.Name;
        }

        public void Inc(ulong size)
        {
            TotalSize += size;
            NbInstances++;
        }
    }

}