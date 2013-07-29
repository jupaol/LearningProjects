using System.Net.Security;
using System.ServiceModel;
using Service.MessageContracts;
using Shared.Constants;

namespace Service.ServiceContracts
{
    [ServiceContract(
    Namespace = Namespaces.ServiceModelNamespace,
    SessionMode = SessionMode.Allowed,
    ProtectionLevel = ProtectionLevel.None)]
    public interface IQueueLoggingService
    {
        [OperationContract(IsOneWay = true)]
        void AddDeploymentLog(AddDeploymentLogRequest addDeploymentLogRequest);
    }
}
