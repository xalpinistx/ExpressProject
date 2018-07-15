using ExpressProject.DAL;
using ExpressProject.Model;
using ExpressProject.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressProject.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        MovieContext dbContext;
        UserRepository userRepository;
        MovieRepository movieRepository;
        bool disposed = false;

        public UnitOfWork(MovieContext context)
        {
            dbContext = context;
        }

        public IRepository<User> Users
        {
            get
            {
                if (dbContext != null)
                {
                    userRepository = new UserRepository(dbContext);
                }
                return userRepository;
            }
        }

        public IRepository<Movie> Movies
        {
            get
            {
                if (dbContext != null)
                {
                    movieRepository = new MovieRepository(dbContext);
                }
                return movieRepository;
            }
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        public void Dispose()
        {
            CleanUp(true);
            GC.SuppressFinalize(this);
        }

        private void CleanUp(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    //Освобождение управляемых ресурсов.
                    dbContext.Dispose();
                }
                else
                {
                    //Очистка неуправляемых ресурсов.
                }

                disposed = true;
            }
        }
    }
}
