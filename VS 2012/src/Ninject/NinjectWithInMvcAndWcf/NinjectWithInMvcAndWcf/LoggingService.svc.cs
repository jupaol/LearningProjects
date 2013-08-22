using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Threading;
using NinjectShared;
using NinjectWithInMvcAndWcf.Data;
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
        private readonly MyDataContext _myDataContext;

        public LoggingService(IContextResolver contextResolver, MyDataContext myDataContext)
        {
            _contextResolver = contextResolver;
            _myDataContext = myDataContext;
        }

        public string DoWork()
        {
            if (_contextResolver == null)
            {
                throw new ArgumentNullException("_contextResolver");
            }

            if (_myDataContext == null)
            {
                throw new ArgumentNullException("_myDataContext");
            }

            return string.Format("At: {0} - Context Hash: {1} - Service Hash: {2}", DateTime.Now.ToString(), _myDataContext.GetHashCode(), this.GetHashCode());
        }

        public string Call1()
        {
            Thread.Sleep(6000);

            return string.Format("At: {0} - Context Hash: {1} - Service Hash: {2}", DateTime.Now.ToString(), _myDataContext.GetHashCode(), this.GetHashCode());
        }

        public string Call2()
        {
            Thread.Sleep(2000);

            return string.Format("At: {0} - Context Hash: {1} - Service Hash: {2}", DateTime.Now.ToString(), _myDataContext.GetHashCode(), this.GetHashCode());
        }

        public string Call3()
        {
            Thread.Sleep(4000);
            
            return string.Format("At: {0} - Context Hash: {1} - Service Hash: {2}", DateTime.Now.ToString(), _myDataContext.GetHashCode(), this.GetHashCode());
        }
    }
}
