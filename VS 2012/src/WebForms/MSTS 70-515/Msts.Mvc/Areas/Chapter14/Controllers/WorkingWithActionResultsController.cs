using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Msts.Mvc.Areas.Chapter14.Controllers
{
    public class WorkingWithActionResultsController : Controller
    {
        public ActionResult Index()
        {
            return View((object)"Initial value from Action");
        }

        public ViewResult SimpleViewResult()
        {
            return this.View();
        }

        [ChildActionOnly]
        public PartialViewResult SimplePartialViewResult()
        {
            return this.PartialView("Menu");
        }

        public RedirectResult SimpleRedirectResult()
        {
            return this.Redirect("~/");
        }

        public RedirectToRouteResult SimpleRedirectToRouteResult()
        {
            this.TempData["SimpleRedirectToRouteResult"] = string.Format("Processed at: {0}", DateTime.Now);

            return this.RedirectToAction("SimpleViewResult");
        }

        public RedirectToRouteResult SimpleRedirectToRouteResultWithRedirectToRoute()
        {
            this.TempData["SimpleRedirectToRouteResultWithRedirectToRoute"] = string.Format("Processed at: {0} using: RedirectToRoute", DateTime.Now);

            return this.RedirectToRoute("Chapter14_default", new
            {
                controller = "WorkingWithActionResults",
                action = "SimpleViewResult"
            });
        }

        public ContentResult SimpleContentResult()
        {
            var xml = new XElement("Info", new XElement("Message", "Hello World"));

            return this.Content(xml.ToString(), "application/xml");
        }

        [HttpGet]
        public JsonResult SimpleJsonResult()
        {
            return this.Json(Enumerable.Range(1, 10), JsonRequestBehavior.AllowGet);
        }

        public JavaScriptResult SimpleJavaScriptResult()
        {
            return this.JavaScript("alert('hello world from MVC action');");
        }

        public FileResult SimpleFileResult()
        {
            return this.File(this.Server.MapPath("~/Images/orderedList8.png"), "image/png");
        }
    }
}
