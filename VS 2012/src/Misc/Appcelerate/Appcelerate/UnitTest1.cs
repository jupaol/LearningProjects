using System;
using Appccelerate.EventBroker;
using Appccelerate.EventBroker.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Appcelerate
{
    public class Publisher
    {
        [EventPublication("de")]
        public event EventHandler SimpleEvent;

        public void FireSimpleEvent()
        {
            SimpleEvent(this, EventArgs.Empty);
        }
    }

    public class Subscriber
    {
        [EventSubscription(
            "de",
            typeof(OnPublisher))]

        public void SimpleEvent(object sender, EventArgs e)
        {
            // do something useful or at least funny
            Console.WriteLine("handled");
        }
    }



    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var eventBroker = new EventBroker();

            var publisher = new Publisher();
            eventBroker.Register(publisher);

            var subscriber = new Subscriber();
            eventBroker.Register(subscriber);

            publisher.FireSimpleEvent();
        }
    }
}
