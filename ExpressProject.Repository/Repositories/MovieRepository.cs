using ExpressProject.DAL;
using ExpressProject.Model;
using ExpressProject.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressProject.Repository.Repositories
{
    class MovieRepository : IRepository<Movie>
    {
        MovieContext dbContext;

        public MovieRepository(MovieContext context)
        {
            dbContext = context;
        }

        public void Create(Movie movie)
        {
            dbContext.Movies.Add(movie);
        }

        public void Delete(int? id)
        {
            Movie movie = dbContext.Movies.SingleOrDefault(m => m.MovieId == id);

            if (movie != null)
            {
                dbContext.Movies.Remove(movie);
            }
        }

        public IEnumerable<Movie> GetAll()
        {
            return dbContext.Movies.ToList();
        }

        public Movie GetById(int? id)
        {
            var movie = dbContext.Movies.SingleOrDefault(m => m.MovieId == id);

            if (movie == null)
            {
                //Console.WriteLine("");
            }

            return movie;
        }

        public void Update(Movie movie)
        {
            dbContext.Entry(movie).State = EntityState.Modified;
        }
    }
}
