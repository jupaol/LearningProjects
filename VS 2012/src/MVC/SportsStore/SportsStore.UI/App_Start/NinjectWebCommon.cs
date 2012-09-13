[assembly: WebActivator.PreApplicationStartMethod(typeof(SportsStore.UI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(SportsStore.UI.App_Start.NinjectWebCommon), "Stop")]

namespace SportsStore.UI.App_Start
{
    using Bootstrap.AutoMapper;
    using Bootstrap.Extensions.StartupTasks;
    using Bootstrap.Locator;
    using Bootstrap.Ninject;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using SportsStore.Domain.Entities;
    using System;
    using System.Web;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            Bootstrap.Bootstrapper
                .Including
                    //.AssemblyRange(BuildManager.GetReferencedAssemblies().OfType<Assembly>().Where(x => x.FullName.StartsWith("SportsStore")))
                    .AssemblyRange(new[] { typeof(NinjectWebCommon).Assembly, typeof(Product).Assembly })
                .With
                    .Ninject()
                .And
                    .ServiceLocator()
                .And
                    .AutoMapper()
                .And
                    .StartupTasks()
                .Start();

            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            //var kernel = new StandardKernel();
            var kernel = Bootstrap.Bootstrapper.Container as IKernel;

            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            return kernel;
        }
    }
}
