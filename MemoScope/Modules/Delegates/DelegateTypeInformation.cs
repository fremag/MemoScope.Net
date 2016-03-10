using Microsoft.Diagnostics.Runtime;
using BrightIdeasSoftware;
using WinFwk.UITools;
using MemoScope.Core.Data;
using MemoScope.Core;

namespace MemoScope.Modules.Delegates
{
    public class DelegateTypeInformation : ITypeNameData
    {
        ClrDump ClrDump { get; }
        public ClrType ClrType { get; }

        public DelegateTypeInformation(ClrDump clrDump, ClrType clrType, int count, long targetCount)
        {
            ClrDump = clrDump;
            ClrType  = clrType;
            Count = count;
            Targets = targetCount;
        }

        [OLVColumn(Title="Type")]
        public string TypeName => ClrType.Name;

        [IntColumn(Title = "Count")]
        public int Count { get; }

        [IntColumn(Title = "Total Targets")]
        public long Targets { get; }
    }
}