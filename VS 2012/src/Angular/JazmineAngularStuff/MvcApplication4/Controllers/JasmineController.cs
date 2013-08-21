using System;
using System.Web.Mvc;

namespace BillManager.Web.Controllers
{
    public partial class JasmineController : Controller
    {
        public virtual ViewResult Run()
        {
            return View("SpecRunner");
        }
    }
}
