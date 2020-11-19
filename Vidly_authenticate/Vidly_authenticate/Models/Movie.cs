using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly_authenticate.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required] 
        public string Name { get; set; }
        public Genre Genres { get; set; }
        [Display(Name = "Genre")]
        [Required] 
        public int GenresId { get; set; }
        [Display(Name = "Release Date")]
        [Required] 
        public DateTime ReleaseDate { get; set; }
        [Required] 
        public DateTime DateAdded { get; set; }
        [Display(Name = "Number in Stock")]
        [Required]
        [Range(1, 20)]
        public int inStock { get; set; }

    }
}