using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Msts.Mvc.Areas.Chapter14.Controllers
{
    public class PassingDataToActionsController : Controller
    {
        //
        // GET: /Chapter14/PassingDataToActions/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PassingGetParameters(string p1, int p2)
        {
            return View((object) string.Format("p1 = {0}, p2 = {1}", p1, p2));
        }

        [HttpPost]
        [Authorize(Users = "", Roles = "")]
        [ValidateAntiForgeryToken]
        public ActionResult PassingPostParameters(string p1, int p2)
        {
            return this.View((object)string.Format("p1 = {0}, p2 = {1}", p1, p2));
        }

        [HttpPost]
        [Authorize()]
        [ValidateAntiForgeryToken]
        public ActionResult PassingPostParametersWithFormCollection(FormCollection forms)
        {
            var p1 = forms["p1"].ToString();
            var p2 = Convert.ToInt32(forms["p2"]);

            return this.View((object)string.Format("p1 = {0}, p2 = {1}", p1, p2));
        }
    }
}
