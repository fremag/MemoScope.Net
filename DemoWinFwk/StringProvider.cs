using WinFwk.UICommands;

namespace DemoWinFwk
{
    public class StringProvider : UIDataProvider<string>
    {
        public StringProvider()
        {
            Data = "DataStr";
        }

        public string Data { get; }
    }
}