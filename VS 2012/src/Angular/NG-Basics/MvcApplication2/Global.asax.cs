using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Newtonsoft.Json;

namespace MvcApplication2
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RouteTable.Routes.MapHubs();
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            var formatters = GlobalConfiguration.Configuration.Formatters;
            var jsonSettings = formatters.JsonFormatter.SerializerSettings;
            var appXmlType =
                formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");

            formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

            jsonSettings.Formatting = Formatting.Indented;
            //jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

        }
    }
}