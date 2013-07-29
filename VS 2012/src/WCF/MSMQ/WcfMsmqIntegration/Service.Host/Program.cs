using System;
using System.ServiceModel;
using Service.ServiceImplementations;

namespace Service.Host
{
    class Program
    {
        static void Main()
        {
            var serviceHost = new ServiceHost(typeof (LoggingService), new Uri("net.tcp://localhost:8002"));

            serviceHost.Open();

            Console.WriteLine("Service running. Press 'Enter' to exit...");
            Console.ReadLine();
        }
    }
}
