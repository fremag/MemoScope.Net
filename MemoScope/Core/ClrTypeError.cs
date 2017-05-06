using Microsoft.Diagnostics.Runtime;
using System;
using System.Collections.Generic;

namespace MemoScope.Core
{
    public class ClrTypeError : ClrType
    {
        public override ulong MethodTable => 0;
        public override uint MetadataToken => 0;
        public override string Name { get; }
        public override ClrHeap Heap => null;
        public override IList<ClrInterface> Interfaces => new List<ClrInterface>();
        public override bool IsFinalizable => false;
        public override bool IsPublic => false;
        public override bool IsPrivate => false;
        public override bool IsInternal => false;
        public override bool IsProtected => false;
        public override bool IsAbstract => false;
        public override bool IsSealed => false;
        public override bool IsInterface => false;
        public override ClrType BaseType => null;
        public override int ElementSize => 0;
        public override int BaseSize => 0;
        public override IEnumerable<ulong> EnumerateMethodTables() => new ulong[0];
        public override IList<ClrInstanceField> Fields => new List<ClrInstanceField>();

        public ClrTypeError(string typeName)
        {
            Name = $"Error({typeName})";
        }

        public override void EnumerateRefsOfObject(ulong objRef, Action<ulong, int> action)
        {
            return;
        }

        public override void EnumerateRefsOfObjectCarefully(ulong objRef, Action<ulong, int> action)
        {
            return;
        }

        public override ulong GetArrayElementAddress(ulong objRef, int index) => 0;
        public override object GetArrayElementValue(ulong objRef, int index) => null;
        public override int GetArrayLength(ulong objRef) => 0;
        public override ClrInstanceField GetFieldByName(string name) => null;

        public override bool GetFieldForOffset(int fieldOffset, bool inner, out ClrInstanceField childField, out int childFieldOffset)
        {
            childField = null;
            childFieldOffset = 0;
            return false;
        }

        public override ulong GetSize(ulong objRef) => 0;
        public override ClrStaticField GetStaticFieldByName(string name) => null;
    }
}
