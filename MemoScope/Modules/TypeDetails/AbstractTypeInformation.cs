using BrightIdeasSoftware;
using System.Collections.Generic;

namespace MemoScope.Modules.TypeDetails
{
    public abstract class AbstractTypeInformation
    {
        public abstract bool HasChildren { get; }
        public abstract IEnumerable<object> Children { get; }
        [OLVColumn(Title = "Name", FillsFreeSpace = true)]
        public string Name { get; protected set; }
    }
}
