using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly_authenticate.Models;
using Vidly_authenticate.ViewModels;

namespace Vidly_authenticate.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customer
        public ActionResult Index()
        {
            var Customers =  _context.Customers.Include(c => c.MembershipType).ToList();

            return View(Customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(x => x.Id == id);
            if (customer == null) { return HttpNotFound(); }
            else {return View(customer); }
        }

    }
}