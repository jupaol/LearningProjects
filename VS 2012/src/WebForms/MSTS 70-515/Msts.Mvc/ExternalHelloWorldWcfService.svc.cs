using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading;

namespace Msts.Mvc
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ExternalHelloWorldWcfService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ExternalHelloWorldWcfService.svc or ExternalHelloWorldWcfService.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ExternalHelloWorldWcfService : IExternalHelloWorldWcfService
    {
        public HelloWorldDto HelloWorld()
        {
            Thread.Sleep(3000);

            return new HelloWorldDto
            {
                Message = DateTime.Now.ToString()
            };
        }
    }
}
