using System.Runtime.Serialization;
using Shared.Constants;

namespace Service.FaultContracts
{
    [DataContract(Namespace = Namespaces.ServiceNamespace)]
    public class LoggingFault
    {
        public string FaultReason { get; set; }
    }
}
