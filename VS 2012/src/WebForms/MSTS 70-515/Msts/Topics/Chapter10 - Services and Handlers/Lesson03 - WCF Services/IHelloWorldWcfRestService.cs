using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Msts.Topics.Chapter10___Services_and_Handlers.Lesson03___WCF_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IHelloWorldWcfRestService" in both code and config file together.
    [ServiceContract(
        SessionMode = SessionMode.Allowed)]
    public interface IHelloWorldWcfRestService
    {
        //[OperationContract(
        //    Name = "HelloWorldBare")]
        //[WebInvoke(
        //    BodyStyle = WebMessageBodyStyle.Bare,
        //    Method = "POST",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json)]
        //HelloWorldDto HelloWorldBare();

        //[OperationContract(
        //    Name = "HelloWorldWrapped")]
        //[WebInvoke(
        //    BodyStyle = WebMessageBodyStyle.Wrapped,
        //    Method = "POST",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json)]
        //HelloWorldDto HelloWorldWrapped();

        [OperationContract(
            Name = "HelloWorldRequestWrapped")]
        [WebGet(
            //Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        HelloWorldDto HelloWorldWrappedRequest();

        //[OperationContract(
        //    Name = "HelloWorldResponseWrapped")]
        //[WebInvoke(
        //    BodyStyle = WebMessageBodyStyle.WrappedResponse,
        //    Method = "POST",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json)]
        //HelloWorldDto HelloWorldWrappedResponse();
    }
}
