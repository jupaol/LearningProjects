using FizzWare.NBuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Concrete;
using SportsStore.Domain.Entities;
using SportsStore.UI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using FluentAssertions;
using MvcContrib.TestHelper;
using SportsStore.UI.Models;
using SportsStore.Domain.Abstract;

namespace SportsStore.UnitTests.MVC.Controllers
{
    [TestClass]
    public class CartControllerTests
    {
        public static Mock<IOrderProcessor> OrderProcessorMock;

        public static CartController GetCartController()
        {
            var repository = new Mock<IProductRepository>();
            var orderProcessor = new Mock<IOrderProcessor>();
            var products = Builder<Product>.CreateListOfSize(10).Build().AsQueryable();

            repository.Setup(x => x.GetProducts()).Returns(() => products).Verifiable();

            OrderProcessorMock = orderProcessor;

            return new CartController(repository.Object, orderProcessor.Object);
        }

        [TestClass]
        public class TheAddToCartActionMethod
        {
            [TestMethod]
            public void can_add_a_new_product_to_the_cart()
            {
                var sut = CartControllerTests.GetCartController();
                var cart = new Cart();
                var resAction = sut.AddToCart(cart, 1, "~/") as RedirectToRouteResult;

                cart.Lines.Should().HaveCount(1);
                cart.Lines.First().Product.ProductID.Should().Be(1);
            }

            [TestMethod]
            public void after_adding_a_product_to_the_cart_the_correct_action_is_redirected()
            {
                var sut = CartControllerTests.GetCartController();
                var cart = new Cart();
                var res = sut.AddToCart(cart, 1, "~/");

                //res.AssertActionRedirect().ToAction<CartController>(x => x.Index(cart, "~/"));
                res.RouteValues["action"].Should().Be("Index");
                res.RouteValues["returnUrl"].Should().Be("~/");
            }
        }

        [TestClass]
        public class TheIndexMethod
        {
            [TestMethod]
            public void returns_the_cart_and_the_returnUrl()
            {
                var sut = CartControllerTests.GetCartController();
                var cart = new Cart();
                var res = sut.Index(cart, "~/");
                var model = res.Model as CartModel;

                model.Cart.Should().Be(cart);
                model.ReturnUrl.Should().Be("~/");
            }

            [TestMethod]
            public void returns_the_default_view()
            {
                var sut = CartControllerTests.GetCartController();
                var cart = new Cart();

                var res = sut.Index(cart, string.Empty);

                res.ViewName.Should().Be(string.Empty); // default view
            }
        }

        [TestClass]
        public class TheCheckoutGetMethod
        {
            [TestMethod]
            public void when_the_cart_is_empty_this_method_should_throw_an_exception()
            {
                var sut = CartControllerTests.GetCartController();
                var cart = new Cart();

                sut.Invoking(x => x.Checkout(string.Empty, cart))
                    .ShouldThrow<InvalidOperationException>()
                    .WithMessage("The cart is empty", FluentAssertions.Assertions.ComparisonMode.Substring);

                CartControllerTests.OrderProcessorMock.Verify(x => x.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()), Times.Never());
            }

            [TestMethod]
            public void it_should_render_the_default_view_passing_the_returnUrl_parameter()
            {
                var sut = CartControllerTests.GetCartController();
                var cart = new Cart();

                cart.AddProduct(new Product(), 2);

                var res = sut.Checkout("~/", cart);

                res.ViewName.Should().BeEmpty(); // default view rendered
                res.ViewData["ReturnUrl"].ToString().Should().Be("~/");
            }
        }

        [TestClass]
        public class TheCheckoutPostMethod
        {
            [TestMethod]
            public void it_should_return_the_default_view_when_the_model_contains_errors()
            {
                var sut = CartControllerTests.GetCartController();
                var cart = new Cart();
                var shippingDetails = new ShippingDetails();

                sut.ModelState.AddModelError("error", "error");

                var res = sut.Checkout("~/", cart, shippingDetails) as ViewResult;

                res.ViewName.Should().BeEmpty();
                res.ViewData["ReturnUrl"].ToString().Should().Be("~/");
                sut.ModelState.Count.Should().Be(1);
                sut.ModelState.IsValid.Should().BeFalse();

                CartControllerTests.OrderProcessorMock.Verify(x => x.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()), Times.Never());
            }

            [TestMethod]
            public void it_should_return_the_default_view_when_the_cart_is_empty()
            {
                var sut = CartControllerTests.GetCartController();
                var cart = new Cart();
                var shippingDetails = new ShippingDetails();

                var res = sut.Checkout("~/", cart, shippingDetails) as ViewResult;

                res.ViewName.Should().BeEmpty();
                sut.ModelState.Count.Should().Be(1);
                sut.ModelState.IsValid.Should().BeFalse();

                CartControllerTests.OrderProcessorMock.Verify(x => x.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()), Times.Never());
            }

            [TestMethod]
            public void whene_there_are_no_errors_it_should_redirect_to_a_completed_action()
            {
                var sut = CartControllerTests.GetCartController();
                var cart = new Cart();
                var shippingDetails = new ShippingDetails();

                cart.AddProduct(Builder<Product>.CreateNew().Build(), 3);

                var res = sut.Checkout("~/", cart, shippingDetails) as RedirectToRouteResult;

                res.RouteValues["action"].ToString().Should().Be("OrderCompleted");
                res.RouteValues["returnUrl"].ToString().Should().Be("~/");
                sut.ModelState.IsValid.Should().BeTrue();
                CartControllerTests.OrderProcessorMock.Verify(x => x.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()), Times.Once());
            }
        }
    }
}
