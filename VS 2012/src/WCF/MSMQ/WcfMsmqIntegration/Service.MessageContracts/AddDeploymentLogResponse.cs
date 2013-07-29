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

        [MessageBodyMember(Namespace = Namespaces.ServiceModelNamespace)]
        public string NewServerName { get; set; }
    }
}
