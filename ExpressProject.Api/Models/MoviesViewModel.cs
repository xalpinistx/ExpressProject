using ExpressProject.TMDBWrapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpressProject.Api.Models
{
    public class MoviesViewModel : PagesInfo
    {
        public IReadOnlyList<string> PosterSizes { get; set; }
        public IReadOnlyList<string> LogoSizes { get; set; }
        public IReadOnlyList<string> ProfileSizes { get; set; }
        public IReadOnlyList<string> BackdropSizes { get; set; }
        
        public List<Movie> Movies { get; set; }
    }
}