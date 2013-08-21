using System.Net.Security;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace NinjectShared
{
    [ServiceContract(
        Namespace = Namespaces.MyNamespace,
        SessionMode = SessionMode.NotAllowed,
        ProtectionLevel = ProtectionLevel.None)]
    public interface ILoggingService
    {
        [OperationContract(IsOneWay = false)]
        [WebInvoke(
            Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string DoWork();

        [OperationContract(IsOneWay = false)]
        [WebInvoke(
            Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string Call1();

        [OperationContract(IsOneWay = false)]
        [WebInvoke(
            Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string Call2();

        [OperationContract(IsOneWay = false)]
        [WebInvoke(
            Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string Call3();
    }
}
