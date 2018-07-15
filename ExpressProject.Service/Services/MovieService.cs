using ExpressProject.Model;
using ExpressProject.Repository.Interfaces;
using ExpressProject.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
