using ExpressProject.Model;
using System.Data.Entity;

namespace ExpressProject.DAL
{
    public class MovieContext : DbContext
    {
        public MovieContext() : base("name=MovieContext")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}
