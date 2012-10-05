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
using Msts.DataAccess.EFData;
using DataServicesJSONP;

namespace Msts.Topics.Chapter10___Services_and_Handlers.Lesson03___WCF_Services
{
    //[JSONPSupportBehavior]
    public class HelloWorldWcfDataService : DataService<PubsEntities>
    {
        public static void InitializeService(DataServiceConfiguration config)
        {
            config.SetEntitySetAccessRule("*", EntitySetRights.All);
            config.SetServiceOperationAccessRule("*", ServiceOperationRights.All);

            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;
        }
    }
}
