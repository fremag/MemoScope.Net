using System.Collections.Generic;
using BrightIdeasSoftware;
using MemoScope.Core.Data;
using MemoScope.Core.Helpers;
using Microsoft.Diagnostics.Runtime;
using WinFwk.UITools;

namespace MemoScope.Modules.InstanceDetails
{
    internal class FieldValueInformation : ITreeNodeInformation<FieldValueInformation>, IAddressData
    {
        private ClrDumpObject clrDumpObject;
        private string name;

        public FieldValueInformation(string name, ClrDumpObject clrDumpObject)
        {
            this.name = name;
            this.clrDumpObject = clrDumpObject;
        }

        [OLVColumn(Title = "Field name")]
        public string Name => name;

        [OLVColumn(Title = "Value")]
        public object Value => clrDumpObject.Value;

        [OLVColumn(Title = "Address", AspectToStringFormat = "{0:X}")]
        public ulong Address => clrDumpObject.Address;

        [OLVColumn(Title = "Type name")]
        public string TypeName => clrDumpObject.TypeName;

        public ClrType ClrType => clrDumpObject.ClrType;
        
        public bool CanExpand => ! clrDumpObject.IsPrimitiveOrString;
        public List<FieldValueInformation> Children => GetChildren(clrDumpObject);

        internal static List<FieldValueInformation> GetValues(ClrDumpObject clrDumpObject)
        {
            List<FieldValueInformation> values= clrDumpObject.ClrDump.Eval(() =>
            {
                var clrObject = new ClrObject(clrDumpObject.Address, clrDumpObject.ClrType, clrDumpObject.IsInterior);
                var l = new List<FieldValueInformation>();
                foreach (var field in clrDumpObject.ClrType.Fields)
                {
                    var fieldValue = clrObject[field];
                    var fieldValueInfo = new FieldValueInformation(field.RealName(), new ClrDumpObject(clrDumpObject.ClrDump, fieldValue.Type, fieldValue.Address, fieldValue.IsInterior));
                    l.Add(fieldValueInfo);
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
                var n = clrDumpObject.ClrType.GetArrayLength(clrDumpObject.Address);
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
            if( clrDumpObject.ClrType.IsArray)
            {
                var elems = GetElements(clrDumpObject);
                return elems;
            }
            var values = GetValues(clrDumpObject);
            return values;
        }
    }
}