using MemoScope.Core;
using MemoScope.Core.Data;
using Microsoft.Diagnostics.Runtime;
using System;
using System.Collections.Generic;

namespace MemoScope.Modules.Instances
{
    public class FieldAccessor
    {
        public ClrDump ClrDump { get; }
        public ClrType ClrType { get; }
        public ulong Address { get; set; }

        public FieldAccessor(ClrDump clrDump, ClrType clrType)
        {
            ClrDump = clrDump;
            ClrType = clrType;
        }
        string lastArg = null;
        List<ClrInstanceField> lastFields;

        Dictionary<string, List<ClrInstanceField>> cacheField = new Dictionary<string, List<ClrInstanceField>>();
        private object Eval(string arg)
        {
            List<ClrInstanceField> fields;
            if (ReferenceEquals(arg, lastArg))
            {
                fields = lastFields;
            }
            else {
                if (!cacheField.TryGetValue(arg, out fields))
                {
                    fields = new List<ClrInstanceField>();
                    ClrType type = ClrType;
                    foreach (var fieldName in arg.Split('.'))
                    {
                        var field = type.GetFieldByName(fieldName);
                        if (field == null)
                        {
                            var propName = ClrObject.GetAutomaticPropertyField(fieldName);
                            field = type.GetFieldByName(propName);
                        }
                        type = field.Type;
                        fields.Add(field);
                    }
                    cacheField[arg] = fields;
                }
                lastFields = fields;
                lastArg = arg;
            }
            var value = ClrDump.GetFieldValueImpl(Address, ClrType, fields);
            return value;
        }

        internal static string GetFuncName(ClrElementType elementType)
        {
            switch(elementType)
            {
                case ClrElementType.Boolean:
                    return nameof(_bool);
                case ClrElementType.Double:
                    return nameof(_double);
                case ClrElementType.Float:
                    return nameof(_float);
                case ClrElementType.Char:
                    return nameof(_char);
                case ClrElementType.Int16:
                    return nameof(_short);
                case ClrElementType.Int32:
                    return nameof(_int);
                case ClrElementType.Int64:
                    return nameof(_long);
                case ClrElementType.Int8:
                    return nameof(_byte);
                case ClrElementType.String:
                    return nameof(_string);
                case ClrElementType.UInt16:
                    return nameof(_ushort);
                case ClrElementType.UInt32:
                    return nameof(_uint);
                case ClrElementType.UInt64:
                    return nameof(_ulong);
                default:
                    return "Unknown";
            }
        }

        public char _char(string arg)
        {
            return (char)Eval(arg);
        }

        public short _short(string arg)
        {
            return (short)Eval(arg);
        }

        public ushort _ushort(string arg)
        {
            return (ushort)Eval(arg);
        }
        public double _double(string arg)
        {
            var val = Eval(arg);
            if (val != null)
            {
                return (double)val;
            }
            return double.NaN;
        }
        public bool _bool(string arg)
        {
            return (bool)Eval(arg);
        }
        public int _int(string arg)
        {
            return (int)Eval(arg);
        }
        public long _long(string arg)
        {
            return (long)Eval(arg);
        }
        public string _string(string arg)
        {
            return (string)Eval(arg);
        }
        public float _float(string arg)
        {
            return (float)Eval(arg);
        }
        public byte _byte(string arg)
        {
            return (byte)Eval(arg);
        }
        public uint _uint(string arg)
        {
            return (uint)Eval(arg);
        }
        public ulong _ulong(string arg)
        {
            return (ulong)Eval(arg);
        }
        public DateTime _datetime(string arg)
        {
            return (DateTime)Eval(arg);
        }
        public decimal _decimal(string arg)
        {
            return (decimal)Eval(arg);
        }
        public override string ToString()
        {
            var obj = ClrDump.GetSimpleValue(Address, ClrType);
            return obj != null ? obj.ToString() : string.Empty;
        }
    }
}