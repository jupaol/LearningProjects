using System;

namespace EventBrokerTests
{
    public interface IEventConsumer<in TEvent> : IHandle<TEvent>
    {
        Func<TEvent, bool> Filters { get; }
    }
}