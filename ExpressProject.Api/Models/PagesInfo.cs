using ExpressProject.TMDBWrapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpressProject.Api.Models
{
    public class PagesInfo
    {
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public int TotalMovies { get; set; }
    }
}