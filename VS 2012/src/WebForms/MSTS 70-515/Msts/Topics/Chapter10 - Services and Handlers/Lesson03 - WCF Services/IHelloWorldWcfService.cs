using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Msts.Topics.Chapter10___Services_and_Handlers.Lesson03___WCF_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IHelloWorldWcfService" in both code and config file together.
    [ServiceContract(SessionMode = SessionMode.Allowed)]
    public interface IHelloWorldWcfService
    {
        [OperationContract(
            Name = "HelloWorldBare")]
        [WebInvoke(
            BodyStyle = WebMessageBodyStyle.Bare,
            Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string HelloWorldBare(string name, DateTime birthdayDate);

        [OperationContract(
            Name = "HelloWorldWr")]
        [WebInvoke(
            BodyStyle = WebMessageBodyStyle.Wrapped,
            Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string HelloWorldWrapped(string name, DateTime birthdayDate);

        [OperationContract(
            Name = "HelloWorldRequestWrapped")]
        [WebInvoke(
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string HelloWorldWrappedRequest(string name, DateTime birthdayDate);

        [OperationContract(
            Name = "HelloWorldResponseWrapped")]
        [WebInvoke(
            BodyStyle = WebMessageBodyStyle.WrappedResponse,
            Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string HelloWorldWrappedResponse(string name, DateTime birthdayDate);
    }
}
