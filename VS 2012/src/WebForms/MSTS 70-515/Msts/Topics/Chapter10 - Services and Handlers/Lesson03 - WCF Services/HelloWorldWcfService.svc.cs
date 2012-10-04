using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;

namespace Msts.Topics.Chapter10___Services_and_Handlers.Lesson03___WCF_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HelloWorldWcfService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select HelloWorldWcfService.svc or HelloWorldWcfService.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class HelloWorldWcfService : IHelloWorldWcfService
    {
        public string HelloWorldBare(string name, DateTime birthdayDate)
        {
            return string.Format("Hello World Bare: {0} at: {1}", name, birthdayDate.ToString());
        }

        public string HelloWorldWrapped(string name, DateTime birthdayDate)
        {
            return string.Format("Hello World Wrapped: {0} at: {1}", name, birthdayDate.ToString());
        }

        public string HelloWorldWrappedRequest(string name, DateTime birthdayDate)
        {
            return string.Format("Hello World WrappedRequest: {0} at: {1}", name, birthdayDate.ToString());
        }

        public string HelloWorldWrappedResponse(string name, DateTime birthdayDate)
        {
            return string.Format("Hello World WrappedResponse: {0} at: {1}", name, birthdayDate.ToString());
        }
    }
}
