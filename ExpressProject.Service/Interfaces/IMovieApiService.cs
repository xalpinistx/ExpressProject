using ExpressProject.TMDBWrapper.ApiResponse;
using ExpressProject.TMDBWrapper.Models;
using System.Threading.Tasks;

namespace ExpressProject.Service.Interfaces
{
    public interface IMovieApiService
    {
        Task<ApiQueryResponse<Movie>> FindByIdAsync(int movieId, string language = "en");

        Task<ApiSearchResponse<MovieInfo>> SearchByTitleAsync(string query, int pageNumber = 1, string language = "en");

        Task<ApiQueryResponse<Movie>> GetLatestAsync(string language = "en");

        Task<ApiSearchResponse<Movie>> GetNowPlayingAsync(int pageNumber = 1, string language = "en");

        Task<ApiSearchResponse<Movie>> GetUpcomingAsync(int pageNumber = 1, string language = "en");

        Task<ApiSearchResponse<MovieInfo>> GetTopRatedAsync(int pageNumber = 1, string language = "en");

        Task<ApiSearchResponse<MovieInfo>> GetPopularAsync(int pageNumber = 1, string language = "en");

        //Task<ApiQueryResponse<MovieCredit>> GetCreditsAsync(int movieId, string language = "en");
    }
}
