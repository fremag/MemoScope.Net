namespace WinFwk.UIMessages
{
    public interface IMessageListener<in T>
    {
        void HandleMessage(T message);
    }
}