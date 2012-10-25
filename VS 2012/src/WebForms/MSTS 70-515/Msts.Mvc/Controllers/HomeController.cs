using Msts.Mvc.Abstract;
using Msts.Mvc.DataAccess.EFData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Msts.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private IContextResolver contextResolver;

        public HomeController(IContextResolver contextResolver)
        {
            this.contextResolver = contextResolver;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult About(string username)
        {
            return View((object)username);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CallWcfRestService()
        {
            return View();
        }

        public ActionResult CallWcfRestCrossDomainService()
        {
            return this.View();
        }

        public ActionResult CallWcfRestDataService()
        {
            return this.View();
        }

        public ActionResult CallWcfRestDataCrossDomainService()
        {
            return View();
        }

        public ActionResult RaiseException()
        {
            throw new NotImplementedException();
        }

        public ActionResult HandledException()
        {
            throw new InvalidOperationException();
        }

        public ActionResult SimpleData()
        {
            var ctx = this.contextResolver.GetCurrentContext<pubsEntities>();

            return View(ctx.jobs);
        }
    }
}
