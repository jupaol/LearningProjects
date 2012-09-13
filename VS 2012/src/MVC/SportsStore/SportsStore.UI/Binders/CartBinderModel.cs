using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;

namespace SportsStore.UI.Binders
{
    public class CartBinderModel : System.Web.Mvc.IModelBinder
    {
        public object BindModel(System.Web.Mvc.ControllerContext controllerContext, System.Web.Mvc.ModelBindingContext bindingContext)
        {
            var cart = controllerContext.HttpContext.Session["c"] as Cart;

            if (cart == null)
            {
                cart = new Cart();

                controllerContext.HttpContext.Session["c"] = cart;
            }

            return cart;
        }
    }
}