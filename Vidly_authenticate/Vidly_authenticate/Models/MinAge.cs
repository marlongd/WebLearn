using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly_authenticate.Models
{
    public class MinAge : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if(customer.MembershipTypeId == 1)
            {
                return ValidationResult.Success;
            }
            if(customer.birthDate == null)
            {
                return new ValidationResult("Birthdate is required.");
            }
            var age = DateTime.Today.Year - customer.birthDate.Value.Year;

            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Customer needs to be at least 18");
            
        }
    }
}