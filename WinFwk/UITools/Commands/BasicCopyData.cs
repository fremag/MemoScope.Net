namespace WinFwk.UITools.Commands
{
    public class BasicCopyData : ICopyData
    {
        public string Title { get; }
        public string Data { get; }

        public BasicCopyData(string data)
        {
            Data = data;
        }
    }
}
