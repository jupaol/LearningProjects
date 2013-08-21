using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EventBrokerTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var broker = new EventBroker();

            broker.Locally().Subscribe(new MyEventHandler());

            broker.Publish(new MyEvent {Message = "my message"});
        }
    }
}
