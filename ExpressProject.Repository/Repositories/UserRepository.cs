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
    class UserRepository : IRepository<User>
    {
        MovieContext dbContext;

        public UserRepository(MovieContext context)
        {
            dbContext = context;
        }

        public IEnumerable<User> GetAll()
        {
            return dbContext.Users.ToList();

        }

        public User GetById(int? id)
        {
            var user = dbContext.Users.SingleOrDefault(u => u.UserId == id);

            if (user == null)
            {
                //Console.WriteLine("");
            }

            return user;
        }

        public void Create(User user)
        {
            dbContext.Users.Add(user);
        }

        public void Update(User user)
        {
            dbContext.Entry(user).State = EntityState.Modified;
        }

        public void Delete(int? id)
        {
            User user = dbContext.Users.SingleOrDefault(u => u.UserId == id);

            if (user != null)
                dbContext.Users.Remove(user);
        }
    }
}
