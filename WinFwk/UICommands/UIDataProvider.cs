namespace WinFwk.UICommands
{
    public interface UIDataProvider<out T>
    {
        T Data { get; }
    }
}
