using System;

namespace EventBrokerTests
{
    public interface IEventBroker : IDisposable, IPublish, ISubscribe
    {
    }
}