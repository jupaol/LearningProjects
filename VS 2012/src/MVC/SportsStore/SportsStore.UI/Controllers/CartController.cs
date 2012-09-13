using SportsStore.Domain.Abstract;
using SportsStore.Domain.Concrete;
using SportsStore.Domain.Entities;
using SportsStore.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.UI.Controllers
{
    [HandleError]
    public partial class CartController : Controller
    {
        private IProductRepository repository;
        private IOrderProcessor orderProcessor;

        public CartController(IProductRepository repository, IOrderProcessor orderProcessor)
        {
            this.repository = repository;
            this.orderProcessor = orderProcessor;
        }

        public virtual RedirectToRouteResult AddToCart(Cart cart, int productID, string returnUrl)
        {
            var product = this.repository.GetProducts().FirstOrDefault(x => x.ProductID == productID);

            if (product != null)
            {
                cart.AddProduct(product, 1);
            }

            return RedirectToAction(MVC.Cart.Index(cart, returnUrl));
        }

        public virtual RedirectToRouteResult RemoveFromCart(Cart cart, int productID, string returnUrl)
        {
            var product = this.repository.GetProducts().FirstOrDefault(x => x.ProductID == productID);

            if (product != null)
            {
                cart.RemoveProduct(product);
            }

            return RedirectToAction(MVC.Cart.Index(cart, returnUrl));
        }

        public virtual ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartModel { Cart = cart, ReturnUrl = returnUrl });
        }

        public virtual ViewResult Summary(Cart cart)
        {
            return View(cart);
        }

        public virtual ActionResult OrderCompleted(string returnUrl)
        {
            this.ViewData["ReturnUrl"] = returnUrl;

            return View();
        }

        [HttpGet]
        public virtual ViewResult Checkout(string returnUrl, Cart cart)
        {
            this.ViewData["ReturnUrl"] = returnUrl;

            if (cart.Lines.Count() == 0)
            {
                throw new InvalidOperationException("The cart is empty");
            }

            return View();
        }

        [HttpPost]
        public virtual ActionResult Checkout(string returnUrl, Cart cart, ShippingDetails shippingDetails)
        {
            this.ViewData["ReturnUrl"] = returnUrl;

            if (!this.ModelState.IsValid)
            {
                return View(shippingDetails);
            }

            if (cart.Lines.Count() == 0)
            {
                this.ModelState.AddModelError(string.Empty, "Your cart is empty");
                return View(shippingDetails);
            }

            this.orderProcessor.ProcessOrder(cart, shippingDetails);
            cart.Clear();

            return RedirectToAction("OrderCompleted", new { returnUrl = returnUrl });
        }
    }
}
