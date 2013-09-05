using Autofac;
using Autofac.Extras.CommonServiceLocator;
using Microsoft.Practices.ServiceLocation;
using NLogNinjectSlf.Services;
using slf4net;

namespace NLogNinjectSlf
{
    public static class AutofacInitialization
    {
        public static void Initialize()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<MyService>().As<IMyService>();

            containerBuilder.Register(x =>
                {
                    // TODO: Get the correct type
                    return LoggerFactory.GetLogger(x.GetType());
                }).As<ILogger>();

            var builtContainer = containerBuilder.Build();

            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(builtContainer));

            containerBuilder.RegisterInstance(ServiceLocator.Current).As<IServiceLocator>();
        }
    }
}
