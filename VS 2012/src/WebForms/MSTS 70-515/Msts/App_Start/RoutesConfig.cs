using Msts.Topics.Chapter10___Services_and_Handlers.Lesson03___WCF_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Routing;

namespace Msts.App_Start
{
    public class RoutesConfig
    {
        public static void ConfigureRoutes(RouteCollection routes)
        {
            routes.Ignore("{resource}.axd/{*pathInfo}");
        }
    }
}