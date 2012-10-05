using Msts.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Data.Services.Common;
using System.ServiceModel.Web;

namespace Msts.Topics.Chapter10___Services_and_Handlers.Lesson03___WCF_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HelloWorldWcfDataService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select HelloWorldWcfDataService.svc or HelloWorldWcfDataService.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class HelloWorldWcfDataService : DataService<PubsDataContext>
    {
        public static void InitializeService(DataServiceConfiguration config)
        {
            config.SetEntitySetAccessRule("jobs", EntitySetRights.All);

            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;
        }

        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/wcf/jobs")]
        public IQueryable<jobs> Get()
        {
            return Enumerable.Empty<jobs>().AsQueryable();
        }
    }
}
