using MemoScope.Core;
using MemoScope.Core.Helpers;
using Microsoft.Diagnostics.Runtime;
using System.Collections.Generic;

namespace MemoScope.Modules.TypeDetails
{
    public class InterfaceInformation : AbstractTypeInformation
    {
        public ClrDump ClrDump { get; }
        public ClrInterface ClrInterface { get; }

        public override bool HasChildren
        {
            get
            {
                return ClrInterface.BaseInterface != null;
            }
        }

        public override IEnumerable<object> Children
        {
            get
            {
                var x = new InterfaceInformation(ClrDump, ClrInterface.BaseInterface);
                var l = new List<object>();
                l.Add(x);
                return l;
            }
        }

        public InterfaceInformation(ClrDump clrDump, ClrInterface interf)
        {
            Name = TypeHelpers.ManageAlias(interf.Name);
            ClrDump = clrDump;
            ClrInterface = interf;
        }
    }
}
