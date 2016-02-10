using MemoScope.Core.Data;
using BrightIdeasSoftware;
using System.Windows.Forms;

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
        [OLVColumn(AspectToStringFormat ="{0:###,###,###,##0}", Width = 150, TextAlign = HorizontalAlignment.Right )]
        public ulong NbInstances { get; }
        [OLVColumn(AspectToStringFormat = "{0:###,###,###,##0}", Width = 150, TextAlign = HorizontalAlignment.Right)]
        public ulong TotalLength { get; }
        [OLVColumn(AspectToStringFormat = "{0:###,###,###,##0}", Width = 150, TextAlign = HorizontalAlignment.Right)]
        public ulong MaxLength { get; }
        [OLVColumn(AspectToStringFormat = "{0:###,###,###,##0}", Width = 150, TextAlign = HorizontalAlignment.Right)]
        public ulong TotalSize { get; }
    }
}