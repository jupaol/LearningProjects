using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Msts.Mvc.Areas.Chapter14.Controllers
{
    public class CachingController : Controller
    {
        //
        // GET: /Chapter14/Caching/

        [OutputCache(
            Duration = 15,
            VaryByParam = "none")]
        public ActionResult Index()
        {
            return View();
        }

    }
}
