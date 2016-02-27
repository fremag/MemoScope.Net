using MemoScope.Core;
using MemoScope.Core.Data;
using Microsoft.Diagnostics.Runtime;
using BrightIdeasSoftware;
using System.Windows.Forms;
using WinFwk.UITools;

namespace MemoScope.Modules.ArrayInstances
{
    public class ArrayInstanceInformation : IAddressData
    {
        public ArrayInstanceInformation(ClrDump clrDump, ClrType clrType, ulong address, int length, float nullRatio, float uniqueRatio)
        {
            Address = address;
            Length = length;
            NullRatio = nullRatio;
            UniqueRatio = uniqueRatio;
        }

        [OLVColumn]
        public ulong Address { get; }
        [IntColumn]
        public int Length { get; }
        [OLVColumn(TextAlign = HorizontalAlignment.Right, AspectToStringFormat = "{0:p2}")]
        public float NullRatio { get; }
        [OLVColumn(TextAlign = HorizontalAlignment.Right, AspectToStringFormat = "{0:p2}")]
        public float UniqueRatio { get; }
    }
}