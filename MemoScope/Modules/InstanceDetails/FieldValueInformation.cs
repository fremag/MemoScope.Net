using System.Collections.Generic;
using BrightIdeasSoftware;
using MemoScope.Core.Data;
using MemoScope.Core.Helpers;
using Microsoft.Diagnostics.Runtime;
using WinFwk.UITools;
using System;
using ClrObject = MemoScope.Core.Data.ClrObject;

namespace MemoScope.Modules.InstanceDetails
{
    internal class FieldValueInformation : TreeNodeInformationAdapter<FieldValueInformation>, IAddressData, ITypeNameData
    {
        private ClrDumpObject clrDumpObject;
        private string name;

        public FieldValueInformation(string name, ClrDumpObject clrDumpObject)
        {
            this.name = name;
            this.clrDumpObject = clrDumpObject;
        }

        [OLVColumn(Title = "Field Name")]
        public string Name => name;

        [OLVColumn(Title = "Value")]
        public object Value => clrDumpObject.Value;

        [OLVColumn(Title = "Address")]
        public ulong Address => clrDumpObject.Address;

        [OLVColumn(Title = "Type")]
        public string TypeName => clrDumpObject.TypeName;

        public ClrType ClrType => clrDumpObject.ClrType;
        
        public override bool CanExpand => ! (clrDumpObject.IsPrimitiveOrString || clrDumpObject.Address == 0);
        public override List<FieldValueInformation> Children => GetChildren(clrDumpObject);

        internal static List<FieldValueInformation> GetValues(ClrDumpObject clrDumpObject)
        {
            List<FieldValueInformation> values= clrDumpObject.ClrDump.Eval(() =>
            {
                var clrObject = new ClrObject(clrDumpObject.Address, clrDumpObject.ClrType, clrDumpObject.IsInterior);
                var l = new List<FieldValueInformation>();
                if (clrDumpObject.ClrType != null)
                {
                    foreach (var field in clrDumpObject.ClrType.Fields)
                    {
                        var fieldValue = clrObject[field];
                        var fieldValueInfo = new FieldValueInformation(field.RealName(), new ClrDumpObject(clrDumpObject.ClrDump, fieldValue.Type, fieldValue.Address, fieldValue.IsInterior));
                        l.Add(fieldValueInfo);
                    }
                }
                return l;
            });
            return values;
        }

        internal static List<FieldValueInformation> GetElements(ClrDumpObject clrDumpObject)
        {
            List<FieldValueInformation> values = clrDumpObject.ClrDump.Eval(() =>
            {
                var clrObject = new ClrObject(clrDumpObject.Address, clrDumpObject.ClrType, clrDumpObject.IsInterior);
                var l = new List<FieldValueInformation>();
                int length = clrDumpObject.ClrType.GetArrayLength(clrDumpObject.Address);
                var n = Math.Min(length, 1024);
                for (int i=0; i < n; i++)
                {
                    var fieldValue = clrObject[i];
                    var fieldValueInfo = new FieldValueInformation($"[{i}]", new ClrDumpObject(clrDumpObject.ClrDump, fieldValue.Type, fieldValue.Address, fieldValue.IsInterior));
                    l.Add(fieldValueInfo);
                }
                return l;
            });
            return values;
        }

        public static List<FieldValueInformation> GetChildren(ClrDumpObject clrDumpObject)
        {
            if(clrDumpObject.ClrType != null && clrDumpObject.ClrType.IsArray)
            {
                var elems = GetElements(clrDumpObject);
                return elems;
            }
            var values = GetValues(clrDumpObject);
            return values;
        }
    }
}