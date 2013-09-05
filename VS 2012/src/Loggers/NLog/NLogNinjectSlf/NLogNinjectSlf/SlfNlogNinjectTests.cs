using Microsoft.Practices.ServiceLocation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLogNinjectSlf.Services;

namespace NLogNinjectSlf
{
    [TestClass]
    public class SlfNlogNinjectTests
    {
        [TestMethod]
        public void it_should_write_a_simple_log_message_suing_NLog_SLF_and_Ninject()
        {
            NinjectInitialize.Initialize();

            var myService = ServiceLocator.Current.GetInstance<IMyService>();

            myService.DoSomething();
        }
    }
}
