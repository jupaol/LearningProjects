namespace EventBrokerTests
{
    public interface IHandle<in T>
    {
        void Handle(T instance);
    }
}