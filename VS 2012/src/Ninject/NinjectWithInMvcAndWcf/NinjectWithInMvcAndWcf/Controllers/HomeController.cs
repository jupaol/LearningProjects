using System.ServiceModel;
using System.Web.Mvc;
using NinjectShared;
using NinjectWithInMvcAndWcf.Services;

namespace NinjectWithInMvcAndWcf.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContextResolver _contextResolver;

        public HomeController(IContextResolver contextResolver)
        {
            _contextResolver = contextResolver;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            var res = _contextResolver.Resolve();
            string resFromWcf;

            using (var channelFactory = new ChannelFactory<ILoggingService>("MyLoggingServiceEndPoint"))
            {
                var proxy = channelFactory.CreateChannel();

                resFromWcf = proxy.DoWork();
            }

            ViewBag.FromSimpleService = res;
            ViewBag.FromWcfService = resFromWcf;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
