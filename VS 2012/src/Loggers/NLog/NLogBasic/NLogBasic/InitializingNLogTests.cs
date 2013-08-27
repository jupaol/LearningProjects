using FluentAssertions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;

namespace NLogBasic
{
    [TestClass]
    public class InitializingNLogTests
    {
        [TestMethod]
        public void it_should_log_a_simple_message_to_the_console()
        {
            var logger = LogManager.GetCurrentClassLogger();

            logger.IsDebugEnabled.Should().BeTrue();

            if (logger.IsDebugEnabled)
            {
                logger.Debug("My debug message");
            }
        }

        [TestMethod]
        public void it_should_inject_a_logger_using_ninject_automatically_and_log_to_the_console()
        {
            NinjectInitializer.Initialize();

            var myComponent = ServiceLocator.Current.GetInstance<IMyComponent>();

            myComponent.DoSomething();
        }
    }
}
