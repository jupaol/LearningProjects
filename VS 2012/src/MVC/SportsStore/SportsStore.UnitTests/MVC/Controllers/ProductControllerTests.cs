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
        public static ProductController GetProductController()
        {
            var repo = new Mock<IProductRepository>();
            var products = Builder<Product>.CreateListOfSize(9)
                .TheFirst(1)
                    .With(x => x.Category, "Cat1")
                    .With(x => x.ImageData, new byte[] { })
                    .With(x => x.ImageMimeType, "image/jpg")
                .TheFirst(2)
                    .With(x => x.Category, "Cat1")
                .TheNext(3)
                    .With(x => x.Category, "Cat2")
                .TheNext(2)
                    .With(x => x.Category, "Cat3")
                .TheNext(1)
                    .With(x => x.Category, null)
                .Build().AsQueryable();

            repo.Setup(x => x.GetProducts()).Returns(() => products).Verifiable();

            return new ProductController(repo.Object);
        }

        [TestClass]
        public class TheListMethod
        {
            [TestMethod]
            public void can_paginate()
            {
                var res = (ProductControllerTests.GetProductController().List() as ViewResult).Model as ProductsListViewModel;
                res.Products.Should().HaveCount(4);
            }

            [TestMethod]
            public void can_send_the_correct_PagingInfo()
            {
                var res = (ProductControllerTests.GetProductController().List(string.Empty, 2) as ViewResult).Model as ProductsListViewModel;

                res.PagingInfo.CurrentPage.Should().Be(2);
                res.PagingInfo.ItemsPerPage.Should().Be(4);
                res.PagingInfo.TotalItems.Should().Be(9);
                res.PagingInfo.TotalPages.Should().Be(3);
            }

            [TestMethod]
            public void can_filter_using_the_current_category()
            {
                var res = (ProductControllerTests.GetProductController().List("Cat2") as ViewResult).Model as ProductsListViewModel;

                res.Products.Should().HaveCount(4);
            }
        }

        [TestClass]
        public class TheGetImageGetMethod
        {
            [TestMethod]
            public void it_should_throw_an_exception_if_the_product_does_not_exist()
            {
                var sut = ProductControllerTests.GetProductController();

                sut.Invoking(x => x.GetImage(99))
                    .ShouldThrow<IndexOutOfRangeException>()
                    .WithMessage("Product not found", FluentAssertions.Assertions.ComparisonMode.Substring);
            }

            [TestMethod]
            public void it_should_return_null_if_the_current_product_does_not_contain_an_image()
            {
                var sut = ProductControllerTests.GetProductController();

                var res = (FileContentResult)sut.GetImage(2);

                res.Should().BeNull();
            }

            [TestMethod]
            public void it_should_return_the_product_image()
            {
                var sut = ProductControllerTests.GetProductController();

                var res = (FileContentResult)sut.GetImage(1);

                res.Should().NotBeNull();
                res.ContentType.Should().Be("image/jpg");
                res.FileContents.Should().NotBeNull();
            }
        }

        [TestClass]
        public class TheGetProductInfoGetMethod
        {
            [TestMethod]
            public void it_should_render_the_default_view()
            {
                var sut = ProductControllerTests.GetProductController();

                var res = sut.GetProductInfo(21) as FileResult;

                res.ContentType.Should().Be("application/pdf");
                res.FileDownloadName.Should().Be("01.pdf");
            }
        }
    }
}
