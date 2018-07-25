using ExpressProject.TMDBWrapper.ApiRequest;
using ExpressProject.TMDBWrapper.ApiResponse;
using ExpressProject.TMDBWrapper.Shims;
using System.Threading.Tasks;

namespace ExpressProject.TMDBWrapper.Configuration
{
    class ApiConfigurationRequest : ApiRequestBase, IApiConfigurationRequest
    {
        [ImportingConstructor]
        public ApiConfigurationRequest(IMovieDbSettings settings)
            : base(settings)
        { }

        public async Task<ApiQueryResponse<ApiConfiguration>> GetAsync()
        {
            ApiQueryResponse<ApiConfiguration> response = await base.QueryAsync<ApiConfiguration>("configuration");

            return response;
        }
    }
}
