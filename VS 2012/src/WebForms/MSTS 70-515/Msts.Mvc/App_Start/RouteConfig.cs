using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Msts.Mvc
{
    public class MyWcfRestRouteConstrain : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            var controller = values["controller"] as string;

            if (!string.IsNullOrWhiteSpace(controller))
            {
                return !controller.StartsWith("wcf", StringComparison.InvariantCultureIgnoreCase);
            }
            else
            {
                return true;
            }
        }
    }

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.svc/{*pathInfo}");

            routes.RouteExistingFiles = false;

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                //constraints: new { controller = new MyWcfRestRouteConstrain() }
                constraints: new { controller = "^(?!wcf).+" }
            );

            routes.Add(new ServiceRoute(
                "wcf",
                new ServiceHostFactory(),
                typeof(ExternalHelloWorldWcfService)));
        }
    }
}