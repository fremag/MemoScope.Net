using System.Collections.Generic;
using BrightIdeasSoftware;
using WinFwk.UITools;
using MemoScope.Core.Data;

namespace MemoScope.Modules.TypeDetails
{
    public abstract class AbstractTypeInformation : ITreeNodeInformation<AbstractTypeInformation>, ITypeNameData
    {
        public abstract bool CanExpand { get; }
        public abstract List<AbstractTypeInformation> Children { get; }

        [OLVColumn(Title = "Type", FillsFreeSpace = true)]
        public string TypeName { get; protected set; }
    }
}
