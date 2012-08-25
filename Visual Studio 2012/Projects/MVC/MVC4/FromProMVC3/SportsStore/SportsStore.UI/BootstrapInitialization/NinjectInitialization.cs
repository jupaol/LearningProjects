using Bootstrap.Ninject;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.UI.BootstrapInitialization
{
    public class NinjectInitialization : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind<IForTesting>().To<ForTesting>();
        }
    }
}