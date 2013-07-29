using System;
using System.ServiceModel;
using Shared.Constants;

namespace Service.MessageContracts
{
    [MessageContract(WrapperNamespace = Namespaces.ServiceModelNamespace)]
    public class AddDeploymentLogResponse
    {
        [MessageBodyMember(Namespace = Namespaces.ServiceModelNamespace)]
        public Guid DeploymentId { get; set; }
    }
}
