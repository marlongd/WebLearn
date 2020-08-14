using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie/Random
        public ActionResult Random()
        {
            Movie movie = new Movie() { Name = "Shrek" };
            return View(movie);
            //return Content("HELLO WORLD");
            //return RedirectToAction("Index");
            
        }

        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year +"/" + month);
        }
    }

    
}