using MemoScope.Core.Data;
using Microsoft.Diagnostics.Runtime;
using System.ComponentModel;

namespace MemoScope.Modules.TypeDetails
{
    internal class TypeInformations
    {
        private ClrDumpType dumpType;

        public TypeInformations(ClrDumpType dumpType)
        {
            this.dumpType = dumpType;
        }
        const string CAT_MAIN = "1- Main";
        const string CAT_FLAGS = "2- Flags";
        const string CAT_ARRAY = "3- Arrays";

        [Category(CAT_MAIN)]
        [DisplayName("_ Name _")]
        public string Name => Type.Name;
        [Browsable(false)]
        public ClrType Type => dumpType.ClrType;
        [Category(CAT_MAIN)]
        public int BaseSize => Type.BaseSize;
        [Category(CAT_MAIN)]
        public string BaseType => dumpType.BaseTypeName;
        [Category(CAT_MAIN)]
        public bool ContainsPointers => Type.ContainsPointers;
        [Category(CAT_MAIN)]
        public string Module => Type.Module.FileName;

        [Category(CAT_ARRAY)]
        public int ElementSize => Type.ElementSize;
        [Category(CAT_ARRAY)]
        public ClrElementType ElementType => dumpType.ElementType;
        [Category(CAT_ARRAY)]
        public bool IsArray => Type.IsArray;
        [Category(CAT_ARRAY)]
        public string ComponentType => Type.ComponentType?.Name;

        [Category(CAT_FLAGS)]
        public bool IsAbstract => dumpType.IsAbstract;
        [Category(CAT_FLAGS)]
        public bool IsEnum => Type.IsEnum;
        [Category(CAT_FLAGS)]
        public bool IsException => Type.IsException;
        [Category(CAT_FLAGS)]
        public bool IsFinalizable => dumpType.IsFinalizable;
        [Category(CAT_FLAGS)]
        public bool IsFree => Type.IsFree;
        [Category(CAT_FLAGS)]
        public bool IsInterface => Type.IsInterface;
        [Category(CAT_FLAGS)]
        public bool IsInternal => Type.IsInternal;
        [Category(CAT_FLAGS)]
        public bool IsObjectReference => Type.IsObjectReference;
        [Category(CAT_FLAGS)]
        public bool IsPointer => Type.IsPointer;
        [Category(CAT_FLAGS)]
        public bool IsPrimitive => Type.IsPrimitive;
        [Category(CAT_FLAGS)]
        public bool IsPrivate => Type.IsPrivate;
        [Category(CAT_FLAGS)]
        public bool IsProtected => Type.IsProtected;
        [Category(CAT_FLAGS)]
        public bool IsPublic => Type.IsPublic;
        [Category(CAT_FLAGS)]
        public bool IsRuntimeType => Type.IsRuntimeType;
        [Category(CAT_FLAGS)]
        public bool IsSealed => Type.IsSealed;
        [Category(CAT_FLAGS)]
        public bool IsString => Type.IsString;
        [Category(CAT_FLAGS)]
        public bool IsValueClass => Type.IsValueClass;
    }
}