using Microsoft.Diagnostics.Runtime;
using BrightIdeasSoftware;
using MemoScope.Core;

namespace MemoScope.Modules.TypeDetails
{
    public class FieldInformation
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
        public string Type => clrField.Type.Name;

        [OLVColumn(Title = "Elem. Type", Width = 50)]
        public ClrElementType ElementType => clrField.ElementType;

        [OLVColumn(Title = "Size", Width = 70)]
        public int Size => clrField.Size;

        [OLVColumn(Title = "IsInternal", Width = 70)]
        public bool IsInternal => clrField.IsInternal;
        [OLVColumn(Title = "IsPrivate", Width = 70)]
        public bool IsPrivate => clrField.IsPrivate;
        [OLVColumn(Title = "IsProtected", Width = 70)]
        public bool IsProtected => clrField.IsProtected;
        [OLVColumn(Title = "IsPublic", Width = 70)]
        public bool IsPublic => clrField.IsPublic;
    }
}
