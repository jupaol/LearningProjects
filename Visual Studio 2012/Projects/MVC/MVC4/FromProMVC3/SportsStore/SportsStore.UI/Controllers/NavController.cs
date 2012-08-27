using SportsStore.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.UI.Controllers
{
    public partial class NavController : Controller
    {
        private IProductRepository repository;

        public NavController(IProductRepository repository)
        {
            this.repository = repository;
        }

        public virtual ActionResult Menu(string category = "")
        {
            var categories = from p in this.repository.GetProducts()
                             group p by p.Category into grouped
                             select grouped.Key;

            this.ViewBag.CurrentCategory = category;

            return View(categories.AsEnumerable());
        }
    }
}
