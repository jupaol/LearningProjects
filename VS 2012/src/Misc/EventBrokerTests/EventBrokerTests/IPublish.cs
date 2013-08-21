namespace EventBrokerTests
{
    public interface IPublish
    {
        IEventBroker Publish<TEvent>(TEvent @event)
            where TEvent : IEvent;
    }
}