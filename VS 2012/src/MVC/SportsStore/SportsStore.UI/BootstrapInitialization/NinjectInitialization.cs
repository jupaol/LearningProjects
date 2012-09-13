using Bootstrap.Ninject;
using Ninject;
using Ninject.Modules;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Concrete;
using SportsStore.Domain.Entities;
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
            this.Kernel.Bind<IProductRepository>().To<ProductRepository>();

            var emailSettings = new EmailSettings
            {
                MailToAddress = "orders@sportsstore.com",
                MailFromAddress = "sportsStore@sportsstore.com",
                UseSsl = false,
                Username = "user",
                Password = "password",
                ServerName = "localhost",
                ServerPort =  25,
                WriteAsFile = false,
                FileLocation = @"c:\somepath"
            };

            this.Kernel.Bind<IOrderProcessor>().To<OrderProcessor>().WithConstructorArgument("emailSettings", emailSettings);
            this.Kernel.Bind<IAccountRepository>().To<AccountRepository>();
        }
    }
}