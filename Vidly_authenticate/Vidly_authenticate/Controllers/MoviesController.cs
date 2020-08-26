using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.MappingViews;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly_authenticate.Models;

namespace Vidly_authenticate.Controllers
{
    public class MoviesController : Controller
    {
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
            var movie = getMovies();
            return View(movie);
        }

        public ActionResult Details(int id)
        {
            var movie = getMovies().SingleOrDefault(x => x.Id == id);
            if (movie == null) { return HttpNotFound(); }
            else { return View(movie); }
        }

        [Route("movies/released/{year}/{month:regex(\\d{4})}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        private IEnumerable<Movie> getMovies()
        {
            List<Movie> movies = new List<Movie>
            {
                new Movie {Id = 1, Name = "SHREK"},
                new Movie {Id = 2, Name = "WALL-e"}
            };

            return movies;
        }
    }
}