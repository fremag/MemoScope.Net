using MemoScope.Core;
using MemoScope.Core.Data;
using Microsoft.Diagnostics.Runtime;
using BrightIdeasSoftware;
using System.Windows.Forms;

namespace MemoScope.Modules.ArrayInstances
{
    public class ArrayInstanceInformation : IAddressData
    {
        public ArrayInstanceInformation(ClrDump clrDump, ClrType clrType, ulong address, int length, float nullRatio)
        {
            Address = address;
            Length = length;
            NullRatio = nullRatio;
        }

        [OLVColumn]
        public ulong Address { get; }
        [OLVColumn(TextAlign = HorizontalAlignment.Right, AspectToStringFormat ="{0:###,###,###,##0}")]
        public int Length { get; }
        [OLVColumn(TextAlign = HorizontalAlignment.Right, AspectToStringFormat = "{0:p2}")]
        public float NullRatio { get; }
    }
}