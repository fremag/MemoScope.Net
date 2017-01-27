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
    public class FieldNode : TreeNodeInformationAdapter<FieldNode>, ITypeNameData
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

        public override bool CanExpand { get; set; }

        public override List<FieldNode> Children
        {
            get
            {
                var fieldInfos = ClrDump.GetFieldInfos(ClrType);
                var fieldNodes = fieldInfos.Select(fieldInfo => new FieldNode(fieldInfo.Name, fieldInfo.FieldType, ClrDump, this));
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
