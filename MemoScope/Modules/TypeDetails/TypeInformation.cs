using MemoScope.Core.Data;
using MemoScope.Core.Helpers;
using System.Collections.Generic;

namespace MemoScope.Modules.TypeDetails
{
    public class TypeInformation : AbstractTypeInformation
    {
        private ClrDumpType ClrDumpType { get; }
        public TypeInformation(ClrDumpType clrDumpType)
        {
            ClrDumpType = clrDumpType;
            Name = TypeHelpers.ManageAlias(ClrDumpType.TypeName);
        }
        public override IEnumerable<object> Children
        {
            get
            {
                var baseType = new TypeInformation(ClrDumpType.BaseType);
                var interfs = ClrDumpType.Interfaces;
                var l = new List<object>();
                l.Add(baseType);
                l.AddRange(interfs);
                return l;
            }
        }

        public override bool HasChildren
        {
            get
            {
                bool baseTypeExists = ClrDumpType.BaseType != null;
                bool hasInterfaces = ClrDumpType.Interfaces.Count != 0;
                return baseTypeExists || hasInterfaces;
            }
        }
    }
}
