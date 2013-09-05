using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;

namespace NLogNinjectSlf
{
    [TestClass]
    public class SimpleNlogTests
    {
        [TestMethod]
        public void it_should_write_a_simple_log()
        {
            var logger = LogManager.GetCurrentClassLogger();

            logger.Debug("Debugging...");
        }
    }
}
