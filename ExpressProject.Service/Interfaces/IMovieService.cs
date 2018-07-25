using ExpressProject.Model;
using ExpressProject.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressProject.Service.Interfaces
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetAllMovies();
        IEnumerable<Movie> GetMovieById();
        IEnumerable<Movie> GetMovieByTitle();
    }
}
