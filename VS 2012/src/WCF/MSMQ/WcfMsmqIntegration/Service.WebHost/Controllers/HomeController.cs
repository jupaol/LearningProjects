using System.Web.Mvc;

namespace Service.WebHost.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RestWcfService()
        {
            return View();
        }
    }
}
