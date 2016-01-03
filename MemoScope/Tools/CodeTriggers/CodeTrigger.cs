using BrightIdeasSoftware;

namespace MemoScope.Tools.CodeTriggers
{
    public class CodeTrigger 
    {
        public bool Active { get; set; }

        [OLVColumn(Width = 150)]
        public string Name { get; set; }

        [OLVColumn(Width = 150, IsVisible = false)]
        public string Group { get; set; } = "Default";

        [OLVColumn(FillsFreeSpace = true)]
        public string Code { get; set; }

        public CodeTrigger Clone()
        {
            return (CodeTrigger) MemberwiseClone();
        }
    }
}