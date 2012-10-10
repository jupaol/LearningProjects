using Microsoft.Practices.ServiceLocation;
using Ninject;
using NinjectAdapter;
using QueryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace CQRS_SimpleQuery01.Models
{
    public class Global : System.Web.HttpApplication
    {
        

        protected void Application_Start(object sender, EventArgs e)
        {
            var kernel = new StandardKernel();

            kernel.Bind<HttpContextBase>().ToConstant(new HttpContextWrapper(this.Context));
            kernel.Bind<IJobsRepository>().To<JobsRepository>();
            kernel.Bind<IEntityContextResolver>().To<EntityContextResolver>();

            var locator = new NinjectServiceLocator(kernel);

            ServiceLocator.SetLocatorProvider(() => locator);
        }

        protected void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        {
        }

        protected void Application_PostRequestHandlerExecute(object sender, EventArgs e)
        {
            var ctxResolver = ServiceLocator.Current.GetInstance<IEntityContextResolver>();

            ctxResolver.ReleaseContext();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}