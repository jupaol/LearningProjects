using CommonServiceLocator.NinjectAdapter.Unofficial;
using Microsoft.Practices.ServiceLocation;
using Ninject;
using Ninject.Extensions.Conventions;
using slf4net;

namespace NLogNinjectSlf
{
    public static class NinjectInitialize
    {
        public static void Initialize()
        {
            var kernel = new StandardKernel();

            kernel.Bind(x => x.From(typeof(NinjectInitialize).Assembly)
                .SelectAllClasses()
                .Where(c => c.Namespace != null && c.Namespace.EndsWith("Services"))
                .BindAllInterfaces());

            kernel.Bind<ILogger>().ToMethod(x => LoggerFactory.GetLogger(x.Request.Target.Member.ReflectedType));

            ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(kernel));

            kernel.Bind<IServiceLocator>().ToConstant(ServiceLocator.Current);
            kernel.Bind<IKernel>().ToConstant(kernel);
        }
    }
}
