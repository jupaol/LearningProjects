using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Msts.Mvc.Areas.Movies.Models;
using Msts.Mvc.DataAccess;
using Msts.Mvc.Abstract;

namespace Msts.Mvc.Areas.Movies.Controllers
{
    public class MoviesController : Controller
    {
        private MovieContext db;

        public MoviesController(IContextResolver contextResolver)
        {
            this.db = contextResolver.GetCurrentContext<MovieContext>();
        }

        //
        // GET: /Movies/Movies/

        public ActionResult Index()
        {
            return View(db.Movies.ToList());
        }

        //
        // GET: /Movies/Movies/Details/5

        public ActionResult Details(int id = 0)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        //
        // GET: /Movies/Movies/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Movies/Movies/Create

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        //
        // GET: /Movies/Movies/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        //
        // POST: /Movies/Movies/Edit/5

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        //
        // GET: /Movies/Movies/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        //
        // POST: /Movies/Movies/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SearchIndex(string genre, string searchCriteria)
        {
            var movies = this.db.Movies.AsQueryable();

            var genres = this.db.Movies.AsQueryable().Select(x => x.Genre).Distinct();

            this.ViewBag.Genres = genres;

            if (!string.IsNullOrWhiteSpace(searchCriteria))
            {
                movies = movies.Where(x => x.Title.Contains(searchCriteria));
            }

            if (!string.IsNullOrWhiteSpace(genre))
            {
                movies = movies.Where(x => x.Genre.Contains(genre));
            }

            return this.View(movies);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}