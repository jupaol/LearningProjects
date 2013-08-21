using System;

namespace EventBrokerTests
{
    public abstract class EventConsumer<TEvent> : IEventConsumer<TEvent>
        where TEvent : IEvent
    {
        public Func<TEvent, bool> Filters { get; private set; }

        protected void Register(Func<TEvent, Boolean> filter)
        {
            if (Filters == null)
                Filters = filter;
            else
                Filters += filter;
        }

        public abstract void Handle(TEvent message);
    }
}