using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcContrib.TestHelper;
using SportsStore.UI.Controllers;
using SportsStore.UI;
using System.Web.Routing;

namespace SportsStore.UnitTests.MVC.MvcRoutes
{
    [TestClass]
    public class RouteTests
    {
        [TestMethod]
        [Ignore]
        public void TestMethod1()
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            "~/".ShouldMapTo<ProductController>(x => x.List("", 1));
        }
    }
}
