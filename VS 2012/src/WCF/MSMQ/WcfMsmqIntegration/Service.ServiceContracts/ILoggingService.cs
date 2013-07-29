using System.Net.Security;
using System.ServiceModel;
using System.ServiceModel.Web;
using Service.FaultContracts;
using Service.MessageContracts;
using Shared.Constants;

namespace Service.ServiceContracts
{
    [ServiceContract(
        Namespace = Namespaces.ServiceModelNamespace,
        SessionMode = SessionMode.Allowed,
        ProtectionLevel = ProtectionLevel.None)]
    public interface ILoggingService
    {
        [OperationContract]
        [FaultContract(typeof(LoggingFault))]
        [WebInvoke(
            Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        AddDeploymentLogResponse AddDeploymentLog(AddDeploymentLogRequest addDeploymentLogRequest);
    }
}
