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

        /// <summary>
        /// Gets the list of top rated movies which is refreshed daily.
        /// </summary>
        /// <param name="requestPage">Number of current page</param>
        /// <returns>Movie object JSON formated with fields: current page, total pages, 
        /// total content, 20 top rated movies of the current page</returns>
        ///
        [HttpGet]
        [Route("getTopRatedMovies")]
        public async Task<HttpResponseMessage> GetTopRatedMovies(int requestPage = 1)
        {
            var movies = await _movieApiService.GetTopRatedAsync(requestPage);

            if (movies.Error == null)
            {
                MoviesInfoViewModel moviesModel = new MoviesInfoViewModel()
                {
                    Movies = movies.Results.ToList(),
                    TotalPages = movies.TotalPages,
                    PageNumber = movies.PageNumber,
                    TotalMovies = movies.TotalResults
                };
                return Request.CreateResponse(HttpStatusCode.OK, moviesModel);
            }
            else
            {
                var message = string.Format("Error {0}: {1}", movies.Error.StatusCode, movies.Error.Message);
                return new HttpResponseMessage() { Content = new StringContent(message) };
            }
        }

        /// <summary>
        /// Gets the most recent movie that has been added to TheMovieDb.org.
        /// </summary>
        /// <returns>Movie or error with message.</returns>
        [HttpGet]
        [Route("getLatestMovie")]
        public async Task<HttpResponseMessage> GetLatestMovie()
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

        /// <summary>
        /// Searches for Movies by title.
        /// </summary>
        /// <param name="title">Title of the searching film</param>
        /// <param name="requestPage">Default is page 1. The page number to retrieve.</param>
        /// <returns><see cref="MoviesInfoViewModel"/> with movies content or error with message/></returns>
        /// 
        [HttpGet]
        [Route("getMoviesByTitle")]
        public async Task<HttpResponseMessage> GetMoviesByTitleAsync(string title, int requestPage = 1)
        {
            var movies = await _movieApiService.SearchByTitleAsync(title, requestPage);

            if (movies.Error == null)
            {
                MoviesInfoViewModel moviesModel = new MoviesInfoViewModel()
                {
                    Movies = movies.Results.ToList(),
                    TotalPages = movies.TotalPages,
                    PageNumber = movies.PageNumber,
                    TotalMovies = movies.TotalResults
                };

                return Request.CreateResponse(HttpStatusCode.OK, moviesModel);
            }
            else
            {
                var message = string.Format("Error {0}: {1}", movies.Error.StatusCode, movies.Error.Message);
                return new HttpResponseMessage() { Content = new StringContent(message) };
            }
        }

        /// <summary>
        /// Gets all the information about a specific Movie.
        /// </summary>
        /// <param name="movieId">The movie Id is typically found from a more generic Movie query.</param>
        /// <returns>movie or error with message.</returns>
        /// 
        [HttpGet]
        [Route("getMovieById")]
        public async Task<HttpResponseMessage> GetMovieById(int movieId)
        {
            var movie = await _movieApiService.FindByIdAsync(movieId);

            if (movie.Error == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, movie.Item);
            }
            else
            {
                var message = string.Format("Error {0}: {1}", movie.Error.StatusCode, movie.Error.Message);
                return new HttpResponseMessage(){ Content = new StringContent(message) };
            }
        }

        [HttpGet]
        [Route("getUpcommingMovies")]
        public async Task<HttpResponseMessage> GetUpcomingMovies(int pageNumber = 1)
        {
            var movies = await _movieApiService.GetUpcomingAsync(pageNumber);

            if (movies.Error == null)
            {
                MoviesViewModel moviesModel = new MoviesViewModel()
                {
                    Movies = movies.Results.ToList(),
                    TotalPages = movies.TotalPages,
                    PageNumber = movies.PageNumber,
                    TotalMovies = movies.TotalResults
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
        [Route("getPopularMovies")]
        public async Task<HttpResponseMessage> GetPopularMovies(int pageNumber = 1)
        {
            var movies = await _movieApiService.GetPopularAsync(pageNumber);

            if (movies.Error == null)
            {
                MoviesInfoViewModel moviesModel = new MoviesInfoViewModel()
                {
                    Movies = movies.Results.ToList(),
                    TotalPages = movies.TotalPages,
                    PageNumber = movies.PageNumber,
                    TotalMovies = movies.TotalResults
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
        [Route("getNowPlayingMovies")]
        public async Task<HttpResponseMessage> GetNowPlayingMovies(int pageNumber = 1)
        {
            var movies = await _movieApiService.GetNowPlayingAsync(pageNumber);

            if (movies.Error == null)
            {
                MoviesViewModel moviesModel = new MoviesViewModel()
                {
                    Movies = movies.Results.ToList(),
                    TotalPages = movies.TotalPages,
                    PageNumber = movies.PageNumber,
                    TotalMovies = movies.TotalResults
                };

                return Request.CreateResponse(HttpStatusCode.OK, moviesModel);
            }
            else
            {
                var message = string.Format("Error {0}: {1}", movies.Error.StatusCode, movies.Error.Message);
                return new HttpResponseMessage() { Content = new StringContent(message) };
            }
        }
    }
}
