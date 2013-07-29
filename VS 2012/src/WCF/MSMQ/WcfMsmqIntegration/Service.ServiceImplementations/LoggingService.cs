using System;
using System.ServiceModel;
using System.Threading;
using Service.MessageContracts;
using Service.ServiceContracts;
using Shared.Constants;

namespace Service.ServiceImplementations
{
    [ServiceBehavior(
        Namespace = Namespaces.ServiceModelNamespace,
        InstanceContextMode = InstanceContextMode.PerSession,
        ConcurrencyMode = ConcurrencyMode.Single)]
    public class LoggingService : ILoggingService
    {
        public AddDeploymentLogResponse AddDeploymentLog(AddDeploymentLogRequest addDeploymentLogRequest)
        {
            Thread.Sleep(3000);

            return new AddDeploymentLogResponse
                {
                    DeploymentId = Guid.NewGuid()
                };
        }
    }
}
