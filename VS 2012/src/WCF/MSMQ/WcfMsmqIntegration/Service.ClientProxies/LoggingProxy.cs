using System.ServiceModel;
using Service.ServiceContracts;

namespace Service.ClientProxies
{
    public class LoggingProxy
    {
        public ILoggingService GetLoggingProxy()
        {
            //var proxy = new ChannelFactory<ILoggingService>(new NetTcpBinding(), "net.tcp://localhost:8002");
            var proxy = new ChannelFactory<ILoggingService>("Service.ServiceContracts.LoggingService");

            return proxy.CreateChannel();
        }
    }
}
