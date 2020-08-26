using System;
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
        // GET: Customer
        public ActionResult Index()
        {
            var Customers =  getCustomers();

            return View(Customers);
        }

        public ActionResult Details(int id)
        {
            var customer = getCustomers().SingleOrDefault(x => x.Id == id);
            if (customer == null) { return HttpNotFound(); }
            else {return View(customer); }
        }

        private IEnumerable<Customer> getCustomers()
        {
            List<Customer> customers = new List<Customer>
            {
                new Customer {Id = 1, Name = "Customer 1"},
                new Customer {Id = 2, Name = "Customer 2"}
            };

            return customers;
        }
    }
}