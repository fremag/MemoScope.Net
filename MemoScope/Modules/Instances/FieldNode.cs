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
        public ClrInstanceField Field { get; }
        public ClrDump ClrDump { get; }
        public FieldNode Parent { get; }

        public FieldNode(ClrInstanceField field, ClrDump clrDump)
        {
            Field = field;
            ClrDump = clrDump;
            CanExpand = !Field.Type.IsPrimitive && ClrDump.Eval(() => Field.Type.Fields.Any());
        }
        public FieldNode(ClrInstanceField field, ClrDump clrDump, FieldNode parent) : this(field, clrDump)
        {
            Parent = parent;
        }

        [OLVColumn(Title = "Name", Width = 150)]
        public string Name => Field.RealName();

        [OLVColumn(Title = "Type")]
        public string TypeName => Field.Type.Name;

        public ClrType ClrType => Field.Type;

        public bool CanExpand { get; }

        public List<FieldNode> Children
        {
            get
            {
                IList<ClrInstanceField> fields = ClrDump.Eval(() => Field.Type.Fields);
                var fieldNodes = fields.Select(field => new FieldNode(field, ClrDump, this));
                return fieldNodes.ToList();
            }
        }

        public string FullName
        {
            get
            {
                string fullName = Field.RealName(null);
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
