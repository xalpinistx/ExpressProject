using ExpressProject.Model;
using ExpressProject.Repository.Interfaces;
using ExpressProject.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace ExpressProject.Service.Services
{
    public class MovieService : IMovieService
    {
        private IUnitOfWork _unitOfWork;

        public MovieService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _unitOfWork.Movies.GetAll();
        }

        public IEnumerable<Movie> GetMovieById()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetMovieByTitle()
        {
            throw new NotImplementedException();
        }
    }
}
