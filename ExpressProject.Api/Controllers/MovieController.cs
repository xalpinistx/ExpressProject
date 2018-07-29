using ExpressProject.Api.Models;
using ExpressProject.Service.Interfaces;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ExpressProject.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("movie")]
    public class MovieController : ApiController
    {
        IMovieService _movieService { get; }
        IMovieApiService _movieApiService { get; }

        public MovieController()
        {

        }

        public MovieController(IMovieService movieService, IMovieApiService movieApiService)
        {
            _movieService = movieService;
            _movieApiService = movieApiService;
        }

        [HttpGet]
        [Route("getTopRatedMovies")]
        public async Task<HttpResponseMessage> GetTopRatedMovies(int requestPage = 1)
        {
            var movies = await _movieApiService.GetTopRatedAsync(requestPage);

            if (movies.Error == null)
            {
                MoviesViewModel moviesModel = new MoviesViewModel()
                {
                    Movies = movies.Results.ToList(),
                    TotalPages = movies.TotalPages,
                    PageNumber = movies.PageNumber,
                    TotalTopRatedMovies = movies.TotalResults
                };

                return Request.CreateResponse(HttpStatusCode.OK, moviesModel);
            }
            else
            {
                var message = string.Format("Error {0}: {1}", movies.Error.StatusCode, movies.Error.Message);
                return new HttpResponseMessage() { Content = new StringContent(message) };
            }
        }

        [HttpGet]
        [Route("getLatestMovies")]
        public async Task<HttpResponseMessage> GetLatestMovies()
        {
            var movie = await _movieApiService.GetLatestAsync();

            if (movie.Error == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, movie.Item);
            }
            else
            {
                var message = string.Format("Error {0}: {1}", movie.Error.StatusCode, movie.Error.Message);
                return new HttpResponseMessage() { Content = new StringContent(message) };
            }
        }

        [HttpGet]
        [Route("getMovieByTitle")]
        public async Task<HttpResponseMessage> GetMovieByTitleAsync(string title, int requestPage = 1)
        {
            var movies = await _movieApiService.SearchByTitleAsync(title, requestPage);

            if (movies.Error == null)
            {
                MoviesViewModel moviesModel = new MoviesViewModel()
                {
                    Movies = movies.Results.ToList(),
                    TotalPages = movies.TotalPages,
                    PageNumber = movies.PageNumber,
                    TotalTopRatedMovies = movies.TotalResults
                };

                return Request.CreateResponse(HttpStatusCode.OK, moviesModel);
            }
            else
            {
                var message = string.Format("Error {0}: {1}", movies.Error.StatusCode, movies.Error.Message);
                return new HttpResponseMessage() { Content = new StringContent(message) };
            }
        }

        [HttpGet]
        [Route("getMovieById")]
        public async Task<HttpResponseMessage> GetMovieById(int movieId)
        {
            var movie = await _movieApiService.FindByIdAsync(movieId);

            if (movie.Error == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, movie.Json);
            }
            else
            {
                var message = string.Format("Error {0}: {1}", movie.Error.StatusCode, movie.Error.Message);
                return new HttpResponseMessage(){ Content = new StringContent(message) };
            }
        }
    }
}
