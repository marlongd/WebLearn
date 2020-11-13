using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly_authenticate.Models
{
    public class Genre
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}