namespace WinFwk.MessageBus
{
    public interface IMessageListener<in T>
    {
        void HandleMessage(T message);
    }
}