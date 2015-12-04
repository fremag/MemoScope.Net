using MemoScope.Core;
using Microsoft.Diagnostics.Runtime;
using System.Collections.Generic;

namespace MemoScope.Modules.TypeDetails
{
    public class ClrDumpType
    {
        public ClrDump ClrDump {get;}
        public ClrType ClrType { get; }
        public bool IsAbstract => ClrDump.Eval(() => ClrType.IsAbstract);
        public bool IsFinalizable => ClrDump.Eval(() => ClrType.IsFinalizable);
        public string BaseTypeName => ClrDump.Eval(() => ClrType.BaseType.Name);

        public IList<ClrInstanceField> Fields => ClrDump.Eval(() => ClrType.Fields);
        public IList<ClrMethod> Methods => ClrDump.Eval(() => ClrType.Methods);

        public ClrElementType ElementType => ClrDump.Eval(() => ClrType.ElementType);

        public ClrDumpType(ClrDump clrDump, ClrType clrType)
        {
            ClrDump = clrDump;
            ClrType = clrType;
        }
    }
}