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
            private ProductController SUT;

            [TestInitialize]
            public void Initialize()
            {
                var repo = new Mock<IProductRepository>();
                var products = Builder<Product>.CreateListOfSize(9)
                    .TheFirst(3)
                        .With(x => x.Category, "Cat1")
                    .TheNext(3)
                        .With(x => x.Category, "Cat2")
                    .TheNext(2)
                        .With(x => x.Category, "Cat3")
                    .TheNext(1)
                        .With(x => x.Category, null)
                    .Build().AsQueryable();

                repo.Setup(x => x.GetProducts()).Returns(() => products).Verifiable();

                this.SUT = new ProductController(repo.Object);
            }

            [TestMethod]
            public void can_paginate()
            {
                var res = (this.SUT.List() as ViewResult).Model as ProductsListViewModel;
                res.Products.Should().HaveCount(4);
            }

            [TestMethod]
            public void can_send_the_correct_PagingInfo()
            {
                var res = (this.SUT.List(string.Empty, 2) as ViewResult).Model as ProductsListViewModel;

                res.PagingInfo.CurrentPage.Should().Be(2);
                res.PagingInfo.ItemsPerPage.Should().Be(4);
                res.PagingInfo.TotalItems.Should().Be(9);
                res.PagingInfo.TotalPages.Should().Be(3);
            }

            [TestMethod]
            public void can_filter_using_the_current_category()
            {
                var res = (this.SUT.List("Cat2") as ViewResult).Model as ProductsListViewModel;

                res.Products.Should().HaveCount(4);
            }
        }
    }
}
