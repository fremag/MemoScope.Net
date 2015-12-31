using System.Collections.Generic;
using BrightIdeasSoftware;
using WinFwk.UITools;

namespace MemoScope.Modules.TypeDetails
{
    public abstract class AbstractTypeInformation : ITreeNodeInformation<AbstractTypeInformation>
    {
        public abstract bool CanExpand { get; }
        public abstract List<AbstractTypeInformation> Children { get; }

        [OLVColumn(Title = "Name", FillsFreeSpace = true)]
        public string Name { get; protected set; }
    }
}
