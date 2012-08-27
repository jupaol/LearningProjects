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
    public partial class CartController : Controller
    {
        private IProductRepository repository;

        public CartController(IProductRepository repository)
        {
            this.repository = repository;
        }

        public virtual ActionResult AddToCart(int productID, string returnUrl)
        {
            var product = this.repository.GetProducts().FirstOrDefault(x => x.ProductID == productID);

            if (product != null)
            {
                this.GetCart().AddProduct(product, 1);
            }

            return RedirectToAction(MVC.Cart.Index(returnUrl));
        }

        public virtual ActionResult RemoveFromCart(int productID, string returnUrl)
        {
            var product = this.repository.GetProducts().FirstOrDefault(x => x.ProductID == productID);

            if (product != null)
            {
                this.GetCart().RemoveProduct(product);
            }

            return RedirectToAction(MVC.Cart.Index(returnUrl));
        }

        public virtual ActionResult Index(string returnUrl)
        {
            return View(new CartModel { Cart = this.GetCart(), ReturnUrl = returnUrl });
        }

        [NonAction]
        public Cart GetCart()
        {
            var cart = this.Session["cart"] as Cart;

            if (cart == null)
            {
                cart = new Cart();

                this.Session["cart"] = cart;
            }

            return cart;
        }
    }
}
