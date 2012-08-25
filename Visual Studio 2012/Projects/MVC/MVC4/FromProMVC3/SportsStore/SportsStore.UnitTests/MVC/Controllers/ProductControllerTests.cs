using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Ploeh.AutoFixture;
using Moq;
using Ploeh.AutoFixture.AutoMoq;
using SportsStore.UI.Controllers;
using SportsStore.Domain.Concrete;
using SportsStore.Domain.Entities;
using FizzWare.NBuilder;
using System.Web.Mvc;
using MvcContrib.TestHelper;
using MvcContrib.TestHelper.Fakes;
using System.Web;
using System.Security.Principal;
using System.Collections.Generic;
using SportsStore.UI.Models;

namespace SportsStore.UnitTests.MVC.Controllers
{
    [TestClass]
    public class ProductControllerTests
    {
        [TestClass]
        public class TheListMethod
        {
            [TestMethod]
            public void CanPaginate()
            {
                var repo = new Mock<IProductRepository>();
                var products = Builder<Product>.CreateListOfSize(9).Build().AsQueryable();
                var sut = new ProductController(repo.Object);

                repo.Setup(x => x.GetProducts()).Returns(() => products).Verifiable();

                var res = (sut.List() as ViewResult).Model as IEnumerable<Product>;
                res.Should().HaveCount(4);
            }
        }
    }
}
