using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace EventBrokerTests
{
    public class EventBroker : IEventBroker
    {
        private readonly IScheduler _scheduler;
        private readonly ISubject<IEvent> _subject;

        public EventBroker()
        {
            _scheduler = new EventLoopScheduler();
            _subject = new Subject<IEvent>();
        }

        public IEventBroker Publish<TEvent>(TEvent @event)
            where TEvent : IEvent
        {
            _subject.OnNext(@event);
            return this;
        }

        public ISubscribe Locally()
        {
            return this;
        }

        public ISubscribe Subscribe<TEvent>(IEventConsumer<TEvent> eventConsumer)
            where TEvent : IEvent
        {
            ((ISubscribe)this).Subscribe(eventConsumer.Filters, eventConsumer.Handle);
            return this;
        }

        public ISubscribe Subscribe<TEvent>(Action<TEvent> onConsume)
            where TEvent : IEvent
        {
            ((ISubscribe)this).Subscribe(null, onConsume);
            return this;
        }

        public ISubscribe Subscribe<TEvent>(Func<TEvent, Boolean> filter,
                                                Action<TEvent> onConsume)
            where TEvent : IEvent
        {
            _subject.Where(o => o is TEvent).Cast<TEvent>()
                    .Where(filter ?? (x => true))
                    .ObserveOn(_scheduler)
                    .Subscribe(onConsume);
            return this;
        }

        public void Dispose()
        {
        }
    }
}