using ExpressProject.TMDBWrapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpressProject.Api.Models
{
    public class MoviesInfoViewModel : PagesInfo
    {
        public IReadOnlyList<string> PosterSizes { get; set; }
        public IReadOnlyList<string> LogoSizes { get; set; }
        public IReadOnlyList<string> ProfileSizes { get; set; }
        public IReadOnlyList<string> BackdropSizes { get; set; }

        public List<MovieCredit> MovieCredits { get; set; }

        public List<MovieInfo> Movies { get; set; }
    }
}