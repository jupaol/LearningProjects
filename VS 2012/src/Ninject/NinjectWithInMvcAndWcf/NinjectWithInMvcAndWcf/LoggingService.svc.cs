using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Threading;
using NinjectShared;
using NinjectWithInMvcAndWcf.Services;

namespace NinjectWithInMvcAndWcf
{
    [ServiceBehavior(
        Namespace = Namespaces.MyNamespace,
        InstanceContextMode = InstanceContextMode.PerSession,
        ConcurrencyMode = ConcurrencyMode.Single)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class LoggingService : ILoggingService
    {
        private readonly IContextResolver _contextResolver;

        public LoggingService(IContextResolver contextResolver)
        {
            _contextResolver = contextResolver;
        }

        public string DoWork()
        {
            if (_contextResolver == null)
            {
                throw new ArgumentNullException("_contextResolver");
            }

            return DateTime.Now.ToString();
        }

        public string Call1()
        {
            Thread.Sleep(6000);

            return DateTime.Now.ToString();
        }

        public string Call2()
        {
            Thread.Sleep(2000);

            return DateTime.Now.ToString();
        }

        public string Call3()
        {
            Thread.Sleep(4000);

            return DateTime.Now.ToString();
        }
    }
}
