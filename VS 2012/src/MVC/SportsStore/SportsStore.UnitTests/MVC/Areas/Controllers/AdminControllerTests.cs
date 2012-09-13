using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using SportsStore.Domain.Concrete;
using Moq;
using FizzWare.NBuilder;
using SportsStore.Domain.Entities;
using System.Linq;
using System.Web.Mvc;
using SportsStore.UI.Controllers;
using SportsStore.UI.Areas.Administration.Controllers;
using System.Collections.Generic;
using SportsStore.UI.Models;
using SportsStore.UI.Areas.Administration.Models;
using System.Web;
using System.IO;

namespace SportsStore.UnitTests.MVC.Areas.Controllers
{
    [TestClass]
    public class AdminControllerTests
    {
        private static Mock<IProductRepository> productRepository;
        public static AdminController GetAdminController()
        {
            var repository = new Mock<IProductRepository>();
            var sut = new AdminController(repository.Object);
            var products = Builder<Product>.CreateListOfSize(10).Build().AsQueryable();

            repository.Setup(x => x.GetProducts()).Returns(() => products).Verifiable();

            productRepository = repository;
            return sut;
        }

        [TestClass]
        public class TheListGetAction
        {
            [TestMethod]
            public void it_should_render_the_default_view()
            {
                var sut = AdminControllerTests.GetAdminController();

                var res = sut.List() as ViewResult;

                res.ViewName.Should().BeEmpty(); // default vuew rendered
            }

            [TestMethod]
            public void it_should_return_the_list_of_products()
            {
                var sut = AdminControllerTests.GetAdminController();

                var res = sut.List() as ViewResult;
                var model = res.Model as AdminProductModel;

                model.Should().NotBeNull();
                model.Products.Should().NotBeEmpty();
            }

            [TestMethod]
            public void it_should_paginate_the_results()
            {
                var sut = AdminControllerTests.GetAdminController();

                var res = sut.List(2) as ViewResult;
                var model = res.Model as AdminProductModel;

                model.Should().NotBeNull();
                model.Products.Should().HaveCount(4);
                model.PagingInfo.Should().NotBeNull();
                model.PagingInfo.CurrentPage.Should().Be(2);
                model.PagingInfo.ItemsPerPage.Should().Be(4);
                model.PagingInfo.TotalItems.Should().Be(10);
            }
        }

        [TestClass]
        public class TheDetailsGetAction
        {
            [TestMethod]
            public void it_should_throw_an_exception_if_the_product_is_not_found()
            {
                var sut = AdminControllerTests.GetAdminController();

                sut.Invoking(x => x.Details(999))
                    .ShouldThrow<IndexOutOfRangeException>();
            }

            [TestMethod]
            public void it_should_render_the_default_view()
            {
                var sut = AdminControllerTests.GetAdminController();

                var res = sut.Details(1) as ViewResult;

                res.ViewName.Should().BeEmpty();
            }

            [TestMethod]
            public void it_should_return_the_product_to_the_view()
            {
                var sut = AdminControllerTests.GetAdminController();

                var res = sut.Details(1) as ViewResult;
                var model = res.Model as Product;

                model.Should().NotBeNull();
                model.ProductID.Should().Be(1);
            }
        }

        [TestClass]
        public class TheEditGetAction
        {
            [TestMethod]
            public void it_should_render_the_default_view()
            {
                var sut = AdminControllerTests.GetAdminController();

                var res = sut.Edit(1) as ViewResult;

                res.ViewName.Should().BeEmpty();
            }

            [TestMethod]
            public void it_should_throw_an_exception_if_the_product_does_not_exist()
            {
                var sut = AdminControllerTests.GetAdminController();

                sut.Invoking(x => x.Edit(999))
                    .ShouldThrow<IndexOutOfRangeException>()
                    .WithMessage("Product not found", FluentAssertions.Assertions.ComparisonMode.Substring);
            }

            [TestMethod]
            public void it_should_pass_the_current_product_to_the_view()
            {
                var sut = AdminControllerTests.GetAdminController();

                var res = sut.Edit(1) as ViewResult;
                var model = res.Model as Product;

                model.Should().NotBeNull();
                model.ProductID.Should().Be(1);
            }
        }

        [TestClass]
        public class TheEditPostAction
        {
            [TestMethod]
            public void it_should_throw_an_exception_if_the_product_does_not_exist()
            {
                var sut = AdminControllerTests.GetAdminController();
                var product = Builder<Product>.CreateNew().With(x => x.ProductID, 999).Build();

                sut.Invoking(x => x.Edit(product, null))
                    .ShouldThrow<IndexOutOfRangeException>()
                    .WithMessage("Product not found", FluentAssertions.Assertions.ComparisonMode.Substring);
            }

            [TestMethod]
            public void if_the_model_contains_errors_it_should_render_the_default_view_and_pass_the_current_product_back_to_the_view()
            {
                var sut = AdminControllerTests.GetAdminController();
                var product = new Product { ProductID = 1, Name = "plop" };

                sut.ModelState.AddModelError("error", "error");

                var res = sut.Edit(product, null) as ViewResult;
                var model = res.Model as Product;

                res.ViewName.Should().BeEmpty();
                model.Should().NotBeNull();
                model.ProductID.Should().Be(1);
                model.Name.Should().Be("plop");
                sut.ModelState.IsValid.Should().BeFalse();
            }

            [TestMethod]
            public void if_the_model_does_not_contain_errors_it_should_update_the_current_product()
            {
                var sut = AdminControllerTests.GetAdminController();
                var product = Builder<Product>.CreateNew().Build();

                sut.Edit(product, null);

                productRepository.Verify(x => x.UpdateProduct(product), Times.Once());
            }

            [TestMethod]
            public void if_the_model_does_not_contain_errors_it_should_redirect_to_the_details_action_with_the_current_product_id()
            {
                var sut = AdminControllerTests.GetAdminController();
                var product = Builder<Product>.CreateNew().Build();

                var res = sut.Edit(product, null) as RedirectToRouteResult;

                res.RouteValues["controller"].ToString().Should().Be("Admin");
                res.RouteValues["action"].ToString().Should().Be("Details");
                res.RouteValues["area"].ToString().Should().Be("Administration");
            }

            [TestMethod]
            public void when_redirecting_to_the_details_action_it_should_pass_a_message_indicating_the_success_of_the_operation()
            {
                var sut = AdminControllerTests.GetAdminController();
                var product = Builder<Product>.CreateNew().Build();

                var res = sut.Edit(product, null) as RedirectToRouteResult;
                var message = sut.TempData["message"];

                message.Should().NotBeNull();
                message.Should().BeOfType<string>();
            }

            [TestMethod]
            public void if_the_model_does_not_contain_errors_and_the_posted_image_is_null_it_should_not_read_the_posted_file_into_the_product_model()
            {
                var sut = AdminControllerTests.GetAdminController();
                var product = Builder<Product>.CreateNew().With(x => x.ImageData, null).With(x => x.ImageMimeType, string.Empty).Build();

                var res = sut.Edit(product, null);

                productRepository.Verify(x => x.UpdateProduct(product), Times.Once());
            }
        }

        [TestClass]
        public class TheDeletePostAction
        {
            [TestMethod]
            public void it_should_throw_an_exception_if_the_product_does_not_exist()
            {
                var sut = AdminControllerTests.GetAdminController();

                sut.Invoking(x => x.Delete(22))
                    .ShouldThrow<IndexOutOfRangeException>()
                    .WithMessage("Product not found", FluentAssertions.Assertions.ComparisonMode.Substring);
            }

            [TestMethod]
            public void it_should_delete_the_product()
            {
                var sut = AdminControllerTests.GetAdminController();

                sut.Delete(2);

                productRepository.Verify(x => x.Delete(2), Times.Once());
            }

            [TestMethod]
            public void it_should_redirect_to_the_list_action()
            {
                var sut = AdminControllerTests.GetAdminController();

                var res = sut.Delete(2) as RedirectToRouteResult;

                res.RouteValues["controller"].ToString().Should().Be("Admin");
                res.RouteValues["action"].ToString().Should().Be("List");
                res.RouteValues["area"].ToString().Should().Be("Administration");
            }
        }

        [TestClass]
        public class TheCreateGetAction
        {
            [TestMethod]
            public void it_should_render_the_default_view()
            {
                var sut = AdminControllerTests.GetAdminController();

                var res = sut.Create() as ViewResult;

                res.ViewName.Should().BeEmpty();
            }
        }

        [TestClass]
        public class TheCreatePostAction
        {
            [TestMethod]
            public void when_the_model_contains_validation_errors_it_should_render_the_default_view_passing_the_current_product_to_the_view()
            {
                var sut = AdminControllerTests.GetAdminController();
                var product = Builder<Product>.CreateNew().Build();

                sut.ModelState.AddModelError("error", "error");

                var res = sut.Create(product) as ViewResult;
                var model = res.Model as Product;

                res.ViewName.Should().BeEmpty();
                model.Should().NotBeNull();
                model.Should().Be(product);
                productRepository.Verify(x => x.Add(It.IsAny<Product>()), Times.Never());
            }

            [TestMethod]
            public void when_the_model_does_not_contain_errors_it_should_create_a_new_product()
            {
                var sut = AdminControllerTests.GetAdminController();
                var product = Builder<Product>.CreateNew().Build();

                sut.Invoking(x => x.Create(product))
                    .ShouldNotThrow();

                productRepository.Verify(x => x.Add(product), Times.Once());
            }

            [TestMethod]
            public void after_creating_a_new_product_it_should_redirect_to_the_details_action_wit_the_id_of_the_new_product()
            {
                var sut = AdminControllerTests.GetAdminController();
                var product = Builder<Product>.CreateNew().Build();

                var res = sut.Create(product) as RedirectToRouteResult;

                res.RouteValues["controller"].ToString().Should().Be("Admin");
                res.RouteValues["action"].ToString().Should().Be("Details");
                res.RouteValues["area"].ToString().Should().Be("Administration");
            }

            [TestMethod]
            public void after_creating_the_new_product_it_should_pass_a_message_to_the_next_view()
            {
                var sut = AdminControllerTests.GetAdminController();
                var product = Builder<Product>.CreateNew().Build();

                sut.Create(product);

                sut.TempData["message"].Should().NotBeNull();
            }
        }
    }
}
