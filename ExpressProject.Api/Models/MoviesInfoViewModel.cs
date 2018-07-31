using ExpressProject.TMDBWrapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpressProject.Api.Models
{
    public class MoviesInfoViewModel : PagesInfoViewModel
    {
        public List<MovieInfo> Movies { get; set; }
    }
}