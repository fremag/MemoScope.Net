using BrightIdeasSoftware;
using MemoScope.Core;
using MemoScope.Core.Helpers;
using Microsoft.Diagnostics.Runtime;
using System.Collections.Generic;
using System.Linq;

namespace MemoScope.Modules.Instances
{
    public class FieldNode
    {
        ClrInstanceField Field { get; }
        ClrDump ClrDump { get; }
        public FieldNode(ClrInstanceField field, ClrDump clrDump)
        {
            Field = field;
            ClrDump = clrDump;
        }

        [OLVColumn(Title = "Name", Width = 150)]
        public string Name => Field.RealName();

        [OLVColumn(Title = "Type", Width = 250)]
        public string TypeName => Field.Type.Name;


        public bool HasChildren => !Field.Type.IsPrimitive && ClrDump.Eval(() => Field.Type.Fields.Any());

        public List<FieldNode> Children
        {
            get
            {
                IList<ClrInstanceField> fields = ClrDump.Eval(() => Field.Type.Fields);
                var fieldNodes = fields.Select(field => new FieldNode(field, ClrDump));
                return fieldNodes.ToList();
            }
        }
    }
}
