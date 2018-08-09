using ExpressProject.TMDBWrapper.ApiRequest.Genres;
using ExpressProject.TMDBWrapper.ApiResponse;
using ExpressProject.TMDBWrapper.Configuration;
using ExpressProject.TMDBWrapper.Models;
using ExpressProject.TMDBWrapper.Shims;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressProject.TMDBWrapper.ApiRequest.Movies
{
    internal class ApiMovieRequest : ApiRequestBase, IApiMovieRequest
    {
        private readonly IApiGenreRequest _genreApi;
        private readonly IMovieDbSettings _settings;

        [ImportingConstructor]
        public ApiMovieRequest(IMovieDbSettings settings , IApiGenreRequest genreApi)
            : base(settings)
        {
            _genreApi = genreApi;
            _settings = settings;
        }

        protected async Task<ApiConfiguration> GetConfigurationAsync(IMovieDbSettings settings)
        {
            var configResponse = await new ApiConfigurationRequest(settings).GetAsync();
            ApiConfiguration config = new ApiConfiguration();
            config = JsonConvert.DeserializeObject<ApiConfiguration>(configResponse.Json, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });  

            return config;
        }

        public async Task<IReadOnlyList<string>> GetAllMoviePosterSizesAsync()
        {
            var config = await GetConfigurationAsync(_settings);

            IReadOnlyList<string> images = config.Images.Posters.Select(imageSize => { imageSize = config.Images.SecureRootUrl + imageSize; return imageSize; }).ToList();

            return images;
        }

        public async Task<IReadOnlyList<string>> GetAllMovieProfileSizesAsync()
        {
            var config = await GetConfigurationAsync(_settings);

            IReadOnlyList<string> images = config.Images.Profiles.Select(imageSize => { imageSize = config.Images.SecureRootUrl + imageSize; return imageSize; }).ToList();

            return images;
        }

        public async Task<ApiQueryResponse<Movie>> FindByIdAsync(int movieId, string language = "en")
        {
            var param = new Dictionary<string, string>
            {
                {"language", language},
                {"append_to_response", "keywords"},
            };

            string command = $"movie/{movieId}";

            ApiQueryResponse<Movie> response = await base.QueryAsync<Movie>(command, param);

            //var config = await GetConfiguration(_settings);
            //var baseImageUrl = string.Format("{0}{1}", config.Images.SecureRootUrl, config.Images.Posters.Last());

            //response.Item.PosterPath = baseImageUrl + response.Item.PosterPath;

            return response;
        }

        public async Task<ApiSearchResponse<MovieInfo>> SearchByTitleAsync(string query, int pageNumber = 1, string language = "en")
        {
            var param = new Dictionary<string, string>
            {
                {"query", query},
                {"include_adult", "false"},
                {"language", language},
            };

            const string command = "search/movie";

            ApiSearchResponse<MovieInfo> response = await base.SearchAsync<MovieInfo>(command, pageNumber, param);

            //var config = await GetConfiguration(_settings);
            //var baseImageUrl = string.Format("{0}{1}", config.Images.SecureRootUrl, config.Images.Posters.Last());

            //response.Results.All(movie => { movie.PosterPath = baseImageUrl + movie.PosterPath; return true; });

            if (response.Error != null)
            {
                return response;
            }

            response.Results.PopulateGenres(_genreApi);

            return response;
        }

        public async Task<ApiQueryResponse<Movie>> GetLatestAsync(string language = "en")
        {
            var param = new Dictionary<string, string>
            {
                {"language", language},
                {"append_to_response", "keywords"},
            };

            const string command = "movie/latest";

            ApiQueryResponse<Movie> response = await base.QueryAsync<Movie>(command, param);

            //var config = await GetConfiguration(_settings);
            //var baseImageUrl = string.Format("{0}{1}", config.Images.SecureRootUrl, config.Images.Posters.Last());

            //response.Item.PosterPath = baseImageUrl + response.Item.PosterPath;

            return response;
        }

        public async Task<ApiSearchResponse<Movie>> GetNowPlayingAsync(int pageNumber = 1, string language = "en")
        {
            var param = new Dictionary<string, string>
            {
                {"language", language},
                {"append_to_response", "keywords"},
            };

            const string command = "movie/now_playing";

            ApiSearchResponse<Movie> response = await base.SearchAsync<Movie>(command, pageNumber, param);

            //var config = await GetConfiguration(_settings);
            //var baseImageUrl = string.Format("{0}{1}", config.Images.SecureRootUrl, config.Images.Posters.Last());

            //response.Results.All(movie => { movie.PosterPath = baseImageUrl + movie.PosterPath; return true; });

            return response;
        }

        public async Task<ApiSearchResponse<Movie>> GetUpcomingAsync(int pageNumber = 1, string language = "en")
        {
            var param = new Dictionary<string, string>
            {
                {"language", language},
                {"append_to_response", "keywords"},
            };

            const string command = "movie/upcoming";

            ApiSearchResponse<Movie> response = await base.SearchAsync<Movie>(command, pageNumber, param);

            //var config = await GetConfiguration(_settings);
            //var baseImageUrl = string.Format("{0}{1}", config.Images.SecureRootUrl, config.Images.Posters.Last());

            //response.Results.All(movie => { movie.PosterPath = baseImageUrl + movie.PosterPath; return true; });

            return response;
        }

        public async Task<ApiSearchResponse<MovieInfo>> GetTopRatedAsync(int pageNumber = 1, string language = "en")
        {
            var param = new Dictionary<string, string>
            {
                {"language", language},
            };

            const string command = "movie/top_rated";

            ApiSearchResponse<MovieInfo> response = await base.SearchAsync<MovieInfo>(command, pageNumber, param);

            //var config = await GetConfiguration(_settings);
            //var baseImageUrl = string.Format("{0}{1}", config.Images.SecureRootUrl, config.Images.Posters.Last());

            //response.Results.All(movie => { movie.PosterPath = baseImageUrl + movie.PosterPath; return true; });

            if (response.Error != null)
            {
                return response;
            }

            response.Results.PopulateGenres(_genreApi);

            return response;
        }

        public async Task<ApiSearchResponse<MovieInfo>> GetPopularAsync(int pageNumber = 1, string language = "en")
        {
            var param = new Dictionary<string, string>
            {
                {"language", language},
            };

            const string command = "movie/popular";

            ApiSearchResponse<MovieInfo> response = await base.SearchAsync<MovieInfo>(command, pageNumber, param);

            //var config = await GetConfiguration(_settings);
            //var baseImageUrl = string.Format("{0}{1}", config.Images.SecureRootUrl, config.Images.Posters.Last());

            //response.Results.All(movie => { movie.PosterPath = baseImageUrl + movie.PosterPath; return true; });

            if (response.Error != null)
            {
                return response;
            }

            response.Results.PopulateGenres(_genreApi);

            return response;
        }

        public async Task<ApiQueryResponse<MovieCredit>> GetCreditsAsync(int movieId, string language = "en")
        {
            var param = new Dictionary<string, string>
            {
                {"language", language},
            };

            string command = $"movie/{movieId}/credits";

            ApiQueryResponse<MovieCredit> response = await base.QueryAsync<MovieCredit>(command, param);

            return response;
        }
    }
}
