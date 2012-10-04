using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading;

namespace Msts.Topics.Chapter10___Services_and_Handlers.Lesson03___WCF_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HelloWorldWcfRestService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select HelloWorldWcfRestService.svc or HelloWorldWcfRestService.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class HelloWorldWcfRestService : IHelloWorldWcfRestService
    {
        public HelloWorldDto HelloWorldBare()
        {
            throw new NotImplementedException();
        }

        public HelloWorldDto HelloWorldWrapped()
        {
            throw new NotImplementedException();
        }

        public HelloWorldDto HelloWorldWrappedRequest()
        {
            Thread.Sleep(3000);

            return new HelloWorldDto
            {
                Message = "plop",
                ProcessedDate = DateTime.Now
            };
        }

        public HelloWorldDto HelloWorldWrappedResponse()
        {
            throw new NotImplementedException();
        }
    }
}
