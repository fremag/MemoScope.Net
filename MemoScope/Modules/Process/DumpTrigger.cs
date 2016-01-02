using BrightIdeasSoftware;

namespace MemoScope.Modules.Process
{
    public class DumpTrigger 
    {
        public bool Active { get; set; }

        [OLVColumn(Width = 150)]
        public string Name { get; set; }

        [OLVColumn(Width = 150, IsVisible = false)]
        public string Group { get; set; } = "Default";

        [OLVColumn(FillsFreeSpace = true)]
        public string Code { get; set; }

        public DumpTrigger Clone()
        {
            return (DumpTrigger) MemberwiseClone();
        }
    }
}