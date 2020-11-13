using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.MappingViews;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly_authenticate.Models;
using System.Data.Entity;

namespace Vidly_authenticate.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            return View(movie);
            
        }

        public ActionResult Edit(int id)
        {
            return Content("id:" + id);
        }
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            var movies = _context.Movies.Include(c => c.Genres).ToList();

            return View(movies);
            
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(c => c.Genres).SingleOrDefault(x => x.Id == id);
            if (movie == null) { return HttpNotFound(); }
            else { return View(movie); }
        }

        [Route("movies/released/{year}/{month:regex(\\d{4})}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

    }
}