using CommonServiceLocator.NinjectAdapter.Unofficial;
using Microsoft.Practices.ServiceLocation;
using Ninject;
using Ninject.Extensions.Conventions;

namespace NLogBasic
{
    public static class NinjectInitializer
    {
        public static void Initialize()
        {
            var kernel = new StandardKernel();

            kernel.Bind(x =>
                        x.From(typeof (NinjectInitializer).Assembly)
                         .SelectAllClasses()
                         .Where(y => y.Namespace != null && !y.Namespace.EndsWith("Tests"))
                         .BindAllInterfaces());

            ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(kernel));

            kernel.Bind<IServiceLocator>().ToConstant(ServiceLocator.Current);
        }
    }
}
