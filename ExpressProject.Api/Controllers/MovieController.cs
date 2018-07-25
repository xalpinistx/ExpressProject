using ExpressProject.Service.Interfaces;
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
        public async Task<IHttpActionResult> GetTopRatedMovies(int requestPage = 1)
        {
            int totalPages;

            var movies = await _movieApiService.GetTopRatedAsync(requestPage);
            totalPages = movies.TotalPages;

            if (movies != null)
            {
                return Ok(movies.Json);
            }

            return NotFound();
        }

        [HttpGet]
        [Route("getLatestMovies")]
        public async Task<IHttpActionResult> GetLatestMovies()
        {
            var movies = await _movieApiService.GetLatestAsync();

            if (movies != null)
                return Ok(movies.Json);

            return NotFound();
        }

        [HttpGet]
        [Route("getMovieByTitle")]
        public async Task<IHttpActionResult> GetMovieByTitleAsync(int requestPage = 1)
        {
            int totalPages;

            var movies = await _movieApiService.SearchByTitleAsync("Star Wars", requestPage);
            totalPages = movies.TotalPages;

            if (movies != null)
                return Ok(movies.Json);

            return NotFound();
        }

        [HttpGet]
        [Route("getMovieById")]
        public async Task<IHttpActionResult> GetMovieById(int movieId)
        {
            var movie = await _movieApiService.FindByIdAsync(movieId);

            if (movie != null)
                return Ok(movie.Json);

            return NotFound();
        }
    }
}
