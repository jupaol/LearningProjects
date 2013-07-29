using System.ServiceModel;
using Service.DataContracts;
using Shared.Constants;

namespace Service.MessageContracts
{
    [MessageContract(WrapperNamespace = Namespaces.ServiceModelNamespace)]
    public class AddDeploymentLogRequest
    {
        [MessageBodyMember(Namespace = Namespaces.ServiceModelNamespace)]
        public AddDeploymentLog AddDeploymentLog { get; set; }
    }
}
