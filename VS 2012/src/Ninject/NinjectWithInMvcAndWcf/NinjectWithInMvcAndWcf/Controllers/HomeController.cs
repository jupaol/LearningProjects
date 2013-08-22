using System;
using System.ServiceModel;
using System.Web.Mvc;
using NinjectShared;
using NinjectWithInMvcAndWcf.Data;
using NinjectWithInMvcAndWcf.Services;

namespace NinjectWithInMvcAndWcf.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContextResolver _contextResolver;
        private readonly MyDataContext _myDataContext;

        public HomeController(IContextResolver contextResolver, MyDataContext myDataContext)
        {
            _contextResolver = contextResolver;
            _myDataContext = myDataContext;
        }

        public ActionResult Index()
        {
            if (_myDataContext == null)
            {
                throw new ArgumentNullException("_myDataContext");
            }

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
            ViewBag.ContextHash = _myDataContext.GetHashCode();

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
