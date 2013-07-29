using System.Runtime.Serialization;
using Shared.Constants;

namespace Service.DataContracts
{
    [DataContract(Namespace = Namespaces.ServiceNamespace)]
    public class AddDeploymentLog
    {
        [DataMember]
        public string DatabaseServerName { get; set; }

        [DataMember]
        public string BuildName { get; set; }

        [DataMember]
        public string Product { get; set; }

        [DataMember]
        public string FullBuildName { get; set; }

        [DataMember]
        public string Environment { get; set; }
    }
}
