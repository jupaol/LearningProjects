using DataServicesJSONP;
using Msts.Mvc.DataAccess.EFData;
using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Msts.Mvc
{
    [JSONPSupportBehavior]
    public class ExternalHelloWorldWcfRestDataService : DataService<pubsEntities>
    {
        public static void InitializeService(DataServiceConfiguration config)
        {
            config.SetEntitySetAccessRule("*", EntitySetRights.AllRead);
            config.SetServiceOperationAccessRule("*", ServiceOperationRights.AllRead);
            config.DataServiceBehavior.MaxProtocolVersion = System.Data.Services.Common.DataServiceProtocolVersion.V2;
        }
    }
}
