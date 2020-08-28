using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly_authenticate.Models
{
    public class MembershipType
    {
        public int SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
        public byte Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}