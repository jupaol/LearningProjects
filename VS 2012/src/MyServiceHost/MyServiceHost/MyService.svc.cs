using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading;

namespace MyServiceHost
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MyService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MyService.svc or MyService.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class MyService : IMyService
    {
        public HelloWorldDto Execute()
        {
            Thread.Sleep(3000);

            return new HelloWorldDto
            {
                Message = MethodInfo.GetCurrentMethod().Name,
                ProcessDate = DateTime.Now,
                ServerTicks = (int)DateTime.Now.Ticks
            };
        }
    }
}
