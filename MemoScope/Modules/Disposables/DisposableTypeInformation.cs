using MemoScope.Core.Data;
using BrightIdeasSoftware;
using WinFwk.UITools;
using Microsoft.Diagnostics.Runtime;

namespace MemoScope.Modules.Disposables
{
    public class DisposableTypeInformation : ITypeNameData
    {
        public DisposableTypeInformation(ClrType type, long nbInstances)
        {
            ClrType = type;
            TypeName = ClrType.Name;
            Count = nbInstances;
        }

        public ClrType ClrType { get; private set; }

        [OLVColumn]
        public string TypeName { get; }
        [IntColumn]
        public long Count { get; }
    }
}