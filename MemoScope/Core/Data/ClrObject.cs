using System;
using System.Net;
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
                    throw new ArgumentException(string.Format("Field '{0}' not found in Type '{1}'", fieldName, Type.Name));

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

        private ClrObject GetInnerObject(ulong pointer, ClrType type)
        {
            ulong fieldAddress;
            ClrType actualType = type;

            if (type.IsObjectReference)
            {
                Heap.ReadPointer(pointer, out fieldAddress);

                if (!type.IsSealed && fieldAddress != 0)
                    actualType = Heap.GetObjectType(fieldAddress);
            }
            else if (type.IsPrimitive)
            {
                // Unfortunately, ClrType.GetValue for primitives assumes that the value is boxed,
                // we decrement PointerSize because it will be added when calling ClrType.GetValue.
                // ClrMD should be updated in a future version to include ClrType.GetValue(int interior).
                fieldAddress = pointer - (ulong)Heap.PointerSize;
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
       
        #region SimpleValueHelper

        private static class SimpleValueHelper
        {
            private const string GuidTypeName = "System.Guid";
            private const string TimeSpanTypeName = "System.TimeSpan";
            private const string DateTimeTypeName = "System.DateTime";
            private const string IPAddressTypeName = "System.Net.IPAddress";

            public static bool IsSimpleValue(ClrType type)
            {
                if (type.IsPrimitive || type.IsString)
                    return true;

                switch (type.Name)
                {
                    case GuidTypeName:
                    case TimeSpanTypeName:
                    case DateTimeTypeName:
                    case IPAddressTypeName:
                        return true;
                }

                return false;
            }

            public static object GetSimpleValue(ClrObject obj)
            {
                if (obj.IsNull)
                    throw new NullReferenceException("ClrObject at is pointing to null address.");

                ClrType type = obj.Type;
                ClrHeap heap = type.Heap;
                if (type.IsEnum)
                {
                    var val = type.GetValue(obj.Address);
                    return type.GetEnumName(val);
                }

                if (type.IsPrimitive || type.IsString)
                    return type.GetValue(obj.Address);

                ulong address = obj.IsInterior ? obj.Address : obj.Address + (ulong)heap.PointerSize;

                switch (type.Name)
                {
                    case GuidTypeName:
                        {
                            byte[] buffer = ReadBuffer(heap, address, 16);
                            return new Guid(buffer);
                        }

                    case TimeSpanTypeName:
                        {
                            byte[] buffer = ReadBuffer(heap, address, 8);
                            long ticks = BitConverter.ToInt64(buffer, 0);
                            return new TimeSpan(ticks);
                        }

                    case DateTimeTypeName:
                        {
                            byte[] buffer = ReadBuffer(heap, address, 8);
                            ulong dateData = BitConverter.ToUInt64(buffer, 0);
                            return GetDateTime(dateData);
                        }

                    case IPAddressTypeName:
                        {
                            return GetIPAddress(obj);
                        }
                }

                throw new InvalidOperationException(string.Format("SimpleValue not available for type '{0}'", type.Name));
            }

            public static string GetSimpleValueString(ClrObject obj)
            {
                object value = obj.SimpleValue;

                if (value == null)
                    return "null";

                ClrType type = obj.Type;
                if (type != null && type.IsEnum)
                    return type.GetEnumName(value) ?? value.ToString();

                DateTime? dateTime = value as DateTime?;
                if (dateTime != null)
                    return GetDateTimeString(dateTime.Value);

                return value.ToString();
            }

            private static byte[] ReadBuffer(ClrHeap heap, ulong address, int length)
            {
                byte[] buffer = new byte[length];
                int byteRead = heap.ReadMemory(address, buffer, 0, buffer.Length);

                if (byteRead != length)
                    throw new InvalidOperationException(string.Format("Expected to read {0} bytes and actually read {1}", length, byteRead));

                return buffer;
            }

            private static DateTime GetDateTime(ulong dateData)
            {
                const ulong DateTimeTicksMask = 0x3FFFFFFFFFFFFFFF;
                const ulong DateTimeKindMask = 0xC000000000000000;
                const ulong KindUnspecified = 0x0000000000000000;
                const ulong KindUtc = 0x4000000000000000;

                long ticks = (long)(dateData & DateTimeTicksMask);
                ulong internalKind = dateData & DateTimeKindMask;

                switch (internalKind)
                {
                    case KindUnspecified:
                        return new DateTime(ticks, DateTimeKind.Unspecified);

                    case KindUtc:
                        return new DateTime(ticks, DateTimeKind.Utc);

                    default:
                        return new DateTime(ticks, DateTimeKind.Local);
                }
            }

            private static IPAddress GetIPAddress(ClrObject ipAddress)
            {
                const int AddressFamilyInterNetworkV6 = 23;
                const int IPv4AddressBytes = 4;
                const int IPv6AddressBytes = 16;
                const int NumberOfLabels = IPv6AddressBytes / 2;

                byte[] bytes;
                int family = (int)ipAddress["m_Family"].SimpleValue;

                if (family == AddressFamilyInterNetworkV6)
                {
                    bytes = new byte[IPv6AddressBytes];
                    int j = 0;

                    var numbers = ipAddress["m_Numbers"];

                    for (int i = 0; i < NumberOfLabels; i++)
                    {
                        ushort number = (ushort)numbers[i].SimpleValue;
                        bytes[j++] = (byte)((number >> 8) & 0xFF);
                        bytes[j++] = (byte)(number & 0xFF);
                    }
                }
                else
                {
                    long address = (long)ipAddress["m_Address"].SimpleValue;
                    bytes = new byte[IPv4AddressBytes];
                    bytes[0] = (byte)(address);
                    bytes[1] = (byte)(address >> 8);
                    bytes[2] = (byte)(address >> 16);
                    bytes[3] = (byte)(address >> 24);
                }

                return new IPAddress(bytes);
            }

            private static string GetDateTimeString(DateTime dateTime)
            {
                return dateTime.ToString(@"yyyy-MM-dd HH\:mm\:ss.FFFFFFF") + GetDateTimeKindString(dateTime.Kind);
            }

            private static string GetDateTimeKindString(DateTimeKind kind)
            {
                switch (kind)
                {
                    case DateTimeKind.Unspecified:
                        return " (Unspecified)";
                    case DateTimeKind.Utc:
                        return " (Utc)";
                    default:
                        return " (Local)";
                }
            }
        }

        #endregion
    }
}