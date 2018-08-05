using ExpressProject.TMDBWrapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpressProject.Api.Models
{
    public class MoviesViewModel : PagesInfoViewModel
    {
        public List<Movie> Movies { get; set; }
    }
}