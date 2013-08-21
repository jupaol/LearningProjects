using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.SessionState;
using CommonServiceLocator.NinjectAdapter.Unofficial;
using Microsoft.Practices.ServiceLocation;
using Ninject.Extensions.Conventions;
using NinjectWithInMvcAndWcf.App_Start;
using NinjectWithInMvcAndWcf.Services;

namespace NinjectWithInMvcAndWcf
{
    public class MvcApplication : HttpApplication
    {
        public MvcApplication()
        {
            BeginRequest += MvcApplication_BeginRequest;
            PostAcquireRequestState += MvcApplication_PostAcquireRequestState;
        }

        void MvcApplication_PostAcquireRequestState(object sender, EventArgs e)
        {
            var application = (HttpApplication)sender;
            var context = application.Context;

            if (context.Request.Path.Contains(".svc"))
            {
                var s = context.Session;

                if (s != null)
                {
                    //s.Abandon();

                    
                }
            }
        }

        void MvcApplication_BeginRequest(object sender, EventArgs e)
        {
            //prevent session cookie from reaching the service
            var application = (HttpApplication)sender;
            var context = application.Context;

            if (context.Request.Path.Contains(".svc"))
            {
            //    context.Request.Cookies.Remove("ASP.NET_SessionId");
                context.SetSessionStateBehavior(SessionStateBehavior.ReadOnly);
            }
        }

        protected void Application_Start()
        {
            var kernel = NinjectWebCommon.Kernel;

            kernel.Bind(x =>
            x.From(typeof(IContextResolver).Assembly)
             .SelectAllClasses()
             .Where(y => y.Namespace != null && y.Namespace.StartsWith(typeof(IContextResolver).Namespace))
             .BindAllInterfaces());

            ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(kernel));

            kernel.Bind<IServiceLocator>().ToConstant(ServiceLocator.Current);


            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        //protected void Application_BeginRequest(object sender, EventArgs e)
        //{
        //    if (Request.Path.Contains("AjaxTestWCFService.svc"))
        //    {
        //        HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.ReadOnly);
        //    }
        //}
    }
}