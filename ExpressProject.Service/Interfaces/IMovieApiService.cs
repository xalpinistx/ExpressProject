using ExpressProject.TMDBWrapper;
using ExpressProject.TMDBWrapper.ApiResponse;
using ExpressProject.TMDBWrapper.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpressProject.Service.Interfaces
{
    public interface IMovieApiService
    {
        Task<IReadOnlyList<string>> SearchAllPosterSizesAsync();

        Task<IReadOnlyList<string>> SearchAllMovieProfileSizesAsync();

        Task<ApiQueryResponse<Movie>> FindByIdAsync(int movieId, string language = "en");

        Task<ApiSearchResponse<MovieInfo>> SearchByTitleAsync(string query, int pageNumber = 1, string language = "en");

        Task<ApiQueryResponse<Movie>> SearchLatestAsync(string language = "en");

        Task<ApiSearchResponse<Movie>> SearchNowPlayingAsync(int pageNumber = 1, string language = "en");

        Task<ApiSearchResponse<Movie>> SearchUpcomingAsync(int pageNumber = 1, string language = "en");

        Task<ApiSearchResponse<MovieInfo>> SearchTopRatedAsync(int pageNumber = 1, string language = "en");

        Task<ApiSearchResponse<MovieInfo>> SearchPopularAsync(int pageNumber = 1, string language = "en");

        Task<ApiQueryResponse<MovieCredit>> SearchCreditsAsync(int movieId, string language = "en");
    }
}
