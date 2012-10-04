﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Msts.Mvc
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IExternalHelloWorldWcfService" in both code and config file together.
    [ServiceContract]
    public interface IExternalHelloWorldWcfService
    {
        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/hello")]
        HelloWorldDto HelloWorld();
    }
}
