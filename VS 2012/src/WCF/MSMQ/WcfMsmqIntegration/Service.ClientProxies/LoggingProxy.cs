using System.ServiceModel;
using Service.ServiceContracts;

namespace Service.ClientProxies
{
    public class LoggingProxy
    {
        public ILoggingService GetLoggingProxy(string endpointName)
        {
            //var proxy = new ChannelFactory<ILoggingService>(new NetTcpBinding(), "net.tcp://localhost:8002");
            var proxy = new ChannelFactory<ILoggingService>(endpointName);

            return proxy.CreateChannel();
        }
    }
}
