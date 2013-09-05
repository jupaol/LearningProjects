using Microsoft.Practices.ServiceLocation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using slf4net;

namespace NLogNinjectSlf
{
    [TestClass]
    public class SlfNLogAutofacTests
    {
        [TestMethod]
        public void it_should_log_a_simple_message_using_SLF_NLog_and_Autofac()
        {
            AutofacInitialization.Initialize();

            var logger = ServiceLocator.Current.GetInstance<ILogger>();

            logger.Debug("Resolved from AutoFac using SLF and NLog as the backend logger");
        }
    }
}
