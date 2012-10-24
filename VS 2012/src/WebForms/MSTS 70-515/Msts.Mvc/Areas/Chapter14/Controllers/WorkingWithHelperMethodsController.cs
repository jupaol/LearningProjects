using FizzWare.NBuilder;
using Msts.Mvc.Areas.Chapter14.Models;
using Msts.Mvc.DataAccess.EFData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Msts.Mvc.Areas.Chapter14.Controllers
{
    public class WorkingWithHelperMethodsController : Controller
    {
        //
        // GET: /Chapter14/WorkingWithHelperMethods/

        [HttpGet]
        public ActionResult Index()
        {
            var context = new pubsEntities();
            var model = new HelperMethodsModel
            {
                IsAccepted = true, 
                Jobs = context.jobs.AsEnumerable(),
                ID = 18
            };

            return View(model);
        }

        [ChildActionOnly]
        public PartialViewResult RenderComponent()
        {
            return this.PartialView();
        }

        [HttpPost]
        public ActionResult PrcessForm(HelperMethodsModel model)
        {
            return View(model);
        }

        public ActionResult CheckingValidation()
        {
            var context = new pubsEntities();
            var model = new HelperMethodsModel
            {
                IsAccepted = true,
                Jobs = context.jobs.AsEnumerable(),
                ID = 18
            };

            if (!this.ModelState.IsValid)
            {

            }

            return View(model);
        }

        [HttpGet]
        public ActionResult ScaffoldTheModel()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ScaffoldTheModel(HelperMethodsModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            return this.RedirectToAction("ScaffoldTheModel");
        }

        [HttpGet]
        public ActionResult ScaffoldTheModelReadOnly()
        {
            var model = Builder<HelperMethodsModel>.CreateNew().Build();

            return View(model);
        }
    }
}
