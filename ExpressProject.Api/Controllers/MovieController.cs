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
        public async Task<HttpResponseMessage> GetTopRatedMoviesAsync(int requestPage = 1)
        {
            var movies = await _movieApiService.SearchTopRatedAsync(requestPage);
            var posterSizes = await _movieApiService.SearchAllPosterSizesAsync();
            var profileSizes = await _movieApiService.SearchAllMovieProfileSizesAsync();

            if (movies.Error == null)
            {
                MoviesInfoViewModel moviesModel = new MoviesInfoViewModel()
                {
                    Movies = movies.Results.ToList(),
                    PosterSizes = posterSizes,
                    ProfileSizes = profileSizes,
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
        public async Task<HttpResponseMessage> GetLatestMovieAsync()
        {
            var movie = await _movieApiService.SearchLatestAsync();
            var posterSizes = await _movieApiService.SearchAllPosterSizesAsync();
            var profileSizes = await _movieApiService.SearchAllMovieProfileSizesAsync();

            if (movie.Error == null)
            {
                movie.Item.PosterPath = posterSizes.Last() + movie.Item.PosterPath;
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
            var posterSizes = await _movieApiService.SearchAllPosterSizesAsync();
            var profileSizes = await _movieApiService.SearchAllMovieProfileSizesAsync();

            if (movies.Error == null)
            {
                MoviesInfoViewModel moviesModel = new MoviesInfoViewModel()
                {
                    Movies = movies.Results.ToList(),
                    PosterSizes = posterSizes,
                    ProfileSizes = profileSizes,
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
        [Route("getMovieById/{movieId}")]
        public async Task<HttpResponseMessage> GetMovieByIdAsync(int movieId)
        {
            var movie = await _movieApiService.FindByIdAsync(movieId);
            var movieCredits = await _movieApiService.SearchCreditsAsync(movieId);
            var posterSizes = await _movieApiService.SearchAllPosterSizesAsync();
            var profileSizes = await _movieApiService.SearchAllMovieProfileSizesAsync();
            var backDropSizes = await _movieApiService.SearchAllBackDropSizesAsync();

            if (movie.Error == null)
            {
                //movie.Item.PosterPath = posterSizes.Last() + movie.Item.PosterPath;
                MovieDetailsViewModel movieDetailsModel = new MovieDetailsViewModel()
                {
                    Movie = movie.Item,
                    MovieCredit = movieCredits.Item,
                    PosterSizes = posterSizes,
                    ProfileSizes = profileSizes,
                    BackDropSizes = backDropSizes
                };

                return Request.CreateResponse(HttpStatusCode.OK, movieDetailsModel);
            }
            else
            {
                var message = string.Format("Error {0}: {1}", movie.Error.StatusCode, movie.Error.Message);
                return new HttpResponseMessage(){ Content = new StringContent(message) };
            }
        }

        [HttpGet]
        [Route("getUpcommingMovies")]
        public async Task<HttpResponseMessage> GetUpcomingMoviesAsync(int pageNumber = 1)
        {
            var movies = await _movieApiService.SearchUpcomingAsync(pageNumber);
            var posterSizes = await _movieApiService.SearchAllPosterSizesAsync();
            var profileSizes = await _movieApiService.SearchAllMovieProfileSizesAsync();

            if (movies.Error == null)
            {
                MoviesViewModel moviesModel = new MoviesViewModel()
                {
                    Movies = movies.Results.ToList(),
                    PosterSizes = posterSizes,
                    ProfileSizes = profileSizes,
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
        public async Task<HttpResponseMessage> GetPopularMoviesAsync(int pageNumber = 1)
        {
            var movies = await _movieApiService.SearchPopularAsync(pageNumber);
            var posterSizes = await _movieApiService.SearchAllPosterSizesAsync();
            var profileSizes = await _movieApiService.SearchAllMovieProfileSizesAsync();

            if (movies.Error == null)
            {
                MoviesInfoViewModel moviesModel = new MoviesInfoViewModel()
                {
                    Movies = movies.Results.ToList(),
                    PosterSizes = posterSizes,
                    ProfileSizes = profileSizes,
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
        public async Task<HttpResponseMessage> GetNowPlayingMoviesAsync(int pageNumber = 1)
        {
            var movies = await _movieApiService.SearchNowPlayingAsync(pageNumber);
            var posterSizes = await _movieApiService.SearchAllPosterSizesAsync();
            var profileSizes = await _movieApiService.SearchAllMovieProfileSizesAsync();

            if (movies.Error == null)
            {
                MoviesViewModel moviesModel = new MoviesViewModel()
                {
                    Movies = movies.Results.ToList(),
                    PosterSizes = posterSizes,
                    ProfileSizes = profileSizes,
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
        [Route("getMovieCredits")]
        public async Task<HttpResponseMessage> GetMovieCredits(int movieId)
        {
            var movieCredits = await _movieApiService.SearchCreditsAsync(movieId);
            
            if (movieCredits.Error == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, movieCredits.Item);
            }
            else
            {
                var message = string.Format("Error {0}: {1}", movieCredits.Error.StatusCode, movieCredits.Error.Message);
                return new HttpResponseMessage() { Content = new StringContent(message) };
            }
        }
    }
}
