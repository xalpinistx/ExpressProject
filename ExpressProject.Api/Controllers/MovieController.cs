using ExpressProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExpressProject.Api.Controllers
{
    [RoutePrefix("movie")]
    public class MovieController : ApiController
    {
        IMovieService _movieService { get; }

        public MovieController()
        {

        }

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        [Route("getMovies")]
        public IHttpActionResult GetMovies()
        {
            var allMovies = _movieService.GetAllMovies();

            if (allMovies != null)
                return Ok(allMovies);

            return NotFound();
        }
    }
}
