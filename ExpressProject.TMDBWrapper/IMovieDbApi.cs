﻿using ExpressProject.TMDBWrapper.ApiRequest;
using ExpressProject.TMDBWrapper.ApiRequest.Genres;
using ExpressProject.TMDBWrapper.ApiRequest.Movies;
using ExpressProject.TMDBWrapper.Configuration;

namespace ExpressProject.TMDBWrapper
{
    /// <summary>
    /// Global interface exposing all API interfaces against themoviedb.org that are
    /// currently available in this release.
    /// </summary>
    public interface IMovieDbApi
    {
        /// <summary>
        /// Provides access for retrieving production company information.
        /// </summary>
        //IApiCompanyRequest Companies { get; }

        /// <summary>
        /// Provides access for retrieving themoviedb.org configuration information.
        /// </summary>
        IApiConfigurationRequest Configuration { get; }

        /// <summary>
        /// Provides access for retrieving Movie and TV genres.
        /// </summary>
        IApiGenreRequest Genres { get; }

        /// <summary>
        /// Provides access for retrieving information about Movie/TV industry specific professions.
        /// </summary>
        //IApiProfessionRequest IndustryProfessions { get; }

        /// <summary>
        /// Provides access for retrieving information about Movies.
        /// </summary>
        IApiMovieRequest Movies { get; }

        /// <summary>
        /// Provides access for retrieving movie rating information.
        /// </summary>
        //IApiMovieRatingRequest MovieRatings { get; }

        /// <summary>
        /// Provides access for retrieving information about Television shows.
        /// </summary>
        //IApiTVShowRequest Television { get; }

        /// <summary>
        /// Provides access for retreiving information about People.
        /// </summary>
        //IApiPeopleRequest People { get; }
    }
}
