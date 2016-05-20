using BrightIdeasSoftware;
using MemoScope.Core.Data;
using WinFwk.UITools;

namespace MemoScope.Modules.RootPath
{
    public class RootPathInformation : ITypeNameData, IAddressData
    {
        [AddressColumn]
        public ulong Address => ClrDumpObject.Address;

        [OLVColumn]
        public string TypeName => ClrDumpObject.TypeName;

        [OLVColumn]
        public string FieldName { get; }

        ClrDumpObject ClrDumpObject { get; }
        public RootPathInformation(ClrDumpObject clrDumpObject, string fieldName)
        {
            ClrDumpObject = clrDumpObject;
            FieldName = fieldName;
        }
    }
}
