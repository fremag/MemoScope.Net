using MemoScope.Core.Data;
using BrightIdeasSoftware;
using System.Windows.Forms;
using WinFwk.UITools;

namespace MemoScope.Modules.Arrays
{
    public class ArraysInformation : ITypeNameData
    {
        public ClrDumpType ClrDumpType { get; }
        public ArraysInformation(ClrDumpType  arrayType)
        {
            ClrDumpType = arrayType;
            TypeName = arrayType.ClrType.Name;
        }

        public ArraysInformation(ClrDumpType arrayType, ulong nbInstances, ulong totalLength, ulong maxLength, ulong totalSize) : this(arrayType)
        {
            NbInstances = nbInstances;
            TotalLength = totalLength;
            MaxLength = maxLength;
            TotalSize = totalSize;
        }

        [OLVColumn]
        public string TypeName { get; }
        [IntColumn]
        public ulong NbInstances { get; }
        [IntColumn]
        public ulong TotalLength { get; }
        [IntColumn]
        public ulong MaxLength { get; }
        [IntColumn]
        public ulong TotalSize { get; }
    }
}