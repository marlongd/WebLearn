using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly_authenticate.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Genre Genres { get; set; }
        public int GenresId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        public int inStock { get; set; }

    }
}