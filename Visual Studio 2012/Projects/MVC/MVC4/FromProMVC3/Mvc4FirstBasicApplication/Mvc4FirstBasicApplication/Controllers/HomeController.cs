using Mvc4FirstBasicApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Mvc4FirstBasicApplication.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ViewResult Index()
        {
            var greeting = DateTime.Now.Hour >= 12 ? "Good afternoon" : "Good morning";

            this.ViewBag.Greeting = greeting;

            return View();
        }

        [HttpGet]
        [OutputCache(Duration = -1, Location = OutputCacheLocation.None, NoStore = true, VaryByParam = "none")]
        public ViewResult Register()
        {
            HttpContext.Response.Expires = -1;
            HttpContext.Response.Cache.SetNoServerCaching();
            HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Response.Cache.SetAllowResponseInBrowserHistory(false);
            HttpContext.Response.CacheControl = "no-cache";
            HttpContext.Response.Cache.SetNoStore();

            return View();
        }

        [HttpPost]
        [OutputCache(Duration = -1, Location = OutputCacheLocation.None, NoStore = true, VaryByParam = "none")]
        public ActionResult Register(RegisterModel model)
        {
            HttpContext.Response.Expires = -1;
            HttpContext.Response.Cache.SetNoServerCaching();
            HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Response.Cache.SetAllowResponseInBrowserHistory(false);
            HttpContext.Response.CacheControl = "no-cache";
            HttpContext.Response.Cache.SetNoStore();

            if (!this.ModelState.IsValid)
            {
                return View();
            }

            this.Session["m"] = model;

            return RedirectToAction("Thanks", new { id = 4 });
        }

        [OutputCache(Duration = -1, Location = OutputCacheLocation.None, NoStore = true, VaryByParam = "none")]
        public ActionResult Thanks(int id)
        {
            HttpContext.Response.Expires = -1;
            HttpContext.Response.Cache.SetNoServerCaching();
            HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Response.Cache.SetAllowResponseInBrowserHistory(false);
            HttpContext.Response.CacheControl = "no-cache";
            HttpContext.Response.Cache.SetNoStore();

            return View(this.Session["m"] as RegisterModel);
        }
    }
}
