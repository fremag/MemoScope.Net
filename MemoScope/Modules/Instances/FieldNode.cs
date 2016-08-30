using BrightIdeasSoftware;
using MemoScope.Core;
using MemoScope.Core.Data;
using MemoScope.Core.Helpers;
using Microsoft.Diagnostics.Runtime;
using System.Collections.Generic;
using System.Linq;
using WinFwk.UITools;

namespace MemoScope.Modules.Instances
{
    public class FieldNode : ITreeNodeInformation<FieldNode>, ITypeNameData
    {
        public string FieldName { get; }
        public ClrDump ClrDump { get; }
        public ClrType ClrType { get; }
        public FieldNode Parent { get; }

        public FieldNode(string fieldName, ClrType clrType, ClrDump clrDump)
        {
            FieldName = fieldName;
            ClrDump = clrDump;
            this.ClrType = clrType;
            CanExpand = ClrDump.Eval(() => ClrDump.HasField(clrType));
        }
        public FieldNode(string fieldName, ClrType clrType, ClrDump clrDump, FieldNode parent) : this(fieldName, clrType, clrDump)
        {
            Parent = parent;
        }

        [OLVColumn(Title = "Name", Width = 150)]
        public string Name => TypeHelpers.RealName(FieldName);

        [OLVColumn(Title = "Type")]
        public string TypeName => ClrType.Name;

        public bool CanExpand { get; }

        public List<FieldNode> Children
        {
            get
            {
                var fieldTypesByName = ClrDump.GetFieldNames(ClrType);
                var fieldNodes = fieldTypesByName.Select(kvp => new FieldNode(kvp.Key, kvp.Value, ClrDump, this));
                return fieldNodes.ToList();
            }
        }

        public string FullName
        {
            get
            {
                string fullName = TypeHelpers.RealName(FieldName);
                if (Parent != null)
                {
                    string prefix = Parent.FullName + ".";
                    fullName = prefix + fullName;
                }
                return fullName;
            }
        }
    }
}
