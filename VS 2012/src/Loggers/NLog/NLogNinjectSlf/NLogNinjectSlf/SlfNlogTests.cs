using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NLogNinjectSlf
{
    [TestClass]
    public class SlfNlogTests
    {
        [TestMethod]
        public void it_should_write_a_simple_log_using_SLF_and_NLog()
        {
            var logger = slf4net.LoggerFactory.GetLogger(typeof (SlfNlogTests));

            logger.Debug("Debugging from SLF");
        }
    }
}
