using SportsStore.UI.BootstrapInitialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.UI.Controllers
{
    public class HomeController : Controller
    {
        private IForTesting forTesting;

        public HomeController(IForTesting forTesting)
        {
            this.forTesting = forTesting;
        }

        public ActionResult Index()
        {
            this.ViewBag.Message = this.forTesting.GetMessage();

            return View();
        }
    }
}
