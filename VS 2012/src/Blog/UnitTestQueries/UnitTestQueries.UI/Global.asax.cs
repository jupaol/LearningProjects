using Microsoft.Practices.ServiceLocation;
using NinjectAdapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using UnitTestQueries.UI.App_Start;
using Ninject;
using Ninject.Extensions.Conventions;
using System.Web.Compilation;
using System.Reflection;
using UnitTestQueries.Data;

namespace UnitTestQueries.UI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public MvcApplication()
        {
            this.PostRequestHandlerExecute += MvcApplication_PostRequestHandlerExecute;
        }

        protected void MvcApplication_PostRequestHandlerExecute(object sender, EventArgs e)
        {
            var contextManager = ServiceLocator.Current.GetInstance<IContextManager>();

            contextManager.ReleaseContext();
        }

        protected void Application_Start()
        {
            var kernel = NinjectWebCommon.Kernel;

            kernel.Bind(conv =>
                {
                    var assemblies = BuildManager.GetReferencedAssemblies().OfType<Assembly>()
                        .Where(x => 
                            x.FullName.StartsWith("UnitTestQueries.Data", StringComparison.InvariantCulture) ||
                            x.FullName.StartsWith("UnitTestQueries.Logic", StringComparison.InvariantCulture)
                        );

                    conv
                        .From(assemblies)
                        .SelectAllClasses()
                        .BindAllInterfaces();
                });

            ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(kernel));

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }
    }
}