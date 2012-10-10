using ExternalQueryService.App_Start;
using Microsoft.Practices.ServiceLocation;
using Ninject;
using NinjectAdapter;
using QueryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ExternalQueryService
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public MvcApplication()
        {
            this.PostRequestHandlerExecute += MvcApplication_PostRequestHandlerExecute;
        }

        private void MvcApplication_PostRequestHandlerExecute(object sender, EventArgs e)
        {
            var contextResolver = ServiceLocator.Current.GetInstance<IEntityContextResolver>();

            contextResolver.ReleaseContext();
        }

        protected void Application_Start()
        {
            var kernel = NinjectWebCommon.Kernel;

            //kernel.Bind<HttpContextBase>().ToConstant(new HttpContextWrapper(this.Context));

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}