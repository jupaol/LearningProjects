using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Service.MessageContracts;
using Service.ServiceContracts;
using Shared.Constants;

namespace Service.ServiceImplementations
{
    [ServiceBehavior(
        Namespace = Namespaces.ServiceModelNamespace,
        InstanceContextMode = InstanceContextMode.PerSession,
        ConcurrencyMode = ConcurrencyMode.Single)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class LoggingService : ILoggingService
    {
        public AddDeploymentLogResponse AddDeploymentLog(AddDeploymentLogRequest addDeploymentLogRequest)
        {
            return new AddDeploymentLogResponse
                {
                    DeploymentId = Guid.NewGuid()
                };
        }
    }
}
