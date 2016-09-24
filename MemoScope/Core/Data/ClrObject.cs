using System;
using Microsoft.Diagnostics.Runtime;

namespace MemoScope.Core.Data
{
    // This code was extracted from https://github.com/JeffCyr/ClrMD.Extensions
    // Thanks a lot to Jeff Cyr !
    // TODO: remove this code when ClrMd merges 'clrobject' branches into master and releases a new version.
    public struct ClrObject 
    {
        public ulong Address { get; }
        public ClrType Type { get; }
        public bool IsInterior { get; }

        public ClrHeap Heap => Type.Heap;
        public bool IsNull => Address == 0;

        public ClrObject this[string fieldName]
        {
            get
            {
                ClrInstanceField field = GetField(fieldName);

                if (field == null)
                    throw new ArgumentException($"Field '{fieldName}' not found in Type '{Type.Name}'");

                return this[field];
            }
        }

        public ClrObject this[ClrInstanceField field] => GetInnerObject(field.GetAddress(Address, IsInterior), field.Type);
        public ClrObject this[int arrayIndex] => GetInnerObject(Type.GetArrayElementAddress(Address, arrayIndex), Type.ComponentType);
        public bool HasSimpleValue => SimpleValueHelper.IsSimpleValue(Type); 
        public object SimpleValue => SimpleValueHelper.GetSimpleValue(this);

        public ClrObject(ulong address, ClrType type, bool isInterior = false)
        {
            Address = address;
            Type = type;
            IsInterior = isInterior;
        }

        public ClrInstanceField GetField(string fieldName)
        {
            ClrInstanceField field = null;
            string backingFieldName = GetAutomaticPropertyField(fieldName);

            if (field == null)
                field = Type.GetFieldByName(fieldName);

            if (field == null)
                field = Type.GetFieldByName(backingFieldName);

            return field;
        }

        public static string GetAutomaticPropertyField(string propertyName)
        {
            return "<" + propertyName + ">" + "k__BackingField";
        }

        public static ClrObject GetInnerObject(ulong pointer, ClrType type)
        {
            ulong fieldAddress;
            ClrType actualType = type;

            if (type.IsObjectReference)
            {
                type.Heap.ReadPointer(pointer, out fieldAddress);

                if (!type.IsSealed && fieldAddress != 0)
                    actualType = type.Heap.GetObjectType(fieldAddress);
            }
            else if (type.IsPrimitive)
            {
                // Unfortunately, ClrType.GetValue for primitives assumes that the value is boxed,
                // we decrement PointerSize because it will be added when calling ClrType.GetValue.
                // ClrMD should be updated in a future version to include ClrType.GetValue(int interior).
                fieldAddress = pointer - (ulong)type.Heap.PointerSize;
            }
            else if (type.IsValueClass)
            {
                fieldAddress = pointer;
            }
            else
            {
                throw new NotSupportedException(string.Format("Object type not supported '{0}'", type.Name));
            }

            return new ClrObject(fieldAddress, actualType, !type.IsObjectReference);
        }

        public override int GetHashCode()
        {
            return Address.GetHashCode();
        }

        public override bool Equals(object o)
        {
            if( o is ClrObject)
            {
                return Address == ((ClrObject)o).Address;
            }
            return false;
        }
    }
}