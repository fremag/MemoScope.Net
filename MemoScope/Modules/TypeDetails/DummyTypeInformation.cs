using System.Collections.Generic;
using Microsoft.Diagnostics.Runtime;

namespace MemoScope.Modules.TypeDetails
{
    public class DummyTypeInformation : AbstractTypeInformation
    {
        private ClrInterface interf;

        public DummyTypeInformation(ClrInterface interf)
        {
            this.interf = interf;
            Name = interf.Name;
        }

        public override bool CanExpand => false;
        public override List<AbstractTypeInformation> Children => null;
    }
}