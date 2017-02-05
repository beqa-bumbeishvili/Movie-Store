using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieProject.Models
{
    public class MovieCategoryViewModel
    {
        public List<Movie> Movies { get; set; }
        public List<MovieCategory> Genres { get; set; }
    }
}