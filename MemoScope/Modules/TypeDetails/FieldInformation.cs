using Microsoft.Diagnostics.Runtime;
using BrightIdeasSoftware;
using MemoScope.Core.Helpers;
using MemoScope.Core.Data;
using WinFwk.UITools;

namespace MemoScope.Modules.TypeDetails
{
    public class FieldInformation : ITypeNameData
    {
        private ClrInstanceField clrField;
        private ClrDumpType dumpType;

        public FieldInformation(ClrDumpType dumpType, ClrInstanceField clrField) 
        {
            this.dumpType = dumpType;
            this.clrField = clrField;
        }

        [OLVColumn(Title = "Name", Width = 150)]
        public string Name => clrField.RealName();

        [OLVColumn(Title = "Type", Width = 150)]
        public string TypeName => clrField.Type.Name;

        [IntColumn(Title = "Size", Width = 50)]
        public int Size => clrField.Size;

        [OLVColumn(Title = "Elem. Type", Width = 50)]
        public ClrElementType ElementType => clrField.ElementType;

        [OLVColumn(Title = "IsInternal", Width = 70)]
        public bool IsInternal => clrField.IsInternal;
        [OLVColumn(Title = "IsPrivate", Width = 70)]
        public bool IsPrivate => clrField.IsPrivate;
        [OLVColumn(Title = "IsProtected", Width = 70)]
        public bool IsProtected => clrField.IsProtected;
        [OLVColumn(Title = "IsPublic", Width = 70)]
        public bool IsPublic => clrField.IsPublic;

        public ClrType ClrType => clrField.Type;
    }
}
