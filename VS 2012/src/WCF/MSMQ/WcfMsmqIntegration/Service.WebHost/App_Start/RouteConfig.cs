using System.ServiceModel.Activation;
using System.Web.Mvc;
using System.Web.Routing;
using Service.ServiceImplementations;

namespace Service.WebHost
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.Add(new ServiceRoute("loggingService", new ServiceHostFactory(), typeof(LoggingService)));

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}