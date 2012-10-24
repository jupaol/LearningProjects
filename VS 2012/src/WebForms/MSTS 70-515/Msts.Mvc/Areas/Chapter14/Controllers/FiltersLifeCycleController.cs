using Msts.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Msts.Mvc.Areas.Chapter14.Controllers
{
    public class FiltersLifeCycleController : Controller
    {
        //
        // GET: /Chapter14/FiltersLifeCycle/

        [FilterLifeCycle]
        public ActionResult Index()
        {
            return View();
        }

    }
}
