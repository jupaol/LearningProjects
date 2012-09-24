// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments
#pragma warning disable 1591
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace SportsStore.UI.Controllers {
    public partial class CartController {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected CartController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result) {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.RedirectToRouteResult AddToCart() {
            return new T4MVC_RedirectToRouteResult(Area, Name, ActionNames.AddToCart);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.RedirectToRouteResult RemoveFromCart() {
            return new T4MVC_RedirectToRouteResult(Area, Name, ActionNames.RemoveFromCart);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ViewResult Index() {
            return new T4MVC_ViewResult(Area, Name, ActionNames.Index);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ViewResult Summary() {
            return new T4MVC_ViewResult(Area, Name, ActionNames.Summary);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ViewResult Checkout() {
            return new T4MVC_ViewResult(Area, Name, ActionNames.Checkout);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public CartController Actions { get { return MVC.Cart; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Cart";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Cart";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass {
            public readonly string AddToCart = "AddToCart";
            public readonly string RemoveFromCart = "RemoveFromCart";
            public readonly string Index = "Index";
            public readonly string Summary = "Summary";
            public readonly string Checkout = "Checkout";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants {
            public const string AddToCart = "AddToCart";
            public const string RemoveFromCart = "RemoveFromCart";
            public const string Index = "Index";
            public const string Summary = "Summary";
            public const string Checkout = "Checkout";
        }


        static readonly ActionParamsClass_AddToCart s_params_AddToCart = new ActionParamsClass_AddToCart();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_AddToCart AddToCartParams { get { return s_params_AddToCart; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_AddToCart {
            public readonly string cart = "cart";
            public readonly string productID = "productID";
            public readonly string returnUrl = "returnUrl";
        }
        static readonly ActionParamsClass_RemoveFromCart s_params_RemoveFromCart = new ActionParamsClass_RemoveFromCart();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_RemoveFromCart RemoveFromCartParams { get { return s_params_RemoveFromCart; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_RemoveFromCart {
            public readonly string cart = "cart";
            public readonly string productID = "productID";
            public readonly string returnUrl = "returnUrl";
        }
        static readonly ActionParamsClass_Index s_params_Index = new ActionParamsClass_Index();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Index IndexParams { get { return s_params_Index; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Index {
            public readonly string cart = "cart";
            public readonly string returnUrl = "returnUrl";
        }
        static readonly ActionParamsClass_Summary s_params_Summary = new ActionParamsClass_Summary();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Summary SummaryParams { get { return s_params_Summary; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Summary {
            public readonly string cart = "cart";
        }
        static readonly ActionParamsClass_Checkout s_params_Checkout = new ActionParamsClass_Checkout();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Checkout CheckoutParams { get { return s_params_Checkout; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Checkout {
            public readonly string returnUrl = "returnUrl";
            public readonly string cart = "cart";
        }
        static readonly ViewNames s_views = new ViewNames();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewNames Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewNames {
            public readonly string Checkout = "~/Views/Cart/Checkout.cshtml";
            public readonly string Index = "~/Views/Cart/Index.cshtml";
            public readonly string OrderCompleted = "~/Views/Cart/OrderCompleted.cshtml";
            public readonly string Summary = "~/Views/Cart/Summary.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class T4MVC_CartController: SportsStore.UI.Controllers.CartController {
        public T4MVC_CartController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.RedirectToRouteResult AddToCart(SportsStore.Domain.Entities.Cart cart, int productID, string returnUrl) {
            var callInfo = new T4MVC_RedirectToRouteResult(Area, Name, ActionNames.AddToCart);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "cart", cart);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "productID", productID);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "returnUrl", returnUrl);
            return callInfo;
        }

        public override System.Web.Mvc.RedirectToRouteResult RemoveFromCart(SportsStore.Domain.Entities.Cart cart, int productID, string returnUrl) {
            var callInfo = new T4MVC_RedirectToRouteResult(Area, Name, ActionNames.RemoveFromCart);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "cart", cart);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "productID", productID);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "returnUrl", returnUrl);
            return callInfo;
        }

        public override System.Web.Mvc.ViewResult Index(SportsStore.Domain.Entities.Cart cart, string returnUrl) {
            var callInfo = new T4MVC_ViewResult(Area, Name, ActionNames.Index);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "cart", cart);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "returnUrl", returnUrl);
            return callInfo;
        }

        public override System.Web.Mvc.ViewResult Summary(SportsStore.Domain.Entities.Cart cart) {
            var callInfo = new T4MVC_ViewResult(Area, Name, ActionNames.Summary);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "cart", cart);
            return callInfo;
        }

        public override System.Web.Mvc.ViewResult Checkout(string returnUrl, SportsStore.Domain.Entities.Cart cart) {
            var callInfo = new T4MVC_ViewResult(Area, Name, ActionNames.Checkout);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "returnUrl", returnUrl);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "cart", cart);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Checkout(string returnUrl, SportsStore.Domain.Entities.Cart cart, SportsStore.Domain.Entities.ShippingDetails shippingDetails) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Checkout);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "returnUrl", returnUrl);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "cart", cart);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "shippingDetails", shippingDetails);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591