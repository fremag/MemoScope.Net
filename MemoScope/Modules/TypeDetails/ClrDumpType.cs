using BrightIdeasSoftware;
using MemoScope.Core;
using MemoScope.Core.Helpers;
using Microsoft.Diagnostics.Runtime;
using System.Collections.Generic;
using System.Linq;

namespace MemoScope.Modules.TypeDetails
{
    public class ClrDumpType 
    {
        public ClrDump ClrDump {get;}
        public ClrType ClrType { get; }
        public bool IsAbstract => ClrDump.Eval(() => ClrType.IsAbstract);
        public bool IsFinalizable => ClrDump.Eval(() => ClrType.IsFinalizable);
        public string BaseTypeName => ClrDump.Eval(() => ClrType.BaseType == null ? null : ClrType.BaseType.Name);

        public IList<ClrInstanceField> Fields => ClrDump.Eval(() => ClrType.Fields);
        public IList<ClrMethod> Methods => ClrDump.Eval(() => ClrType.Methods);

        public ClrElementType ElementType => ClrDump.Eval(() => ClrType.ElementType);
        
        public ClrDumpType BaseType => ClrDump.Eval(() => ClrType.BaseType == null ? null : new ClrDumpType(ClrDump, ClrType.BaseType));
        public List<InterfaceInformation> Interfaces => ClrDump.Eval(() => ClrType.Interfaces.Select(interf => new InterfaceInformation(ClrDump, interf)).ToList());

        public string Name => ClrDump.Eval(() => ClrType.Name);

        public ClrDumpType(ClrDump clrDump, ClrType clrType)
        {
            ClrDump = clrDump;
            ClrType = clrType;
        }
    }
}