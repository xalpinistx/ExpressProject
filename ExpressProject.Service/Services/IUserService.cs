using ExpressProject.Model;
using ExpressProject.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressProject.Service
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();

    }
}
