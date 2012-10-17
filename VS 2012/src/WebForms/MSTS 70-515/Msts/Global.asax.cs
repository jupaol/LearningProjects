using Bootstrap;
using Msts.App_Start;
using Msts.Topics.Chapter12___Data_binding.Lesson01___DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using Bootstrap.Ninject;
using Bootstrap.Locator;
using Microsoft.Practices.ServiceLocation;
using StackExchange.Profiling;

namespace Msts
{
    public class Global : System.Web.HttpApplication
    {
        Msts.DataAccess.EFData.PubsEntities PubsEFContext;

        public static Msts.DataAccess.EFData.PubsEntities CurrentContext;

        public Global()
        {
            this.PostRequestHandlerExecute += Global_PostRequestHandlerExecute;
            this.EndRequest += Global_EndRequest;
        }

        private void Global_EndRequest(object sender, EventArgs e)
        {
            MiniProfiler.Stop();
        }

        private void Global_PostRequestHandlerExecute(object sender, EventArgs e)
        {
            var app = sender as HttpApplication;
            var handler = app.Context.Handler as Page;

            if (handler != null)
            {
                var wrapper = ServiceLocator.Current.GetInstance<IContextWrapper>();

                if (CurrentContext != null && wrapper != null && !ReferenceEquals(CurrentContext, wrapper.GetEFContext()))
                {
                    throw new ApplicationException("The InRequestScope method is not working");
                }

                Global.CurrentContext = null;
                wrapper.ReleaseEFContext();            
            }
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            //ScriptManager.ScriptResourceMapping.AddDefinition("jquery",null, new ScriptResourceDefinition
            //    {
            //        DebugPath = "~/Scripts/jquery-1.8.1.js",
            //        Path = "~/Scripts/jquery-1.8.1.min.js"
            //    });

            //var bt = BundleTable.Bundles;

            //bt.Add(new ScriptBundle("~/bundles/jquery").Include(
            //    "~/Scripts/jquery/jquery-{version}.js"
            //    ));

            //Bootstrapper
            //    .Including
            //        .AndAssembly(typeof(Global).Assembly)
            //    .With
            //        .Ninject()
            //    .And
            //        .ServiceLocator()
            //    .Start();

            var ignored = MiniProfiler.Settings.IgnoredPaths.ToList();
            ignored.Add("WebResource.axd");
            ignored.Add("ScriptResource.axd");
            ignored.Add("/Content/");
            ignored.Add("/App_Themes/");
            ignored.Add("/bundles");
            MiniProfiler.Settings.IgnoredPaths = ignored.ToArray();

            MiniProfilerEF.Initialize();

            BundleConfiguration.RegisterBundles(BundleTable.Bundles);
            RoutesConfig.ConfigureRoutes(RouteTable.Routes);

            new JobMapper();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            MiniProfiler.Start();
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

        public override string GetVaryByCustomString(HttpContext context, string custom)
        {
            if (string.IsNullOrWhiteSpace(custom))
            {
                throw new ArgumentNullException("custom");
            }

            var parameters = custom.Split(';');

            foreach (var item in parameters)
            {
                switch (item)
                {
                    case "session":
                        return context.Session.SessionID;
                    default:
                        throw new ArgumentException("custom");
                }
            }

            return base.GetVaryByCustomString(context, custom);
        }
    }
}