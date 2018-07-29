using ExpressProject.TMDBWrapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpressProject.Api.Models
{
    public class MoviesViewModel
    {
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public int TotalTopRatedMovies { get; set; }
        public List<MovieInfo> Movies { get; set; }
    }
}