using MemoScope.Core;
using Microsoft.Diagnostics.Runtime;
using MemoScope.Core.Data;
using BrightIdeasSoftware;
using WinFwk.UITools;

namespace MemoScope.Modules.Delegates
{
    public class DelegateInformation : ITypeNameData
    {
        ClrDump ClrDump { get; }
        public ClrType ClrType { get; }

        public DelegateInformation(ClrDump clrDump, ClrType clrType)
        {
            ClrDump = clrDump;
            ClrType  = clrType;
            Count = ClrDump.CountInstances(ClrType);
            Targets = DelegatesAnalysis.CountTargets(ClrDump, ClrType);
        }

        [OLVColumn(Title="Type")]
        public string TypeName => ClrType.Name;

        [IntColumn(Title = "Count")]
        public int Count { get; }

        [IntColumn(Title = "Total Targets")]
        public long Targets { get; }
    }
}