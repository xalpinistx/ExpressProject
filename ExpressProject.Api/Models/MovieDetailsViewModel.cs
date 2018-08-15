using ExpressProject.TMDBWrapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpressProject.Api.Models
{
    public class MovieDetailsViewModel
    {
        public IReadOnlyList<string> PosterSizes { get; set; }
        public IReadOnlyList<string> LogoSizes { get; set; }
        public IReadOnlyList<string> ProfileSizes { get; set; }
        public IReadOnlyList<string> BackDropSizes { get; set; }

        public MovieCredit MovieCredit { get; set; }

        public Movie Movie { get; set; }
    }
}