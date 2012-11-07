using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitTestQueries.Logic;

namespace UnitTestQueries.UI.Controllers
{
    public class MoviesController : Controller
    {
        private IMovieQueryManager movieQueryManager;

        public MoviesController(IMovieQueryManager movieQueryManager)
        {
            this.movieQueryManager = movieQueryManager;
        }

        public ActionResult Index()
        {
            return View(this.movieQueryManager.FindAll());
        }

    }
}
