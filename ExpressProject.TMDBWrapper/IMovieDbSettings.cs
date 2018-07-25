using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressProject.TMDBWrapper
{
    public interface IMovieDbSettings
    {
        /// <summary>
        /// Private key required to query themoviedb.org API.
        /// </summary>
        string ApiKey { get; }

        /// <summary>
        /// <para>URL used for api calls to themoviedb.org.</para>
        /// <para>Current URL is: http://api.themoviedb.org/3/ </para>
        /// </summary>
        string ApiUrl { get; }
    }
}
