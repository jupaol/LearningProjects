using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitTestQueries.Logic;

namespace UnitTestQueries.UI.Controllers
{
    public partial class MoviesController : Controller
    {
        private IMovieQueryManager movieQueryManager;

        public MoviesController(IMovieQueryManager movieQueryManager)
        {
            this.movieQueryManager = movieQueryManager;
        }

        public virtual ActionResult Index(string titleFilter = "")
        {
            if (string.IsNullOrWhiteSpace(titleFilter))
            {
                return View(this.movieQueryManager.FindAll());
            }
            else
            {
                var query = new FindMoviesByTitleQuery(titleFilter);

                return View(this.movieQueryManager.HandleQuery(query));
            }
        }

        public virtual ActionResult Details(Guid id)
        {
            var movie = this.movieQueryManager.FindByID(new MovieID(id));

            if (movie == null)
            {
                return new HttpNotFoundResult();
            }

            return View(movie);
        }

    }
}
