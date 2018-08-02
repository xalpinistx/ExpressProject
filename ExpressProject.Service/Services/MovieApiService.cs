using ExpressProject.Service.Interfaces;
using ExpressProject.TMDBWrapper;
using ExpressProject.TMDBWrapper.ApiRequest.Movies;
using ExpressProject.TMDBWrapper.ApiResponse;
using ExpressProject.TMDBWrapper.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressProject.Service.Services
{
    public class MovieApiService : IMovieApiService
    {
        private IApiMovieRequest _movieApi;

        public MovieApiService()
        {
            MovieDbFactory.RegisterSettings("0d8749296f94805bd6859aa9d2ec3644");
            _movieApi = MovieDbFactory.Create<IApiMovieRequest>().Value;
        }

        public async Task<IReadOnlyList<string>> GetAllPosterSizesAsync()
        {
            var images = await _movieApi.GetAllMoviePosterSizesAsync();

            return images;
        }

        public async Task<ApiQueryResponse<Movie>> FindByIdAsync(int movieId, string language = "en")
        {
            ApiQueryResponse<Movie> response = await _movieApi.FindByIdAsync(movieId, language);

            return response;
        }

        public async Task<ApiQueryResponse<Movie>> SearchLatestAsync(string language = "en")
        {
            ApiQueryResponse<Movie> response = await _movieApi.GetLatestAsync(language);

            return response;
        }

        public async Task<ApiSearchResponse<Movie>> SearchNowPlayingAsync(int pageNumber = 1, string language = "en")
        {
            ApiSearchResponse<Movie> response = await _movieApi.GetNowPlayingAsync(pageNumber, language);

            return response;
        }

        public async Task<ApiSearchResponse<MovieInfo>> SearchPopularAsync(int pageNumber = 1, string language = "en")
        {
            ApiSearchResponse<MovieInfo> response = await _movieApi.GetPopularAsync(pageNumber, language);

            return response;
        }

        public async Task<ApiSearchResponse<MovieInfo>> SearchTopRatedAsync(int pageNumber = 1, string language = "en")
        {
            ApiSearchResponse<MovieInfo> response = await _movieApi.GetTopRatedAsync(pageNumber, language);

            return response;
        }

        public async Task<ApiSearchResponse<Movie>> SearchUpcomingAsync(int pageNumber = 1, string language = "en")
        {
            ApiSearchResponse<Movie> response = await _movieApi.GetUpcomingAsync(pageNumber, language);

            return response;
        }

        public async Task<ApiSearchResponse<MovieInfo>> SearchByTitleAsync(string query, int pageNumber = 1, string language = "en")
        {
            ApiSearchResponse<MovieInfo> response = await _movieApi.SearchByTitleAsync(query, pageNumber, language);

            return response;
        }

        public async Task<ApiQueryResponse<MovieCredit>> SearchCreditsAsync(int movieId, string language = "en")
        {
            ApiQueryResponse<MovieCredit> response = await _movieApi.GetCreditsAsync(movieId, language);

            return response;
        }
    }
}
