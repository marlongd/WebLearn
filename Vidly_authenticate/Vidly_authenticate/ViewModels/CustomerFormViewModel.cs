using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly_authenticate.Models;

namespace Vidly_authenticate.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}