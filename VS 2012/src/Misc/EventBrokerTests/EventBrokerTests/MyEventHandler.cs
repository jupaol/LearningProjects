using System;

namespace EventBrokerTests
{
    public class MyEventHandler : EventConsumer<MyEvent>
    {
        public override void Handle(MyEvent message)
        {
            Console.WriteLine(message.Message);
        }
    }
}