using System.Runtime.Serialization;
using Shared.Constants;

namespace Service.DataContracts
{
    [DataContract(Namespace = Namespaces.ServiceNamespace)]
    public class AddDeploymentLog
    {
        public string DatabaseServerName { get; set; }

        public string BuildName { get; set; }

        public string Product { get; set; }

        public string FullBuildName { get; set; }

        public string Environment { get; set; }
    }
}
