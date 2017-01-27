using BrightIdeasSoftware;
using WinFwk.UITools;
using MemoScope.Core.Data;

namespace MemoScope.Modules.TypeDetails
{
    public abstract class AbstractTypeInformation : TreeNodeInformationAdapter<AbstractTypeInformation>, ITypeNameData
    {
        [OLVColumn(Title = "Type", FillsFreeSpace = true)]
        public string TypeName { get; protected set; }
    }
}
