namespace EventBrokerTests
{
    public interface ISubscriptionSource
    {
        ISubscribe Locally();
    }
}